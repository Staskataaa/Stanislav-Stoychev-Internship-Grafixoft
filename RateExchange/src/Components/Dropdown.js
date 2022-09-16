import * as Constants from "../Constants/Constants"
import "../CSS/Dropdown.css"

function DropdownCurrencies(props) {

    let DefaultCurrency = 'USD';

    const handleChange = event => {
        DefaultCurrency = props.handleChange && 
        props.handleChange(event.target.value);
    }

    return (
        <div className="dropdown-container">
            <label id="currency-label">Currency: </label>
            <select name="currency-names" id="currencies-ids" onChange={handleChange}>
                {
                    Constants.CurrencyList.map((currency, index) => {
                        return (
                            <option key = {index} className="dropdown-item">
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

