import * as Constants from '../Constants';

export const getSpecifiedCurrencies = (fetchedCurrencyArray) => {

    return fetchedCurrencyArray.filter((currency) => isCurrencyValid(currency));
}

const isCurrencyValid = (currency) => {

    const [ currencyName, currencyValue ] = currency
    const { currencyList } = Constants;
    let result = false;
   
    currencyList.forEach(element => {
        const lowerCaseCurrency = element.toLowerCase();
        if (lowerCaseCurrency === currencyName
            && currencyValue !== 1) {
            result = true;
        }
    });

    return result;
}

export const sortCurrencyArray = (currencyArray) => { 

    const currencyValueIndex = Constants.value;

    return currencyArray.sort((currency, nextCurrency) => 
    currency[currencyValueIndex] - nextCurrency[currencyValueIndex]);
} 

export const sortIntoColumns = (currencies) => {

    const tableColumns = [[], [], []];

    currencies.forEach((element) => {
        const columnIndex = determineColumn(element);
        tableColumns[columnIndex].push(element);
    })
    return tableColumns;
}

export const determineColumn = (keyValueItem) => {

    const value = keyValueItem[Constants.value];
    
    let result;

    switch(true) {
        
        case (Number(value) < Number(1)): {
            result = 0;
            break;
        }
        case (Number(value) > Number(1) && Number(value) < Number(1.5)): {
            result = 1
            break;
        }
        case (Number(value) > Number(1.5)): {
            result = 2;
            break;
        }
    }

    return result;
}

const findColumnsLengths = (tableColumnsArray) => {

    return tableColumnsArray.map((column) => column.length);
}

export const convertToRows = (columnsArray) => {

    const result = [];
    const columnLengthsArray = findColumnsLengths(columnsArray);
    const rowsSize = Math.max(...columnLengthsArray);
    const colsSize = columnLengthsArray.length;

    for(let row = 0; row < rowsSize; row++)
    {
        const rowArray = Array.apply(undefined, Array(colsSize));

        for(let col = 0; col < colsSize; col++)
        {
            const currentItem = columnsArray[col][row];

            if (currentItem) {
                const determinePosition = determineColumn(currentItem);
                rowArray[determinePosition] = currentItem;
            }          
        }

        result.push(rowArray);
    }

    return result;
}

export const sortKeyValues = (response) => {

    const dataCurrency = Object.entries(response);
    const currenctyList = getSpecifiedCurrencies(dataCurrency);
    const sortedCurrenctyList = sortCurrencyArray(currenctyList);

    return sortedCurrenctyList;
}

export const applyFilters = (response) => {

    const sortedList = sortKeyValues(response);
    const sortIntoCols = sortIntoColumns(sortedList);  

    return sortIntoCols;
}
