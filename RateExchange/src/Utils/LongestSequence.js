import * as LocalStorage from "./LocalStorage"
import * as CurrencyFilter from "../Utils/CurrencyFilters"
import * as Constants from "../Constants";

export const sortValues = (array) => {

    return(
        array.sort((a, b) => a - b)
    )
}

export const findLongestSequesnce = (array) => {

    const { maximumDifference } = Constants;
    let maxSequence = 0;

    for(let valueIdx = 0; valueIdx < array.length; valueIdx++)
    {
        let currenctSequence = 1;

        for(let nextValueIdx = valueIdx + 1; nextValueIdx < array.length; nextValueIdx++)
        {   
            const check = array[valueIdx];
            if (array[valueIdx] + maximumDifference >= array[nextValueIdx]) {
                currenctSequence++;
            }
        }

        if (currenctSequence >= maxSequence) {
            maxSequence = currenctSequence;
        }
    }

    return maxSequence;
}

export const getAllValues = (array) => {

    const inverseArray = [];

    array.forEach((value, index) => {
        const inverseValue = 1 / value;
        inverseArray.push(inverseValue);
    });

    inverseArray.forEach((value) => array.push(value));
    
    const sorted = sortValues(array);
    return sorted;
}

export const longestSequence = (currency) => {

    let longestSequence = null;

    const check = LocalStorage.areCurrenciesUpdated();

    if (check === true) {
        
        const getData = LocalStorage.getCurrency(currency);
        const sortData = CurrencyFilter.sortKeyValues(getData[currency], currency); 
        const getDataObject = Object.fromEntries(sortData);
        const getInverseValues = getAllValues(Object.values(getDataObject));
        const longestSequence = findLongestSequesnce(getInverseValues);
        return longestSequence;
    }
    
    return longestSequence;
}

export default longestSequence