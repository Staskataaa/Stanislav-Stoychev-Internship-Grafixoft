import "../CSS/ButtonUpdateState.css";
import * as Constants from "../Constants/Constants";
import { useEffect, useRef, useState } from "react";
import * as Utils from "../Utils/FilterResponse";
import * as FetchAPI from "../Utils/FetchAPI"
import * as LocalStorageFilters from "../Utils/LocalStorageFilter"
import * as LongestSequence from "../Utils/LongestSequence";

function ButtonUpdateState(props)
{
    const inputRef = useRef(null);

    const [allUpdatedValues, setAllUpdatedValues] = useState(false);

    const UpdateDataForCurrency = event => {
        props.UpdateDataForCurrency(Constants.currentDate, inputRef.current.value.toLowerCase());
        const check = CheckIfAllCurrenciesAreUpdated();
        if(check === true)
        {
            setAllUpdatedValues(true);
        }
    }

    return (
        <div className="update-state-container"> 
            {
                longestSequence === null &&
                <div className="input-container">
                    <label className="label-input">
                        Input Currency Name:
                    </label>
                    <input className="currency-input" ref={ inputRef }></input>
                </div>
            }
            <div className="button-container">
            {  
                longestSequence === null &&             
                <div className="button-container">
                        <button className="update-button" onClick={ UpdateDataForCurrency }>Update Currency</button>
                    </div> 
            }
            </div>   
            <div className="longest-sequence-container">
                {
                    longestSequence !== null &&
                    <label className="longest-sequence">
                        The longest sequence is: { longestSequence }
                    </label>
                }
            </div>
        </div>  
    )
}

export default ButtonUpdateState;