import * as FetchCurrency from "../Utils/FetchCurrency";
import * as LocalStotage from "../Utils/LocalStorage";
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
            data: null,
            longestSequence: null,
            updatedValues: false,
        };

        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateUpdate = this.onDateUpdate.bind(this);
        this.setDataLatest = this.setDataLatest.bind(this);
        this.setDataForDate = this.setDataForDate.bind(this);
        this.onCurrencyAndDateChange = this.onCurrencyAndDateChange.bind(this);
    }

    componentDidMount() {
        this.setDataLatest(this.state.currency);
    }

    async fetchDataLatest(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchCurrency.fetchCurrencyLatest(lowerCaseCurrency, Constants.currentDate);
        this.setUpdatedValues();
        return response;
    }

    async fetchDataForDate(currency, date) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchCurrency.fetchCurrencyDate(lowerCaseCurrency, date);
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

    onCurrencyAndDateChange(date, currency) { 

        this.setState({
            currency: currency,
        }, function() { 
            this.setDataForDate(this.state.currency, date)
        });  
    }

    onDateUpdate(date) {

        this.setState({
            date: date
        }, function() {
            this.setDataForDate(this.state.currency, date)
        })
        
    }

    async setDataLatest(currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await this.fetchDataLatest(lowerCaseCurrency);
        const responseDate = response[Constants.dateString]; 
        this.setState ({
            data: response,
            date: responseDate,
        });
    }

    async setDataForDate(currency, date) {
        const lowerCaseCurrency = currency.toLowerCase();
        const response = await this.fetchDataForDate(lowerCaseCurrency, date);
        this.setState ({
            data: response,
        });
    }

    render() {
        return (
            <>
                { 
                    this.state.data !== null &&
                    <>
                        <Dropdown 
                        onCurrencyChange={ this.onCurrencyChange } 
                        currency={ this.state.currency.toUpperCase() }/>
                        <Table 
                        data = { this.state.data } 
                        currency = { this.state.currency.toLowerCase() } 
                        date = { this.state.date }/> 
                        <UpdateDateButton 
                        onDateUpdate = { this.onDateUpdate } 
                        date = { this.state.date } />
                        <UpdateCurrency 
                        onCurrencyAndDateChange={this.onCurrencyAndDateChange } 
                        date = { this.state.date } 
                        currency = { this.state.currency.toLowerCase() } 
                        updatedValues = { this.state.updatedValues} />
                    </>
                }
            </>
       ) 
    }
}

export default Application