import { fetchAPI } from "../API/FetchAPI";
import * as LocalStorage from "../Utils/LocalStorage";
import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";

export async function fetchCurrency(currency, date) {

    const currentDate = getCurrentDay();
    const lowerCaseCurrency = currency.toLowerCase();
    const currentDateKey = currentDate + ' ' + lowerCaseCurrency;
    const currentDateRecord = localStorage.getItem(currentDateKey);
    let response;

    if (date === undefined) {
        date = Constants.latest;
    }

    const currentRecordKey = date + ' ' + lowerCaseCurrency;  
    const currentRecord = localStorage.getItem(currentRecordKey);
    

    if (currentRecord === null) {

        if (currentDateRecord !== null) {
            response = JSON.parse(currentDateRecord);
        }

        else {
            response = await fetchAPI(currency, date);
            LocalStorage.removeCurrencyData(currency);
            const responseToJson = JSON.stringify(response);
            localStorage.setItem(currentRecordKey, responseToJson);
        }
    }
    else {
        response = JSON.parse(currentRecord);
    }

    return response;

}

export default fetchCurrency