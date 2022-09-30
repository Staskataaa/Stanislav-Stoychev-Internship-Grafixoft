import * as FetchAPI from "../API/FetchAPI"
import * as LocalStotage from "../Utils/LocalStorage"
import * as Constants from "../Constants";
import Dropdown from "./Dropdown";
import UpdateCurrency  from "./UpdateCurrency";
import Table from "./Table";
import UpdateDateButton from "./UpdateDateButton";
import React from 'react';

class Application extends React.Component {
    constructor(props)
    {
        super(props);

        this.state = {
            currency: props.defaultCurrency,
            currentDate: null,
            dayOfLastFetch: null,
            data: null,
            longestSequence: null,
            updatedValues: false,
        };

        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateUpdate = this.onDateUpdate.bind(this);
        this.setData = this.setData.bind(this);
        this.setCurrencyAndDate = this.setCurrencyAndDate.bind(this);
    }

    async fetchData(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchAPI.fetchCurrency(lowerCaseCurrency);
        this.setUpdatedValues();
        return response;
    }

    onCurrencyChange(value) {

        const newCurrency = value.value.toLowerCase();

        this.setState({
            currency: newCurrency,
        }, function() { 
            this.setData(this.state.currency)
        });  
    }

    setUpdatedValues() {

        const check = LocalStotage.AreCurrenciesUpdated();

        if(this.state.updatedValues !== check)
        {
            this.setState({
                updatedValues: check
            });
        }
    }

    setCurrencyAndDate(date, currency) { 

        this.setState({
            currency: currency,
            date: date,
        }, function() { 
            this.setData(this.state.currency)
        });  
    }

    onDateUpdate(currentDate) {

        this.setState({
            date: currentDate,
        }, function() { 
            this.setData(this.state.currency)
        });
    }

    async setData(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const localStorageKey = Constants.currentDate + ' ' + lowerCaseCurrency;
        const response = await this.fetchData(lowerCaseCurrency);
        const responseDate = response['date'];
        const responseToJson = JSON.stringify(response);
        localStorage.setItem(localStorageKey, responseToJson);   
        console.log(Constants.currentDate);
        this.setState ({
            data: response,
            date: responseDate,
        });
    }
    
    componentDidMount() {
        this.setData(this.state.currency);
    }

    render() {
        return (
            <>
                { 
                    this.state.data !== null &&
                <>
                    <Dropdown onCurrencyChange={ this.onCurrencyChange } currency={ this.state.currency.toUpperCase() }/>
                    <Table data = { this.state.data } currency = { this.state.currency.toLowerCase() } 
                    date = { this.state.date }/> 
                    {
                        Constants.currentDate === this.state.date &&
                        <UpdateDateButton onDateUpdate = { this.onDateUpdate } date = { this.state.date } />
                    }
                    <UpdateCurrency setCurrencyAndDate = { this.setCurrencyAndDate } date = { this.state.date } 
                    currency = { this.state.currency } updatedValues = { this.state.updatedValues} />
                </>
                }
            </>
       ) 
    }
}

export default Application