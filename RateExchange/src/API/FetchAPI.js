export const fetchCurrencyAPI = (currency, date) => {
    
    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((response) => response.json())
    );
}

export default fetchCurrencyAPI