
export const FetchCurrency = (URL) => {

    return (
        fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/${URL}.json`)
        .then((res) => res.json())
        .then((res) => Object.entries(res.cad))
    );
}

export default FetchCurrency