import "../CSS/ButtonUpdateState.css";
import * as Constants from "../Constants";
import { useEffect, useRef, useState } from "react";
import * as LongestSequence from "../Utils/LongestSequence";
import { getCurrentDay } from "../Utils/Date"

function UpdateCurrency(props)
{
    const inputRef = useRef();
    const [longestSequence, setLongestSequence] = useState();

    useEffect(() => {

        const longestSequence = LongestSequence.longestSequence(props.currency);
        setLongestSequence(longestSequence);

    }, [props.updatedValues, props.currency])


    const onCurrencyChange = () => {

        const upperCaseCurrency = inputRef.current.value.toUpperCase();

        if(!Constants.currencyList.includes(upperCaseCurrency))
        {
            alert("Invalid Currency name!");
        }

        else 
        {
            const currentDate = getCurrentDay();
            props.onCurrencyChange !== undefined && 
            props.onCurrencyChange(inputRef.current.value.toLowerCase(), 
            currentDate);
        }

        inputRef.current.value = "";
    }
    
    return (
        <div className="update-state-container"> 
            {
                props.updatedValues === false &&
                <div className="input-container">
                    <label className="label-input">
                        { Constants.inputLabel }
                    </label>
                    <input className="currency-input" ref={ inputRef }></input>
                </div>
            }
            <div className="button-container">
            {   
                props.updatedValues === false &&           
                <div className="button-container">
                    <button className="update-button" 
                    onClick={ onCurrencyChange }>
                    Update Currency
                    </button>
                </div> 
            }
            </div>   
            <div className="longest-sequence-container">
            {
                props.updatedValues === true &&
                <label className="longest-sequence">
                    { Constants.longestSequenceMessage } { longestSequence }
                </label>
            }
            </div>
        </div>  
    )
    
}

export default UpdateCurrency;