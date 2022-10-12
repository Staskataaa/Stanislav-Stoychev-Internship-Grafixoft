import * as Constants from "../Constants";

export const fetchAPI = (currency, date) => {
    
    if (date === undefined) {
        date = Constants.latest;
    }

    if (currency === undefined || currency === null) {
        currency = Constants.defaultCurrency;
    }   
    
    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((response) => response.json())
    );
}

export default fetchAPI