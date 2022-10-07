import * as FetchAPI from "../API/FetchAPI";
import * as LocalStorage from "../Utils/LocalStorage";
export async function fetchCurrencyLatest(currency) {

    const lowerCaseCurrency = currency.toLowerCase();
    let localStorageItem;
    let response;

    for (let idx = 0; idx < localStorage.length; idx++) {
        const currentKey = localStorage.key(idx);

        if (currentKey.includes(lowerCaseCurrency)) {
            localStorageItem = localStorage.getItem(currentKey);
        }
    }

    if (localStorageItem === undefined) {
        response = await FetchAPI.fetchAPILatest(currency);
        const responseDate = response['date'];
        const responseToJson = JSON.stringify(response);
        const newLocalStorageKey = responseDate + ' ' + lowerCaseCurrency;
        localStorage.setItem(newLocalStorageKey, responseToJson);
    }

    else {
        response = JSON.parse(localStorageItem);
    }

    return response;
}

export async function fetchCurrencyDate(currency, date) {

    const lowerCaseCurrency = currency.toLowerCase();
    const localStorageKey = date + ' ' + lowerCaseCurrency;
    const localStorageItem = localStorage.getItem(localStorageKey);
    let response;

    if (localStorageItem === null) {
        response = await FetchAPI.fetchAPIDate(currency, date);
        LocalStorage.removeAllCurrencyData(currency);
        const responseToJson = JSON.stringify(response);
        localStorage.setItem(localStorageKey, responseToJson);
    }

    else {
        response = JSON.parse(localStorageItem);
    }

    return response;
}

export default fetchCurrencyLatest