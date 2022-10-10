import { useEffect, useState } from "react";
import * as Constants from "../Constants";
import "../CSS/ButtonUpdateDate.css";
import { getDateToday } from "../Utils/Date";

function ButtonUpdateDate(props) {

    const [ currentDate, setCurrentDate ] = useState();

    useEffect(() => {

        setCurrentDate(props.date);
    }, [props.date])

    const onDateChange = () => {

        props.onDateChange !== undefined && 
        props.date !== null &&
        props.onDateChange(currentDate);
    }

    return(
        <>
        {
            props.date !== currentDate && 
            <div className="button-update-date-container">    
                <button className="button-update-date" onClick={ onDateChange }>Update date</button>
            </div>
        }
        </>
    )
}

export default ButtonUpdateDate