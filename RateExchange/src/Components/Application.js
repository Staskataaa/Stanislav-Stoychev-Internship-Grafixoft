import DropdownCurrencies from "./Dropdown";
import Table from "./Table";
import React from 'react';

class Application extends React.Component {
    constructor(props)
    {
        super(props);
        this.state = {
          currency: props.defaultCurrency,
          date: props.defaultDate
        };
        this.onCurrencyChange = this.onCurrencyChange.bind(this);
    }

    onCurrencyChange(value) {
        this.setState({
            currency: value
        });    
    }

    render() {
        return (
            <>
                <DropdownCurrencies handleChange={ this.onCurrencyChange } currency={ this.state.currency }/>
                <Table currency={ this.state.currency } date ={ this.state.date }/>
            </>
       ) 
    }
}

export default Application