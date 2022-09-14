import { CurrencyList } from '../Constants/Constants';

export const filterToDefaultValues = (items) => {
    const FilteredValues = [];
    for(let itemIndex = 0; itemIndex < items.length; itemIndex++)
    {
        const currenctElement = items.currency[0];
        for(let constIndex = 0; constIndex < CurrencyList.length; constIndex)
        {
            if(currenctElement[0] === CurrencyList[constIndex])
            {
                FilteredValues.push(currenctElement);
            }
        }
    }

    return (
        FilteredValues
    );
}

export const ArrayGroups = (item) => {
    const tableColumns = {
        firstColumnArray: [],
        secondColumnArray: [],
        thirdColumnArray: []
    }

    const result = determineGroup(item);
    if(result === 'First Column')
    {
        tableColumns.firstColumnArray.push(item);
    }
    else if(result === 'Second Column')
    {
        tableColumns.firstColumnArray.push(item);
    }
    else if(result === 'Third Column')
    {
        tableColumns.firstColumnArray.push(item);
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