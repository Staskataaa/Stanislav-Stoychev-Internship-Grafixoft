import DropdownCurrencies from "./Dropdown";
import * as Utils from '../Utils/FilterResponse';
import { FetchCurrency } from "../Utils/FetchAPI";
import Table from "./Table";
import React from 'react';

class Application extends React.Component {
    constructor(props)
    {
        super(props);
        this.state = {
            currency: props.defaultCurrency,
            date: props.defaultDate,
            response: []
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        //this.fetchData = this.fetchData.bind(this);
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        });    
    }

    /*fetchData = (date, currency) =>
    {
        async function result (date, currency) {
            const lowerCaseCurrency = currency.toLowerCase();
            const response = await FetchCurrency(lowerCaseCurrency, date);
            const dataCurrency = Object.entries(response[lowerCaseCurrency]);
            const currenctyList = Utils.filterCurrencies(dataCurrency);
            const sortedList = Utils.sortCurrencies(currenctyList);
            const sortIntoArrays = Utils.ArrayGroups(sortedList); 
            const convertToArray = Object.values(sortIntoArrays);   
            this.setState({
                response: convertToArray
            })  
        }

        result(date, currency);

    }*/

    render() {
        return (
            <>
                <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                <Table currency={ this.state.currency } date ={ this.state.date } />
            </>
       ) 
    }
}

export default Application