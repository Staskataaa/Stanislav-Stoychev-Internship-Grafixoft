import * as LocalStorageFilter from "../Utils/LocalStorageFilter"

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

export const longestSequence = () => {
    const check = LocalStorageFilter.CheckIfAllCurrenciesAreUpdated();
    let longestSequence = null;
    
    if(check === true)
    {
        const allValues = LocalStorageFilter.FillAllChangeRatesFromStorage();
        const uniqueValues = FilterUniqueValues(allValues);
        const sortedValues = SortValues(uniqueValues);
        longestSequence = FindLongestSequesnce(sortedValues);
        return longestSequence;
    }
    
    return longestSequence;
}

export default longestSequence