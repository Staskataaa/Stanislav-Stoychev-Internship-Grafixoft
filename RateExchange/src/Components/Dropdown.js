import "../CSS/Dropdown.css";
import Select from 'react-select';
import { useEffect, useState } from "react";
import * as DropdownOptions from "../Utils/DropdownOptions"

function Dropdown(props) {

    const [ dropdownData, setDropdownData ] = useState(null);

    useEffect(() => {
        
        if (props.defaultSelectedValue) {
            const data = DropdownOptions.dropdownOptionsData(props.options);
            setDropdownData(data);
        } 
    }, [props.defaultSelectedValue, props.options])

    const onValueChange = (option) => {

        const optionLowerCase = option.value.toLowerCase();
        props.onValueChange !== undefined &&
        props.onValueChange(optionLowerCase);
    }

    return (
        <div className="dropdown-container">
            <label id="currency-label">
                { props.label }
            </label>
            {
                dropdownData !== null && 
                <Select
                    id="select-menu"
                    options = { dropdownData } 
                    value = { dropdownData.filter((option) =>
                    option.value === props.defaultSelectedValue )}
                    onChange= { onValueChange } />
            }
        </div> 
    )
}

export default Dropdown

