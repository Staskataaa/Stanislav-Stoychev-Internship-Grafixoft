import DropdownCurrencies from "./Dropdown";
import UpdateState  from "./ButtonAndInputUpdateState";
import * as LocalStotageFilters from "../Utils/LocalStorageFilter";
import * as Utils from '../Utils/FilterResponse';
import Table from "./Table";
import * as FetchAPI from "../Utils/FetchAPI"
import UpdateDateButton from "./UpdateDateButton";
import React from 'react';
import LongestSequence from "../Utils/LongestSequence";

class Application extends React.Component {
    constructor(props)
    {
        super(props);
        this.state = {
            currency: props.defaultCurrency,
            date: props.defaultDate,
            data: null,
            longestSequence: null,
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.UpdateDataForCurrency = this.UpdateDataForCurrency.bind(this);
        this.handleDateUpdate = this.handleDateUpdate.bind(this);
        this.fetchAndFilterData = this.fetchAndFilterData.bind(this);
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        }, function() { 
            this.fetchAndFilterData(this.state.date, this.state.currency)
        });  
    }

    handleDateUpdate(currentDate) {
        this.setState({
            date: currentDate,
        }, function() { 
            this.fetchAndFilterData(this.state.date, this.state.currency)
        });
    }

    async fetchAndFilterData(date, currency) {

        const lowerCaseCurrency = currency.toLowerCase();
        const localStorageKey = date + ' ' + lowerCaseCurrency;
        const response = await FetchAPI.FetchCurrency(lowerCaseCurrency, date);
        const responseToJson = JSON.stringify(response);
        localStorage.setItem(localStorageKey, responseToJson);   
        this.setState ({
            data: response,
        });
    }

    async UpdateDataForCurrency(date, currency)
    {
        const localStorageKey = date + ' ' + currency;
        const response = await FetchAPI.FetchCurrency(currency, date);
        const responseToJson = JSON.stringify(response);
        if(localStorage.getItem(localStorageKey) !== null)
        {
            localStorage.setItem(localStorageKey, responseToJson); 
        }
    }

    componentDidMount() {
        this.fetchAndFilterData(this.state.date, this.state.currency);
    }

    render() {
        return (
            <>
                { 
                    this.state.data !== null &&
                <>
                    <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                    <Table data = { this.state.data } currency = { this.state.currency } date = { this.state.date }/> 
                    <UpdateDateButton handleDateUpdate = { this.handleDateUpdate } date = { this.state.date }/>
                    <UpdateState UpdateDataForCurrency = { this.UpdateDataForCurrency } date = { this.state.date } 
                    currency = { this.state.currency } longestSequence = { this.longestSequence }/>
                </>
                }
            </>
       ) 
    }
}

export default Application