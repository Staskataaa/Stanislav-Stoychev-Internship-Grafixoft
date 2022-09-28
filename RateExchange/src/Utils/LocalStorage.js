import * as Constants from "../Constants/Constants";
import * as FilterResponse from "../Utils/FilterResponse";

export const FilterLocalStotage = (currencyName) => {

    for(let index = 0; index < localStorage.length; index++)
    {
        const currenctKey = localStorage.key(index);
        if(currenctKey.includes(currencyName.toLowerCase()))
        {
            localStorage.removeItem(currenctKey);
        }
    }
}

export const CheckIfAllCurrenciesAreUpdated = () => {

    let result = true;

    for(let currencyIndex = 0; currencyIndex < Constants.CurrencyList.length; currencyIndex++)
    {
        const currentCurrency = Constants.CurrencyList[currencyIndex].toLowerCase();
        let currentCurrencyResult = false;

        for(let keyIndex = 0; keyIndex < localStorage.length; keyIndex++)
        {
            const currenctItem = localStorage.key(keyIndex);

            if(currenctItem.includes(currentCurrency) && currenctItem.includes(Constants.currentDate))
            {
                currentCurrencyResult = true;
                break;
            }
        }

        if(currentCurrencyResult === false)
        {
            result = false;
            break;
        }
    }

    return result;
}

export const getDataForCurrency = (currency) => {

    let result;
    const lowerCaseCurrency = currency.toLowerCase();

    for(let index = 0; index < localStorage.length; index++)
    {

        const currenctKey = localStorage.key(index);

        if(currenctKey.includes(lowerCaseCurrency))
        {

            result = JSON.parse(localStorage.getItem(currenctKey));
            break;        
        } 
    }
    
    return result;
}

export const getAllChangeRates = (currency) => {

    const currencyData = getDataForCurrency(currency);
}

export const FillAllChangeRatesFromStorage = () => {

    const allChangeRates = [];

    for(let index = 0; index < Constants.CurrencyList.length; index++)
    {
        const currentKey = localStorage.key(index);
        const currenctValue = JSON.parse(localStorage.getItem(currentKey));
        const currency = currentKey.split(' ')[1];
        const dataCurrency = Object.entries(currenctValue[currency]);
        const currenctyList = FilterResponse.filterCurrencies(dataCurrency);
        const sortedList = FilterResponse.sortCurrencies(currenctyList);
        const sortedListToObject = Object.fromEntries(sortedList);
        const values = Object.values(sortedListToObject);
        allChangeRates.push(...values);
    }

    return allChangeRates;
} 

export default FilterLocalStotage