import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";

export const removeCurrencyData = (currency) => {

    const localStorageKeys = Object.keys(localStorage);

    localStorageKeys.forEach((item) => {

        if (item.includes(currency.toLowerCase())) {
            localStorage.removeItem(item);
        }
    });
}

export const areCurrenciesUpdated = () => {

    let result = true;
    const { currencyList } = Constants;
    const currencyListKeys = Object.keys(localStorage);
    const currentDate = getCurrentDay();

    currencyList.forEach((element) => {
        const expectedKey = currentDate + ' ' + element.toLowerCase();
        if(!currencyListKeys.includes(expectedKey)) {
            result = false;
        }
    })

    return result;
}

export const getCurrency = (currency) => {

    let result;
    const lowerCaseCurrency = currency.toLowerCase();
    const localStorageKeys = Object.keys(localStorage);
    
    localStorageKeys.forEach((key) => {
        if (key.includes(lowerCaseCurrency)) {
            result = JSON.parse(localStorage.getItem(key));
        }
    });

    return result;
}

export default getCurrency