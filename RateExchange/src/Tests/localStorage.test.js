import * as LocalStorage from "../Utils/LocalStorage";
import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";
import "jest-localstorage-mock"

//providing mock local storage implementaion 

beforeEach(() => {
})

it("Removes old currency data for specified currency", () => {  

  //arrange
  const currncyName = 'usd';
  const date = "2022-01-14";
  const localStorageOldKey = date + ' ' + currncyName;

  localStorage.setItem(localStorageOldKey, "usd 1.78987");

  //act
  LocalStorage.removeCurrencyData(currncyName);

  const relustStorage = Object.keys(localStorage);

  //assert
  expect(localStorage.setItem).toHaveBeenLastCalledWith(localStorageOldKey, "usd 12.20.2022");
  expect(relustStorage).toEqual(expectedLocalStorage);
});

it("Checks if all currencies from currencies list are in localStorage", () => {

  //arrange
  const result = true;
  const currentDate = getCurrentDay();
  const { currencyList } = Constants;

  for (let idx = 0; idx < currencyList.length; idx++)
  {
    const currentCurrency = Constants.currencyList[idx].toLowerCase();
    const localStorageOldKey = currentDate + ' ' + currentCurrency;
    localStorage.setItem(localStorageOldKey, "test data");
  }

  //act and assert
  expect(LocalStorage.areCurrenciesUpdated()).toEqual(result);
});

it("Gets currency from storage", () => {

  //arrange
  const requestedCurrency = 'cad';
  const currentDate = getCurrentDay();
  const expecedKey = currentDate + ' ' + requestedCurrency;
  const data =  [['cad', 0.078786], ['azn', 1.696762]];

  for(let idx = 0; idx < data.length; idx++)
  {
    const currentCurrency = data[idx][0];
    const currenctElement = JSON.stringify(data[idx]);
    const localStorageKey = currentDate + ' ' + currentCurrency;

    localStorage.setItem(localStorageKey, currenctElement);
  }

  const expecedCurrency = JSON.parse(localStorage.getItem(expecedKey));

  //act
  const getCurrency = LocalStorage.getCurrency(requestedCurrency);

  //assert
  expect(getCurrency).toEqual(expecedCurrency);
})
