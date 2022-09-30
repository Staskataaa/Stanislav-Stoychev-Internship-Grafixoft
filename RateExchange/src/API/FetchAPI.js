import * as Constants from "../Constants";

export const fetchAPI = (currency) => {

    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/${currency}.json`)
        .then((response) => response.json())
    );
}

export async function fetchCurrency(currency) {

    const lowerCaseCurrency = currency.toLowerCase();
    const localStorageKey = Constants.currentDate + ' ' + lowerCaseCurrency;
    const itemInStorage = localStorage.getItem(localStorageKey);
    
    let response;
    
    if(itemInStorage !== null)
    {   
        response = JSON.parse(itemInStorage);
    }
    else
    {

        response = await fetchAPI(currency);
        localStorage.setItem(localStorageKey, response);
    }

    return response;
}

export default fetchCurrency