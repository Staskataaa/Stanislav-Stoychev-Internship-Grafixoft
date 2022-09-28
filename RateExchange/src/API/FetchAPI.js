
export const FetchCurrencyFromAPI = (currency, date) => {

    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((res) => res.json())
    );
}

export async function FetchCurrency(currency, date) {
    currency = currency.toLowerCase();
    const localStorageKey = date + ' ' + currency;
    let response;
    const itemInStorage = localStorage.getItem(localStorageKey);
    if(itemInStorage === null)
    {   
        response = await FetchCurrencyFromAPI(currency, date);
        localStorage.setItem(localStorageKey, response);
    }
    else
    {
        response = JSON.parse(itemInStorage);
    }

    return response;
}

export default FetchCurrency