import { useEffect, useMemo, useState } from 'react';
import { FetchCurrency } from '../Utils/FetchAPI';
import * as Utils from '../Utils/FilterResponse';
import "../CSS/Table.css"
import { useQuery } from 'react-query';


function TableComponent(props)
{
    const [items, setItems] = useState([]);

    const { result } = useQuery([props.currency, props.date], async () => {
        const currency = props.currency.toLowerCase();
        const date = props.date;
        const response = await FetchCurrency(currency, date);
        const dataCurrency = Object.entries(response[currency]);
        const currenctyList = Utils.filterCurrencies(dataCurrency);
        const sortIntoArrays = Utils.ArrayGroups(currenctyList); 
        const convertToArray = Object.values(sortIntoArrays);   
        console.log(convertToArray);    
        return convertToArray;
    });

    useEffect(() => {
        if(result)
        {
            setItems(result)
        }
    }, [result, props]);

    return (    
        <div id ="table-component">
        <table id="table">
          <thead className="main-table-head">
                <tr>
                    <th>Conversion Rates below 1</th>
                    <th>Conversion Rates between 1 and 1,5</th>
                    <th>Conversion Rates above 1,5</th>
                </tr>
            </thead>
                <tbody id="table-body">
                    
                </tbody>
            </table>
          </div>
    );
}

export default TableComponent;
