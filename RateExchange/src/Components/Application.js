import DropdownCurrencies from "./Dropdown";
import UpdateState  from "./ButtonAndInputUpdateState";
import * as LocalStotageFilters from "../Utils/LocalStorage";
import * as Utils from '../Utils/FilterResponse';
import Table from "./Table";
import * as FetchAPI from "../API/FetchAPI"
import UpdateDateButton from "./UpdateDateButton";
import React from 'react';
import * as LongestSequence from "../Utils/LongestSequence";

class Application extends React.Component {
    constructor(props)
    {
        super(props);
        this.state = {
            currency: props.defaultCurrency,
            date: props.defaultDate,
            data: null,
            longestSequence: null,
            updatedValues: false,
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.updateDataForCurrency = this.updateDataForCurrency.bind(this);
        this.handleDateUpdate = this.handleDateUpdate.bind(this);
        this.setStateData = this.setStateData.bind(this);
        this.setCurrencyAndDate = this.setCurrencyAndDate.bind(this);
    }

    async fetchData(date, currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const response = await FetchAPI.FetchCurrency(lowerCaseCurrency, date);
        this.setUpdatedValuesFlag();
        return response;
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        }, function() { 
            this.setStateData(this.state.date, this.state.currency)
        });  
    }

    setUpdatedValuesFlag() {
        const check = LocalStotageFilters.CheckIfAllCurrenciesAreUpdated();
        if(this.state.updatedValues !== check)
        this.setState({
            updatedValues: check
        });
    }

    setCurrencyAndDate(date, currency) {
        this.setState({
            currency: currency,
            date: date,
        }, function() { 
            this.setStateData(this.state.date, this.state.currency)
        });  
    }

    handleDateUpdate(currentDate) {
        this.setState({
            date: currentDate,
        }, function() { 
            this.setStateData(this.state.date, this.state.currency)
        });
    }

    async setStateData(date, currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const localStorageKey = date + ' ' + lowerCaseCurrency;
        const response = await this.fetchData(date, lowerCaseCurrency);
        const responseToJson = JSON.stringify(response);
        localStorage.setItem(localStorageKey, responseToJson);   
        this.setState ({
            data: response,
        });
    }

    async updateDataForCurrency(date, currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const localStorageKey = date + ' ' + lowerCaseCurrency;
        const response = await this.fetchData(date, lowerCaseCurrency);
        const responseToJson = JSON.stringify(response);
        if(localStorage.getItem(localStorageKey) !== null)
        {
            localStorage.setItem(localStorageKey, responseToJson); 
        }
    }

    componentDidMount() {
        this.setStateData(this.state.date, this.state.currency);
    }

    render() {
        return (
            <>
                { 
                    this.state.data !== null &&
                <>
                    <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                    <Table data = { this.state.data } currency = { this.state.currency } date = { this.state.date }/> 
                    <UpdateDateButton handleDateUpdate = { this.handleDateUpdate } date = { this.state.date }
                    currency = { this.state.currency }/>
                    <UpdateState setCurrencyAndDate = { this.setCurrencyAndDate } date = { this.state.date } 
                    currency = { this.state.currency } longestSequence = { this.longestSequence } 
                    updatedValues = { this.state.updatedValues} />
                </>
                }
            </>
       ) 
    }
}

export default Application