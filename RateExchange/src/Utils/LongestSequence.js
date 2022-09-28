import * as LocalStorageFilter from "./LocalStorage"
import * as FilterResponse from "./FilterResponse"

export const FilterUniqueValues = (array) => {
    return (
        array.filter((value, index, array) => array.indexOf(value) === index)
    );
}

export const SortValues = (array) => {
    return(
        array.sort((a, b) => a - b)
    )
}

export const FindLongestSequesnce = (array) => {

    const maximumDifference = 0.5;
    let maxSequence = 0;

    for(let currentItemIndex = 0; currentItemIndex < array.length; currentItemIndex++)
    {
        let currenctSequence = 0;

        for(let nextItemIndex = currentItemIndex + 1; nextItemIndex < array.length; nextItemIndex++)
        {
            if(array[currentItemIndex] + maximumDifference >= array[nextItemIndex])
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
    const sorted = SortValues(array);
    return sorted;
}

export const longestSequence = (currency) => {
    const check = LocalStorageFilter.CheckIfAllCurrenciesAreUpdated();
    let longestSequence = null;
    
    if(check === true)
    {
        const getData = LocalStorageFilter.getDataForCurrency(currency);
        const sortedList = FilterResponse.SortKeyValues(getData, currency); 
        const getDataForCurrencyObject = Object.fromEntries(sortedList);
        const getValuesForCurrency = Object.values(getDataForCurrencyObject);
        const getInverseValues = getAllValues(getValuesForCurrency);
        const longestSequence = FindLongestSequesnce(getInverseValues);
        return longestSequence;
    }
    
    return longestSequence;
}

export default longestSequence