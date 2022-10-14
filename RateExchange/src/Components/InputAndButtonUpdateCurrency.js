import "../CSS/ButtonUpdateState.css";
import * as Constants from "../Constants";
import { useEffect, useRef, useState } from "react";
import * as LongestSequence from "../Utils/LongestSequence";
import { getCurrentDay } from "../Utils/Date"

function InputAndButtonUpdateCurrency(props)
{
    const inputRef = useRef();
    const [longestSequence, setLongestSequence] = useState();

    useEffect(() => {
        
        if(props.currency) {
            
            const longestSequence = LongestSequence.longestSequence(props.currency, localStorage);
            setLongestSequence(longestSequence);
        }

    }, [props.currency, props.areValuesUpdated])

    const onUpdateButtonClick = () => {

        const upperCaseCurrency = inputRef.current.value.toUpperCase();

        if (Constants.currencyList.includes(upperCaseCurrency)) {

            const currentDate = getCurrentDay();
            props.onUpdateButtonClick !== undefined &&
            props.onUpdateButtonClick(inputRef.current.value.toLowerCase(),
            currentDate);
        }

        else {
            alert("Invalid Currency name!");
        }

        inputRef.current.value = "";
    }

    const LabelAndInput = () => {
        return (
            <div className="input-container">
                <label className="label-input">
                    {props.label}
                </label>
                <input className="currency-input" ref={inputRef}></input>
            </div>
        )
    }

    const UpdateCurrencyButton = () => {
        return (
            <div className="button-container">
                {
                    props.areValuesUpdated === false &&
                    <div className="button-container">
                        <button className="update-button"
                            onClick={onUpdateButtonClick}>
                            { props.buttonText }
                        </button>
                    </div>
                }
            </div> 
        )
    }

    const LongestSequenceText = () => {
        return (
            <div className="longest-sequence-container">
                {
                    props.areValuesUpdated === true 
                    && <label className="longest-sequence">
                        {props.longestSequenceMessage} {longestSequence}
                    </label>
                }
            </div>
        )
    }
    
    return (
        <div className="update-state-container">                  
            <LabelAndInput />
            <LongestSequenceText />
            <UpdateCurrencyButton />
        </div>
    )
}

export default InputAndButtonUpdateCurrency;