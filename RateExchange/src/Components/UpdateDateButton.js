import "../CSS/ButtonUpdateDate.css";
import { getCurrentDay } from "../Utils/Date";

function UpdateDateButton(props) {

    const currentDate = getCurrentDay();

    const onDateChange = () => {
        props.onDateChange !== undefined
        && props.onDateChange(currentDate);
    }

    return (
        props.date !== currentDate 
        && <div className="button-update-date-container">    
            <button className="button-update-date" onClick={onDateChange}>
                { props.buttonText }
            </button>
        </div>
    )
}

export default UpdateDateButton