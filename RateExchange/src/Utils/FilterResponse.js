import { CurrencyList } from '../Constants/Constants';

export const filterCurrencies = (items) => {
    const FilteredValues = [];

    for(let itemIndex = 0; itemIndex < items.length; itemIndex++)
    {
        const currenctElement = items[itemIndex];
        for(let validCurrenciesIndex = 0; validCurrenciesIndex < CurrencyList.length; validCurrenciesIndex++)
        {
            if(currenctElement[0] === CurrencyList[validCurrenciesIndex].toLowerCase())
            {
                FilteredValues.push(currenctElement);
            }
        }
    }

    return (
        FilteredValues
    );
}

export const ArrayGroups = (items) => {
    const tableColumns = {
        firstColumnArray: [],
        secondColumnArray: [],
        thirdColumnArray: []
    }

    for(let index = 0; index < items.length; index++)
    {
        const result = determineGroup(items[index]);
        if(result === 'First Column')
        {
            tableColumns.firstColumnArray.push(items[index]);
        }
        else if(result === 'Second Column')
        {
            tableColumns.secondColumnArray.push(items[index]);
        }
        else if(result === 'Third Column')
        {
            tableColumns.thirdColumnArray.push(items[index]);
        }
    }

    return (
        tableColumns
    );
}

const determineGroup = (item) => {
    const value = item[1];
    let result;

    if(value < 1)
    {
        result =  'First Column';
    }

    else if(value > 1 && value < Number(1,5))
    {
        result =  'Second Column';
    }

    else if(value > Number(1,5))
    {
        result =  'Third Column';
    }

    return (
        result
    );
}

export const findColumnsLengths = (tableColumns) => {

    const result = Object.entries(tableColumns)
    .map((column, columnIndex) => column.length);

    return (
        result    
    );
}