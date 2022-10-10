import * as FetchCurrency from "../Utils/FetchCurrency";
import * as LocalStotage from "../Utils/LocalStorage";
import * as Constants from "../Constants";
import Dropdown from "./Dropdown";
import UpdateCurrency  from "./UpdateCurrency";
import Table from "./Table/Table";
import UpdateDateButton from "./UpdateDateButton";
import React from 'react';

class Application extends React.Component {
    constructor(props)
    {
        super(props);

        this.state = {
            currency: props.defaultCurrency,
            data: null,
            date: null,
            longestSequence: null,
            updatedValues: false,
        };

        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateChange = this.onDateChange.bind(this);
        this.setData = this.setData.bind(this);
    }

    componentDidMount() {
        this.setData(this.state.currency);
    }

    async fetchData(currency, date) {

        const lowerCaseCurrency = currency.toLowerCase();
        
        const response = await FetchCurrency.fetchCurrency(lowerCaseCurrency, date);
        this.setUpdatedValues();
        return response;
    }

    onCurrencyChange(value, date) {

        this.setState({
            currency: value
        }, function() {
            this.setData(value, date); 
        }) 
    }

    setUpdatedValues() {

        const areValuesUpdated = LocalStotage.AreCurrenciesUpdated();

        if (this.state.updatedValues !== areValuesUpdated)
        {
            this.setState({
                updatedValues: areValuesUpdated
            });
        }
    }

    onDateChange(date) {
        this.setData(this.state.currency, date);
    }

    async setData(currency, date) {
        const lowerCaseCurrency = currency.toLowerCase();
        const response = await this.fetchData(lowerCaseCurrency, date);
        const responseDate = response[Constants.date];
        this.setState ({
            data: response,
            date: responseDate,
        });
    }

    render () {
        return (
            <>
                <Dropdown 
                onCurrencyChange={ this.onCurrencyChange } 
                currency={ this.state.currency.toUpperCase() }/>
                <Table 
                data = { this.state.data } 
                currency = { this.state.currency.toLowerCase() } 
                date = { this.state.date }/> 
                <UpdateDateButton 
                onDateChange = { this.onDateChange } 
                date = { this.state.date } />
                <UpdateCurrency 
                onCurrencyChange = { this.onCurrencyChange } 
                currency = { this.state.currency.toLowerCase() } 
                updatedValues = { this.state.updatedValues} />
            </>
       ) 
    }
}

export default Application