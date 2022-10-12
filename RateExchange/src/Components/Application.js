import * as FetchCurrency from "../Utils/FetchCurrency";
import * as LocalStotage from "../Utils/LocalStorage";
import * as Constants from "../Constants";
import Dropdown from "./Dropdown";
import InputAndButtonUpdateCurrency from "./InputAndButtonUpdateCurrency";
import Table from "./Table/Table";
import UpdateDateButton from "./UpdateDateButton";
import React from 'react';

class Application extends React.Component {

    state = {
        currency: Constants.defaultCurrency.toLowerCase(),
        data: null,
        date: null,
        longestSequence: null,
        areValuesUpdated: false,
    };

    fetchCurrency = (currency, date) => {
        const lowerCaseCurrency = currency.toLowerCase();
        FetchCurrency.fetchCurrency(lowerCaseCurrency, date)
            .then((res) => {

                const responseDate = res[Constants.date];

                this.setState({
                    data: res[lowerCaseCurrency],
                    date: responseDate,
                })
            })
            .then(() => this.areValuesUpdated())
            .catch((err) => console.log(err));
    }

    constructor(props) {
        super(props);
        const date = this.state.data ?? Constants.latest;
        const currency = this.state.currency ?? Constants.defaultCurrency;

        this.fetchCurrency(currency, date)
        
        this.fetchCurrency = this.fetchCurrency.bind(this);
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
        this.onDateChange = this.onDateChange.bind(this);
        this.areValuesUpdated = this.areValuesUpdated.bind(this);
    }

    onCurrencyChange = (currency, date) => {

        const lowerCaseCurrency = currency.toLowerCase();
        FetchCurrency.fetchCurrency(lowerCaseCurrency, date)
        .then((res) => {

            const responseDate = res[Constants.date];

            this.setState({
                data: res[lowerCaseCurrency],
                date: responseDate,
                currency: lowerCaseCurrency,
            })

        })
        .then(() => this.areValuesUpdated())
        .catch((err) => console.log(err)); 
        this.areValuesUpdated();
    }

    onDateChange(date) {
        this.fetchCurrency(this.state.currency, date);
    }

    areValuesUpdated() {

        const areValuesUpdated = LocalStotage.areCurrenciesUpdated();
        this.setState({
            areValuesUpdated: areValuesUpdated
        });
    }

    renderDropdown() {
        return (
            <Dropdown
                options={Constants.currencyList}
                onValueChange={this.onCurrencyChange}
                defaultSelectedValue={this.state.currency.toUpperCase()}
                label={Constants.dropdownLabel} />  
        )
    }

    renderTable() {
        return (
            <Table
                label={Constants.exchangeRateLabel}
                data={this.state.data}
                currency={this.state.currency}
                date={this.state.date}
                loading={Constants.LoadingData} /> 
        )
    }

    renderUpdateDateButton() {
        return (
            <UpdateDateButton
                onDateChange={this.onDateChange}
                date={this.state.date} />
        )
    }

    renderInputAndButtonUpdateCurrency() {
        return (
            <InputAndButtonUpdateCurrency
                onUpdateButtonClick={this.onCurrencyChange}
                currency={this.state.currency}
                areValuesUpdated = {this.state.areValuesUpdated}
                label = { Constants.inputLabel }
                longestSequenceMessage={Constants.longestSequenceMessage}
                buttonText = {Constants.updateButtonName}/>
        )
    }

    render () {
        return (
            <>
                { this.renderDropdown() }
                { this.renderTable() }
                {this.renderUpdateDateButton()}
                { this.renderInputAndButtonUpdateCurrency() }    
            </>
        )
    }
}

export default Application