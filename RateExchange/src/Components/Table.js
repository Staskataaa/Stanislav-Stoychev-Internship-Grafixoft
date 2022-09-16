import { useEffect, useState } from 'react';
import { FetchCurrency } from '../Utils/FetchAPI';
import * as Utils from '../Utils/FilterResponse';
import "../CSS/Table.css"
import { CurrencyList } from '../Constants/Constants';

function Table(props)
{
    const [items, setItems] = useState([]);

    useEffect(() => {
        const currencyChangeRate = async () => {
            const currency = props.currency.toLowerCase();
            const data = await FetchCurrency(currency);
            const dataCurrency = Object.entries(data[currency]);
            const currenctyList = Utils.filterCurrencies(dataCurrency);
            console.log(data[currency]);
            const sortIntoArrays = Utils.ArrayGroups(currenctyList); 
            const convertToArray = Object.values(sortIntoArrays);    
            setItems(convertToArray);
        }

        currencyChangeRate()
        .catch((err) => console.log(err));

    }, [props.currency]);
    
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
            <tr>
            {
                items.map((array, arrayIndex) => {
                    return (
                        <td key = { arrayIndex }>
                            <table className='main-table-column'>
                                <tbody className='main-table-column-body'>
                                    {
                                        array.map((item, itemIndex) => {
                                            return (
                                                <tr key = {itemIndex}>
                                                    <td>{item[0]}: {item[1]}</td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                            {
                                array.length > 0 &&
                                <table className='main-table-column'>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Total items: { array.length }
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            }
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

export default Table;
