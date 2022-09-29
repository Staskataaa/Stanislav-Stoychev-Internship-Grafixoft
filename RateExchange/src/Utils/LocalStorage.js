import * as Constants from "../Constants";

export const removeOldData = (currencyName) => {

    for(let index = 0; index < localStorage.length; index++)
    {
        const currenctKey = localStorage.key(index);

        if(currenctKey.includes(currencyName.toLowerCase()))
        {
            localStorage.removeItem(currenctKey);
            break;
        }
    }
}

export const AreCurrenciesUpdated = () => {

    let result = true;

    for(let currencyIdx = 0; currencyIdx < Constants.currencyList.length; currencyIdx++)
    {
        const currentCurrency = Constants.currencyList[currencyIdx].toLowerCase();
        let isCurrencyUpdated = false;

        for(let keyIdx = 0; keyIdx < localStorage.length; keyIdx++)
        {
            const currenctKey = localStorage.key(keyIdx);

            if(currenctKey.includes(currentCurrency) && 
            currenctKey.includes(Constants.currentDate))
            {
                isCurrencyUpdated = true;
                break;
            }
        }

        if(isCurrencyUpdated === false)
        {
            result = false;
            break;
        }
    }

    return result;
}

export const getCurrencyFromStorage = (currency) => {

    let result;
    const lowerCaseCurrency = currency.toLowerCase();

    for(let idx = 0; idx < localStorage.length; idx++)
    {

        const currenctKey = localStorage.key(idx);

        if(currenctKey.includes(lowerCaseCurrency))
        {
            result = JSON.parse(localStorage.getItem(currenctKey));
            break;        
        } 
    }
    
    return result;
}

export default getCurrencyFromStorage