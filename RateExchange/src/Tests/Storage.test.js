import * as Storage from "../Utils/Storage";
import * as Constants from "../Constants";
import { getCurrentDay } from "../Utils/Date";

beforeEach(() => {
  localStorage.clear();
})

it("Removes old currency data for specified currency", () => {  

  //arrange
  const currncyName = 'usd';
  const date = "2022-01-14";
  const localStorageOldKey = date + ' ' + currncyName;
  const expectedLocalStorage = [];

  localStorage.setItem(localStorageOldKey, "usd 1.78987");

  //act
  Storage.removeData(currncyName, localStorage);

  //assert
  expect(Object.keys(localStorage)).toEqual(expectedLocalStorage);
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
  expect(Storage.areCurrenciesUpdated(localStorage)).toEqual(result);
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
  const getCurrency = Storage.getCurrency(requestedCurrency, localStorage);

  //assert
  expect(getCurrency).toEqual(expecedCurrency);
})
