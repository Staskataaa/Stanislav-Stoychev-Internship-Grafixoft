import { useState } from "react";
import * as Constants from "../Constants" 
import "../CSS/ButtonUpdateDate.css"

function ButtonUpdateDate(props) {

    const onDateUpdate = () => {
        props.onDateUpdate(Constants.currentDate);
    }

    return(
        <div className="button-update-date-container">
            {
                props.date !== Constants.currentDate && 
                <button className = "button-update-date" onClick={ onDateUpdate }>Update date</button>
            }
        </div>
    )
}

export default ButtonUpdateDate