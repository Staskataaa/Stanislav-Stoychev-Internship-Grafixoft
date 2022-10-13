import { useEffect, useState } from 'react';
import * as Constants from "../../Constants"
import * as CurrencyFilters from '../../Utils/CurrencyFilters';
import TableHead from "./TableHead";
import TableBody from './TableBody';
import "../../CSS/Table.css"

function Table(props)
{
    const [items, setItems] = useState();
    
    useEffect(() => {    
        if (props.data !== null) {
            const filteredResponse = CurrencyFilters.applyFilters(props.data);
            setItems(filteredResponse);
        } 
    }, [props.data]);

    if (items !== undefined) {
        return (
            <div> 
                <div className="current-date">
                <label className="exchange-date-label">
                    { props.label } { props.date }
                </label>
            </div>
            <div id ="table-component">
                <table id="table">
                    <TableHead 
                        columnNames = { Constants.tableColumnNames }/>
                    <TableBody
                        data = { items }
                        label={Constants.tableColumnsLenghtsLabel}/>
                </table>
            </div>
        </div>
        );
    }
    else{   
        return (
            <label className='label-loading'>
                { props.loading }
            </label>
        );
    }
}

export default Table;
