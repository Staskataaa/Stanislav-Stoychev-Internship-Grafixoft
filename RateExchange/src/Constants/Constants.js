export const CurrencyList = ['USD', 'EUR', 'AUD', 'CAD', 'CHF', 'NZD', 'BGN'];
export const DefaultCurrency = 'USD';

export const columns = [
    {
        Header: 'Conversion rates below 1',
        accessor: 'value'
    },
    {
        Header: 'Conversion rates bewtween 1 and 1,5',
        accessor: 'value'
    },
    {
        Header: 'Conversion rates above 1,5',
        accessor: 'value'
    }
];