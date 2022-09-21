import DropdownCurrencies from "./Dropdown";
import ButtonUpdateDate  from "./ButtonUpdateDate";
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
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateChange = this.onDateChange.bind(this);
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        });   
    }

    onDateChange(value)
    {
        this.setState({
            date: value
        });   
    }

    render() {
        return (
            <>
                <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                <Table currency={ this.state.currency } date ={ this.state.date } /> 
                <ButtonUpdateDate handleChangeDate = { this.onDateChange } date = { this.state.date }/>
            </>
       ) 
    }
}

export default Application