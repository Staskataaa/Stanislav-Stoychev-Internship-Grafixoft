import "../CSS/ButtonUpdateDate.css";
import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";

function UpdateDateButton(props) {

    const currentDate = getCurrentDay();

    const onDateChange = () => {
        props.onDateChange !== undefined
        && props.onDateChange(currentDate);
    }

    return (
        <>
        {
            props.date !== currentDate && 
            <div className="button-update-date-container">    
                <button className="button-update-date" onClick={onDateChange}>
                    {Constants.updateDateButtonText}
                </button>
            </div>
        }
        </>
    )
}

export default UpdateDateButton