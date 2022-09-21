export const CurrencyList = ['USD', 'EUR', 'AUD', 'CAD', 'CHF', 'NZD', 'BGN'];
export const DefaultCurrency = 'USD';

export const ColumnCount = 3;

export const date = new Date();
export const getDay = date.getDate();
export const getMonth = String(date.getMonth() + 1).padStart(2, '0') ;
export const getYear = date.getFullYear();
export const currentDate = +getYear+'-'+getMonth+'-'+getDay;
