import "../CSS/ButtonUpdateState.css";
import * as Constants from "../Constants";
import { useEffect, useRef, useState } from "react";
import * as LongestSequence from "../Utils/LongestSequence";

function UpdateCurrency(props)
{
    const inputRef = useRef(null);
    const [longestSequence, setLongestSequence] = useState(null);

    useEffect(() => {

        const longestSequence = LongestSequence.longestSequence(props.currency);
        setLongestSequence(longestSequence);

    }, [props.updatedValues, props.currency])


    const onCurrencyAndDateChange = () => {

        const upperCaseCurrency = inputRef.current.value.toUpperCase();

        if(!Constants.currencyList.includes(upperCaseCurrency))
        {
            alert("Invalid Currency name!");
        }

        else 
        {
            props.onCurrencyAndDateChange(Constants.currentDate,
            inputRef.current.value.toLowerCase());
        }

        inputRef.current.value = "";
    }
   
    return (
        <div className="update-state-container"> 
            {
                props.updatedValues === false &&
                <div className="input-container">
                    <label className="label-input">
                        Input Currency Name:
                    </label>
                    <input className="currency-input" ref={ inputRef }></input>
                </div>
            }
            <div className="button-container">
            {   
                props.updatedValues === false &&           
                <div className="button-container">
                            <button className="update-button" onClick={ onCurrencyAndDateChange }>Update Currency</button>
                    </div> 
            }
            </div>   
            <div className="longest-sequence-container">
            {
                props.updatedValues === true &&
                <label className="longest-sequence">
                    The longest sequence is: { longestSequence }
                </label>
            }
            </div>
        </div>  
    )
}

export default UpdateCurrency;