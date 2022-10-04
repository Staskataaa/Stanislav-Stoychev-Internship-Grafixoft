import * as Constants from "../Constants";
import "../CSS/Dropdown.css";
import Select from 'react-select';
import { useEffect, useState } from "react";
import * as DropdownOptions from "../Utils/DropdownOptions"

function DropdownCurrencies(props) {

    const [ dropdownData, setDropdownData ] = useState(null);

    useEffect(() => {
        const data =  DropdownOptions.dropdownOptionsData(Constants.currencyList);
        setDropdownData(data);

    }, [props.currency])

    const onCurrencyChange = (option) => {
        props.onCurrencyChange(option);
    }

    return (
        <div className="dropdown-container">
            <label id="currency-label">Currency: </label>
            {
                dropdownData !== null && 
                <Select
                    options = { dropdownData } 
                    value = { dropdownData.filter((option) =>
                    option.value === props.currency )}
                    onChange = { onCurrencyChange }
                />
            }
        </div> 
    )
}

export default DropdownCurrencies

