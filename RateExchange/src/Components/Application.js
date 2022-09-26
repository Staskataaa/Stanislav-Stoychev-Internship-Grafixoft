import DropdownCurrencies from "./Dropdown";
import ButtonUpdateState  from "./ButtonUpdateState";
import * as LocalStotageFilters from "../Utils/LocalStorageFilter";
import * as Utils from '../Utils/FilterResponse';
import Table from "./Table";
import React from 'react';

class Application extends React.Component {
    constructor(props)
    {
        super(props);
        this.state = {
            currency: props.defaultCurrency,
            date: props.defaultDate,
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateChange = this.onDateChange.bind(this);
        this.longestSequence = this.longestSequence.bind(this);
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        });   
    }

    onDateChange(dateValue, currencyName)
    {
        LocalStotageFilters.FilterLocalStotage(currencyName);
        this.setState({
            date: dateValue,
        });   
    }

    longestSequence() {
        const check = LocalStotageFilters.CheckIfAllCurrenciesAreUpdated();
        if(check === true)
        {
            const allValues = LocalStotageFilters.FillAllChangeRatesFromStorage();
            const uniqueValues = Utils.FilterUniqueValues(allValues);
            const sortedValues = Utils.SortValues(uniqueValues);
            const longestSequence = Utils.FindLongestSequesnce(sortedValues);
            console.log(sortedValues);
            return longestSequence;
        }
    }

    render() {
        return (
            <>
                <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                <Table currency={ this.state.currency } date ={ this.state.date } /> 
                <ButtonUpdateState handleChangeDate = { this.onDateChange } date = { this.state.date } 
                currency = { this.state.currency } longestSequence = { this.longestSequence }/>
            </>
       ) 
    }
}

export default Application