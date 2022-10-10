import * as Constants from '../Constants';


export const getSpecifiedCurrencies = (array) => {

    const specifiedCurrencies = [];

    for(let arrayIdx = 0; arrayIdx < array.length; arrayIdx++)
    {
        const currenctElement = array[arrayIdx];

        for(let currencyListIdx = 0; currencyListIdx < Constants.currencyList.length; currencyListIdx++)
        {
            const currentCurrency = Constants.currencyList[currencyListIdx].toLowerCase();

            if(currenctElement[Constants.key] === currentCurrency && currenctElement[Constants.value] !== 1)
            {
                specifiedCurrencies.push(currenctElement);
            }
        }
    }

    return specifiedCurrencies; 
}

export const sortCurrencyArray = (currencyArray) => { 

    return (
        currencyArray.sort((a, b) => a[1] - b[1])
    )
} 

export const sortIntoColumns = (currencies) => {

    const tableColumns = [[], [], []];

    for(let currencyIdx = 0; currencyIdx < currencies.length; currencyIdx++)
    {
        const currentItem = currencies[currencyIdx];

        const result = determineColumn(currentItem);

        if(result === 'First Column')
        {
            tableColumns[Constants.firstColumnIndex].push(currentItem);
        }

        else if(result === 'Second Column')
        {
            tableColumns[Constants.secondColumnIndex].push(currentItem);
        }
        
        else if(result === 'Third Column')
        {
            tableColumns[Constants.thirdColumnIndex].push(currentItem);
        }
    }

    return tableColumns;
}

export const determineColumn = (keyValueItem) => {

    const value = keyValueItem[Constants.value];
    
    let result;

    if(Number(value) < Number(1))
    {
        result = Constants.firstColumn;
    }

    else if(Number(value) > Number(1) && Number(value) < Number(1.5))
    {
        result = Constants.secondColumn;
    }

    else if(Number(value) >  Number(1.5))
    {
        result =  Constants.thirdColumn;
    }

    return result;
}

const findColumnsLengths = (tableColumnsArray) => {

    const lengths = tableColumnsArray.map((column) => column.length);

    return lengths;
}

export const convertToRows = (columnsArray) => {

    const result = [];
    const rowsSize = Math.max(...findColumnsLengths(columnsArray));
    const colsSize = Constants.columnCount;

    for(let row = 0; row < rowsSize; row++)
    {
        const rowArray = Array.apply(null, Array(colsSize));

        for(let col = 0; col < colsSize; col++)
        {
            const currentItem = columnsArray[col][row];

            if(currentItem !== undefined)
            {
                const determinePosition = determineColumn(currentItem);

                if(determinePosition === Constants.firstColumn)
                {
                    rowArray[Constants.firstColumnIndex] = currentItem;
                }

                else if(determinePosition === Constants.secondColumn)
                {
                    rowArray[Constants.secondColumnIndex] = currentItem;
                }

                else if(determinePosition === Constants.thirdColumn)
                {
                    rowArray[Constants.thirdColumnIndex] = currentItem;
                }
            }          
        }

        result.push(rowArray);
    }

    return result;
}

export const sortKeyValues = (response) => {

    const currency = Object.keys(response)[Constants.value];
    const dataCurrency = Object.entries(response[currency]);
    const currenctyList = getSpecifiedCurrencies(dataCurrency);
    const sortedCurrenctyList = sortCurrencyArray(currenctyList);

    return sortedCurrenctyList;
}

export const applyFilters = (response) => {

    const sortedList = sortKeyValues(response);
    const sortIntoCols = sortIntoColumns(sortedList);  

    return sortIntoCols;
}
