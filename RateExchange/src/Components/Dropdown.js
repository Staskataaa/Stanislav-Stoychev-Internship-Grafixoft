import * as Constants from "../Constants/Constants"
import "../CSS/Dropdown.css"

function DropdownCurrencies(props) {

    const handleChange = event => {
        props.handleChange(event.target.value);
    }

    return (
        <div className="dropdown-container">
            <label id="currency-label">Currency: </label>
            <select name="currency-names" id="currencies-ids" onChange={handleChange}>
                {
                    Constants.CurrencyList.map((currency, index) => {
                        return (
                            <option key = { index } className="dropdown-item" 
                            defaultValue = { currency === props.currency.toUpperCase() }>
                                { currency }
                            </option>
                        )
                    })
                }
            </select>
        </div> 
    )
}

export default DropdownCurrencies

