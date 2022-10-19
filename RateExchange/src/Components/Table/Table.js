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

    const RenderTable = () => {
        return (
            items !== null 
            && <div className='testClass'> 
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
                        countField={Constants.tableColumnsLenghtsLabel}/>
                </table>
            </div>
        </div>
        );
    }

    const LoadingData = () => {

        return (
            items === null 
            && <label className='label-loading'>
                { props.loading }
            </label>
        );
    }

    return (
        <>
            <LoadingData />
            <RenderTable />
        </>
    )
}

export default Table;
