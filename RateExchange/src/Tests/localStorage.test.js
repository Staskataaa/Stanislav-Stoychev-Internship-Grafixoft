import * as LocalStorage from "../Utils/LocalStorage"
import * as Constants from "../Constants";

const localStorageMock = (function () {

  let localStorage = {};

  return {
    getItem(key) {
      return localStorage[key];
    },

    setItem(key, value) {
      localStorage[key] = value;
    },

    clear() {
      localStorage = {};
    },

    removeItem(key) {
      delete localStorage[key];
    },

    getAll() {
      return localStorage;
    },
    
    key: function(value) {
      const keys = Object.keys(localStorage);
      return keys[value] || null;
    },

    get length() {
      return Object.keys(localStorage).length;
    }
  };
})();

beforeEach(() => {

  Object.defineProperty(window, "localStorage",  { value: localStorageMock });
  window.localStorage.clear();
})

it("Removes old currency data for specified currency", () => {  

  const currncyName = 'usd';
  const date = "2022-01-14";
  const localStorageOldKey = date + ' ' + currncyName;
  localStorage.setItem(localStorageOldKey, "usd 12.20.2022");
  const expectedLocalStorage = {};

  LocalStorage.removeAllCurrencyData(currncyName);

  expect(localStorage.getAll()).toEqual(expectedLocalStorage);
});

it("Checks if all currencies from currencies list are in localStorage", () => {

  const result = true;

  for(let idx = 0; idx < Constants.currencyList.length; idx++)
  {

    const currentCurrency = Constants.currencyList[idx].toLowerCase();
    const localStorageOldKey = Constants.currentDate + ' ' + currentCurrency;
    localStorage.setItem(localStorageOldKey, "test data");

  }

  const array = localStorage.getAll();

  expect(LocalStorage.AreCurrenciesUpdated()).toEqual(result);
});

it("Gets currency from storage", () => {

  const requestedCurrency = 'cad';
  const expecedKey = Constants.currentDate + ' ' + requestedCurrency;
  const data =  [['cad', 0.078786], ['azn', 1.696762]];

  for(let idx = 0; idx < data.length; idx++)
  {
    const currentCurrency = data[idx][0];
    const currenctElement = JSON.stringify(data[idx]);
    const localStorageKey = Constants.currentDate + ' ' + currentCurrency;

    localStorage.setItem(localStorageKey, currenctElement);

  }

  const expecedCurrency = JSON.parse(localStorage.getItem(expecedKey));
  const getCurrency = LocalStorage.getCurrency(requestedCurrency);

  expect(getCurrency).toEqual(expecedCurrency);
})
