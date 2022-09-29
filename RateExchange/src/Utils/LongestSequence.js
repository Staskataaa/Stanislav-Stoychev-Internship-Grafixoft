import * as LocalStorageFilter from "./LocalStorage"
import * as FilterResponse from "./CurrencyFilters"

export const filterUniqueValues = (array) => {
    return (
        array.filter((value, index, array) => array.indexOf(value) === index)
    );
}

export const sortValues = (array) => {
    return(
        array.sort((a, b) => a - b)
    )
}

export const findLongestSequesnce = (array) => {

    const maximumDifference = 0.5;
    let maxSequence = 0;

    for(let valueIdx = 0; valueIdx < array.length; valueIdx++)
    {
        let currenctSequence = 0;

        for(let nextValueIdx = valueIdx + 1; nextValueIdx < array.length; nextValueIdx++)
        {
            if(array[valueIdx] + maximumDifference >= array[nextValueIdx])
            {
                currenctSequence++;
            }

            else
            {
                break;
            }
        }

        if(currenctSequence >= maxSequence)
        {
            maxSequence = currenctSequence;
        }
    }

    return maxSequence;
}

export const getAllValues = (array) => {

    const inverseArray = [];

    for(let index = 0; index < array.length; index++)
    {    
        const inverseValue = 1 / array[index];
        inverseArray.push(inverseValue);
    }

    array.push(inverseArray);
    
    const sorted = sortValues(array);
    return sorted;
}

export const longestSequence = (currency) => {

    let longestSequence = null;

    const check = LocalStorageFilter.AreCurrenciesUpdated();

    if(check === true)
    {
        const getData = LocalStorageFilter.getCurrencyFromStorage(currency);
        const sortData = FilterResponse.sortKeyValues(getData, currency); 
        const getDataObject = Object.fromEntries(sortData);
        const values = Object.values(getDataObject);
        const allValues = getAllValues(values);
        const longestSequence = findLongestSequesnce(allValues);
        return longestSequence;
    }
    
    return longestSequence;
}

export default longestSequence