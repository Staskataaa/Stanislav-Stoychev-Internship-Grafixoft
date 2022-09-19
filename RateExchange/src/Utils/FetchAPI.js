
export const FetchCurrency = (currency, date) => {

    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/${date}/currencies/${currency}.json`)
        .then((res) => res.json())
    );
}

export default FetchCurrency