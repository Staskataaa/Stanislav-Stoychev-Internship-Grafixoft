import * as Constants from '../Constants/Constants';

export const filterCurrencies = (items) => {
    const FilteredValues = [];

    for(let itemIndex = 0; itemIndex < items.length; itemIndex++)
    {
        const currenctElement = items[itemIndex];
        for(let validCurrenciesIndex = 0; validCurrenciesIndex < Constants.CurrencyList.length; validCurrenciesIndex++)
        {
            if(currenctElement[0] === Constants.CurrencyList[validCurrenciesIndex].toLowerCase())
            {
                FilteredValues.push(currenctElement);
            }
        }
    }

    return (
        FilteredValues
    );
}

export const sortCurrencies = (items) => { 
    return (
        items.sort((a, b) => a[1] - b[1])
    )
} 

export const ArrayGroups = (items) => {
    const tableColumns = {
        firstColumnArray: [],
        secondColumnArray: [],
        thirdColumnArray: []
    }

    for(let index = 0; index < items.length; index++)
    {
        const currentItem = items[index];
        const result = determineGroup(currentItem);
        if(result === 'First Column')
        {
            tableColumns.firstColumnArray.push(currentItem);
        }
        else if(result === 'Second Column')
        {
            tableColumns.secondColumnArray.push(currentItem);
        }
        else if(result === 'Third Column')
        {
            tableColumns.thirdColumnArray.push(currentItem);
        }
    }

    return (
        tableColumns
    );
}

const determineGroup = (item) => {
    const value = item[1];
    let result;

    if(Number(value) < Number(1))
    {
        result =  'First Column';
    }

    if(Number(value) >= Number(1) && Number(value) < Number(1.5))
    {
        result = 'Second Column';
    }

    else if(Number(value) >  Number(1.5))
    {
        result =  'Third Column';
    }

    return (
        result
    );
}

export const findColumnsLengths = (tableColumns) => {

    const result = tableColumns
    .map((column, columnIndex) => column.length);

    return (
        result    
    );
}

export const convertToTableFormat = (items) => {

    const result = [];
    const rowsSize = Math.max(...findColumnsLengths(items));
    const colsSize = Constants.ColumnCount;

    for(let rows = 0; rows < rowsSize; rows++)
    {
        const arrayRow = Array.apply(null, Array(colsSize));
        for(let cols = 0; cols < colsSize; cols++)
        {
            const currentItem = items[cols][rows];
            if(currentItem !== undefined)
            {
                const determinePosition = determineGroup(currentItem);
                if(determinePosition === 'First Column')
                {
                    arrayRow[0] = currentItem;
                }
                if(determinePosition === 'Second Column')
                {
                    arrayRow[1] = currentItem;
                }
                if(determinePosition === 'Third Column')
                {
                    arrayRow[2] = currentItem;
                }
            }          
        }
        result.push(arrayRow);
    }

    return result;
}
