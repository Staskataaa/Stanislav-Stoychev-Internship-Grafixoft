
export const FetchCurrency = (currency, date) => {

    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((res) => res.json())
    );
}


export async function FetchCurrencyIfNotInLocalStorage(currency, date) {
    const localStorageKey = date + ' ' + currency;
    let response;
            
    if(localStorage.getItem(localStorageKey) === null)
    {   
        response = await FetchCurrency(currency, date);
        localStorage.setItem(localStorageKey, JSON.stringify(response));
    }
    else
    {
        response = JSON.parse(localStorage.getItem(localStorageKey));
    }

    return response;
}

export default FetchCurrency