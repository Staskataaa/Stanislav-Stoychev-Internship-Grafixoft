import * as Constants from "../Constants" 
import "../CSS/ButtonUpdateDate.css"

function ButtonUpdateDate(props) {

    const onDateUpdate = () => {
        props.onDateUpdate(Constants.currentDate);
    }

    return(
        <>
        {
            props.date !== Constants.currentDate && 
            <div className="button-update-date-container">    
                <button className = "button-update-date" onClick={ onDateUpdate }>Update date</button>
            </div>
        }
        </>
    )
}

export default ButtonUpdateDate