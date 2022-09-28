import "../CSS/ButtonUpdateState.css";
import * as Constants from "../Constants/Constants";
import { useEffect, useRef, useState } from "react";
import * as Utils from "../Utils/FilterResponse";
import * as FetchAPI from "../API/FetchAPI"
import * as LocalStorageFilters from "../Utils/LocalStorage"
import * as LongestSequence from "../Utils/LongestSequence";

function ButtonUpdateState(props)
{
    const inputRef = useRef(null);
    const [longestSequence, setLongestSequence] = useState(null);

    useEffect(() => {
        const longestSequence = LongestSequence.longestSequence(props.currency.toLowerCase());
        setLongestSequence(longestSequence);
    }, [props.updatedValues, props.currency])


    const setCurrencyAndDate = event => {
        const upperCaseCurrency = inputRef.current.value.toUpperCase();
        if(!Constants.CurrencyList.includes(upperCaseCurrency))
        {
            alert("Invalid Currency name!");
        }
        else 
        {
            props.setCurrencyAndDate(Constants.currentDate,
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
                        <button className="update-button" onClick={ setCurrencyAndDate }>Update Currency</button>
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

export default ButtonUpdateState;