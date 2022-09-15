import { useEffect, useState } from 'react';
import { isElement } from 'react-dom/test-utils';
import { FetchCurrency } from '../Utils/FetchAPI';
import * as Utils from '../Utils/FilterResponse';

function Table(URL)
{
    const [items, setItems] = useState([]);

    useEffect(() => {
        const currencyChangeRate = async () => {
            const data = await FetchCurrency('cad');
            const currenctyList = Utils.filterCurrencies(data);
            const sortIntoArrays = Utils.ArrayGroups(currenctyList); 
            const convertToArray = Object.values(sortIntoArrays);    
            console.log(convertToArray);
            setItems(convertToArray);
        }

        currencyChangeRate()
        .catch((err) => console.log(err));

    }, []);
    
    return (    
        <div>
        <table id="table">
          <thead>
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
                            <table>
                                <tbody>
                                    {
                                        array.map((item, itemIndex) => {
                                            return (
                                                <tr key = {itemIndex}>
                                                    <td>{item[0]} : {item[1]}</td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                            {
                                array.length > 0 &&
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            { array.length }
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            }
                        </td>             
                )})
            }
            </tr>
            </tbody>
          </table>
        </div>
    );
}

export default Table;
