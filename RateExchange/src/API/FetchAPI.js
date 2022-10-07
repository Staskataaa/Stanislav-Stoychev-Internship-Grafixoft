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

export default fetchAPILatest