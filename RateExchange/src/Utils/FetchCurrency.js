import * as Date from "../Utils/Date";
import * as Storage from "../Utils/Storage";

export async function fetchCurrency(endpointOne, endpointTwo, API, storage) {

    let response;
    
    let storageKey = endpointOne + ' ' + endpointTwo;
    if (isDataFetched(endpointOne, endpointTwo, storage)) {

        const storageKeys = Object.keys(storage);
        storageKeys.forEach((element) => {
            if(element.includes(endpointOne)) {
                storageKey = element;
            }
        })
        const storageItem = localStorage.getItem(storageKey);
        response = JSON.parse(storageItem);
    }
    else {

        response = await API(endpointOne, endpointTwo);
        Storage.removeData(endpointOne, localStorage);
        const responseToJson = JSON.stringify(response);
        storage.setItem(storageKey, responseToJson);
    }

    return response;
}

function isDataFetched(endpointOne, endpointTwo, storage) {
    
    let result;
    const currentDate = Date.getCurrentDay();
    const lowerCaseEndpointOne = endpointOne.toLowerCase();
    const currentDateKey = lowerCaseEndpointOne + ' ' + currentDate;
    const currentDateRecord = storage.getItem(currentDateKey);
    const currentRecordKey = lowerCaseEndpointOne + ' ' + endpointTwo;
    const currentRecord = storage.getItem(currentRecordKey);

    if (currentRecord === null) {

        if (currentDateRecord !== null) {
            result = true;
        }

        else {
            result = false;
        }
    }
    else {
        result = true;
    }

    return result;
}

export default fetchCurrency