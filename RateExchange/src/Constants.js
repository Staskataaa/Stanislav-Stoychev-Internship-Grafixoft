export const currencyList = ['USD', 'EUR', 'AUD', 'CAD', 'CHF', 'NZD', 'BGN'];

export const defaultCurrency = 'USD';

export const date = new Date();
export const getDay = String(date.getDate()).padStart(2, '0');
export const getMonth = String(date.getMonth() + 1).padStart(2, '0') ;
export const getYear = date.getFullYear();
export const currentDate = getYear + '-' + getMonth + '-' + getDay;

export const columnCount = 3;
export const firstColumn = 'First Column';
export const secondColumn = 'Second Column';
export const thirdColumn = 'Third Column';

export const firstColumnIndex = 0;
export const secondColumnIndex = 1;
export const thirdColumnIndex = 2;

export const key = 0;
export const value = 1;

export const dateString = 'date';
