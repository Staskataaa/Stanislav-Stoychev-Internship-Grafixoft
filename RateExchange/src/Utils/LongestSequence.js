import * as LocalStorage from "./LocalStorage"
import * as CurrencyFilter from "../Utils/CurrencyFilters"

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
        let currenctSequence = 1;

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

    inverseArray.forEach((value) => array.push(value));
    
    const sorted = sortValues(array);
    return sorted;
}

export const longestSequence = (currency) => {

    let longestSequence = null;

    const check = LocalStorage.AreCurrenciesUpdated();

    if(check === true)
    {
        const getData = LocalStorage.getCurrency(currency);
        const sortData = CurrencyFilter.sortKeyValues(getData, currency); 
        const getDataObject = Object.fromEntries(sortData);
        const values = Object.values(getDataObject);
        const allValues = getAllValues(values);
        const longestSequence = findLongestSequesnce(allValues);
        return longestSequence;
    }
    
    return longestSequence;
}

export default longestSequence