
export const FetchCurrency = (URL) => {

    const response = {
        items: {},
        currency: URL,
    };

    fetch(`https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/${response.currency}.json`)
    .then((res) => res.json())
    .then((res) => {
        response['items'] = res.eur;
    })
    .catch((err) => console.log(err));
    
    return (
        response
    );

}

export default FetchCurrency