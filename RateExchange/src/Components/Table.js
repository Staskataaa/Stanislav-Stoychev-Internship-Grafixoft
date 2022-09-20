import { useEffect, useState } from 'react';
import { FetchCurrency } from '../Utils/FetchAPI';
import * as Utils from '../Utils/FilterResponse';
import "../CSS/Table.css"
import { useQuery } from 'react-query';

function TableComponent(props)
{
    const [items, setItems] = useState([]);
    
    useEffect(() => {

        async function fetchData() {
            const currency = props.currency.toLowerCase();
            const date = props.date;
            const response = await FetchCurrency(currency, date);
            const dataCurrency = Object.entries(response[currency]);
            const currenctyList = Utils.filterCurrencies(dataCurrency);
            const sortedList = Utils.sortCurrencies(currenctyList);
            const sortIntoArrays = Utils.ArrayGroups(sortedList); 
            const convertToArray = Object.values(sortIntoArrays);   
            setItems(convertToArray);
        }     
        
        fetchData();
        
    }, [props.currency, props.date]);

    return (    
        <div id ="table-component">
        <table id="table">
          <thead className="table-head">
                <tr>
                    <th>Conversion Rates below 1</th>
                    <th>Conversion Rates between 1 and 1,5</th>
                    <th>Conversion Rates above 1,5</th>
                </tr>
            </thead>
                <tbody id="table-body">
                    {
                        Utils.convertToTableFormat(items).map((array, arrayIndex) => {
                            return (
                                <tr key = {arrayIndex} className="table-row">
                                    {
                                        array.map((item, itemIndex) => {
                                            if(item !== undefined)
                                            {
                                                return (
                                                <td key = {itemIndex} className="table-col">
                                                    {item[0]} : {item[1]}
                                                </td>
                                                )
                                            }
                                            else
                                            {
                                                return (
                                                <td key = {itemIndex} className="table-col"></td>
                                                )
                                            }
                                        })
                                    }
                                </tr>
                            )
                        })
                    }
                    <tr className="table-row">
                        {
                            items.map((value, index) => {
                                return (
                                    <td key={index} className="table-col">
                                        Count: {value.length}
                                    </td>
                                )
                            })
                        }
                    </tr>
                </tbody>
            </table>
          </div>
    );
}

export default TableComponent;
