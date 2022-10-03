import { components } from "react-select";
import * as Constants from "../Constants";

export const fetchAPILatest = (currency) => {
    
    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/${currency}.json`)
        .then((response) => response.json())
    );
}

export const fetchAPIDate = (currency, date) => {
    
    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((response) => response.json())
    );
}

export async function fetchCurrencyLatest(currency) {

    const lowerCaseCurrency = currency.toLowerCase();
    let localStorageItem;
    let localStorageKey;
    let response;

    for(let idx = 0; idx < localStorage.length; idx++)
    {
        const currentKey = localStorage.key(idx);

        if(currentKey.includes(lowerCaseCurrency))
        {
            localStorageItem = localStorage.getItem(currentKey);
            localStorageKey = currentKey;
        }
    }

    if(localStorageItem === undefined)
    {
        response = await fetchAPILatest(currency);
        const responseDate = response['date'];
        const responseToJson = JSON.stringify(response);
        const newLocalStorageKey = responseDate + ' ' + lowerCaseCurrency;
        localStorage.setItem(newLocalStorageKey, responseToJson);
    }

    else
    {   
        response = JSON.parse(localStorageItem);
    }

    return response;
}

export async function fetchCurrencyDate(currency, date) {

    const lowerCaseCurrency = currency.toLowerCase();
    const localStorageKey = date + ' ' + lowerCaseCurrency;
    const localStorageItem = localStorage.getItem(localStorageKey);
    let response;

    if(localStorageItem === null)
    {
        response = await fetchCurrencyDate(currency, date);
        const responseToJson = JSON.stringify(response);
        localStorage.setItem(localStorageKey, responseToJson);
    } 

    else
    {
        response = JSON.parse(localStorageItem);
    }

    return response;
}

export default fetchCurrencyLatest