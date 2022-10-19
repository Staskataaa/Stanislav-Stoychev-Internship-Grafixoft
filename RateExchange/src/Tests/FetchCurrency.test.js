import * as FetchCurrency from "../Utils/FetchCurrency";
import * as  FetchAPI from "../API/FetchAPI";
import * as GetDate from "../Utils/Date";

beforeEach(() => {

    FetchAPI.fetchCurrencyAPI = jest.fn().mockResolvedValue({
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    });

    GetDate.getCurrentDay = jest.fn().mockReturnValue("2021-11-19");

    window.localStorage.clear();
})

it("fetches data for specified date and currency and saves it to local Storage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19",
    FetchAPI.fetchCurrencyAPI, localStorage);

    const localStorageCurrencyRecord = localStorage.getItem("usd" + " " + "2021-11-19");

    const expectedLocalStorage = JSON.stringify(expected);

    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchCurrencyAPI).toHaveBeenCalledTimes(1);
    expect(expectedLocalStorage).toStrictEqual(localStorageCurrencyRecord);
})

it("fetches data for specified date and currency from local storage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };
    const localStorageKey = "usd 2021-11-19";

    localStorage.setItem(localStorageKey, JSON.stringify(expected));
   
    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19",
    FetchAPI.fetchCurrencyAPI, localStorage);

    const localStorageCurrencyRecord = localStorage.getItem("usd" + " " + "2021-11-19");

    let expectedLocalStorage = JSON.stringify(expected);

    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchCurrencyAPI).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageCurrencyRecord);

})

it("fetches data from Latest API and saves it to localStorage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19",
    FetchAPI.fetchCurrencyAPI, localStorage);

    const localStorageCurrencyRecord = localStorage.getItem("usd" + " " + "2021-11-19");

    let expectedLocalStorage = JSON.stringify(expected);

    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchCurrencyAPI).toHaveBeenCalledTimes(1);
    expect(expectedLocalStorage).toStrictEqual(localStorageCurrencyRecord);
})

it("fetches data from Latest API response from local storage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    const localStorageKey = "usd 2021-11-19";

    localStorage.setItem(localStorageKey, JSON.stringify(expected));

    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19",
    FetchAPI.fetchCurrencyAPI, localStorage);

    const localStorageCurrencyRecord = localStorage.getItem("usd" + " " + "2021-11-19");

    let expectedLocalStorage = JSON.stringify(expected);

    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchCurrencyAPI).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageCurrencyRecord);

})
