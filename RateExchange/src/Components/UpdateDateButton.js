import * as Constants from "../Constants/Constants" 
import "../CSS/ButtonUpdateDate.css"

function ButtonUpdateDate(props) {
    
    const handleDateUpdate = event => {
        props.handleDateUpdate(Constants.currentDate);
    }

    return(
        <div className="button-update-date-container">
            {
                props.date !== Constants.currentDate && 
                <button className = "button-update-date" onClick={ handleDateUpdate }>Update date</button>
            }
        </div>
    )
}

export default ButtonUpdateDate