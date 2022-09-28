import { useEffect, useState } from 'react';
import * as FetchAPI from '../API/FetchAPI';
import * as LocalStorageFilters from "../Utils/LocalStorage";
import * as Utils from '../Utils/FilterResponse';
import * as Consts from '../Constants/Constants'
import "../CSS/Table.css"
import { useQuery } from 'react-query';

function TableComponent(props)
{
    const [items, setItems] = useState([]);
    
    useEffect(() => {
        const lowerCaseCurrency =  props.currency.toLowerCase();
        const filteredResponse = Utils.ApplyFilters(props.data, lowerCaseCurrency);
        setItems(filteredResponse);

    }, [props.data]);

    return (
    <div> 
        <div className="current-date">
            <label className="exchange-date-label">Exchange Rates from {props.date}</label>
        </div>
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
        </div>
    );
}

export default TableComponent;
