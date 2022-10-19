import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";

export const removeData = (name, storage) => {

    const localStorageKeys = Object.keys(localStorage);

    localStorageKeys.forEach((item) => {

        if (item.includes(name.toLowerCase())) {
            storage.removeItem(item);
        }
    });
}

export const areCurrenciesUpdated = (storage) => {

    let result = true;
    const { currencyList } = Constants;
   
    const currencyListKeys = Object.keys(storage);
    const currentDate = getCurrentDay();

    currencyList.forEach((element) => {
        const expectedKey = currentDate + ' ' + element.toLowerCase();
        if(!currencyListKeys.includes(expectedKey)) {
            result = false;
        }
    })

    return result;
}

export const getCurrency = (currency, storage) => {

    let result;
    const lowerCaseCurrency = currency.toLowerCase();
    const localStorageKeys = Object.keys(storage);
    
    localStorageKeys.forEach((key) => {
        if (key.includes(lowerCaseCurrency)) {
            result = JSON.parse(storage.getItem(key));
        }
    });

    return result;
}

export default getCurrency