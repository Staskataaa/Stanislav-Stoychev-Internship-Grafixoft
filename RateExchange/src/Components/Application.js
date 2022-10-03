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
        this.setDataLatest = this.setDataLatest.bind(this);
        this.setDataDate = this.setDataDate.bind(this);
        this.setCurrencyAndDate = this.setCurrencyAndDate.bind(this);
    }

    async fetchDataLatest(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchAPI.fetchCurrencyLatest(lowerCaseCurrency, Constants.currentDate);
        this.setUpdatedValues();
        return response;
    }

    async fetchDataDate(currency, date) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchAPI.fetchCurrencyDate(lowerCaseCurrency, date);
        this.setUpdatedValues();
        return response;
    }

    onCurrencyChange(value) {

        const newCurrency = value.value.toLowerCase();

        this.setState({
            currency: newCurrency,
        }, function() { 
            this.setDataLatest(this.state.currency)
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
            this.setDataLatest(this.state.currency)
        });  
    }

    onDateUpdate(currency) {

        this.setDataDate(currency, Constants.currentDate);
    }

    async setDataLatest(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await this.fetchDataLatest(lowerCaseCurrency);
        const responseDate = response['date']; 
        this.setState ({
            data: response,
            date: responseDate,
        });
    }

    async setDataDate(currency, date) {
        const lowerCaseCurrency = currency.toLowerCase();
        const response = await this.fetchDataDate(lowerCaseCurrency, date);
        this.setState ({
            data: response,
            date: date,
        });
    }
    
    componentDidMount() {
        this.setDataLatest(this.state.currency);
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
                    <UpdateDateButton onDateUpdate = { this.onDateUpdate } date = { this.state.date } />
                    <UpdateCurrency setCurrencyAndDate = { this.setCurrencyAndDate } date = { this.state.date } 
                    currency = { this.state.currency.toLowerCase() } updatedValues = { this.state.updatedValues} />
                </>
                }
            </>
       ) 
    }
}

export default Application