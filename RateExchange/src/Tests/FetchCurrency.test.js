import * as FetchCurrency from "../Utils/FetchCurrency";
import * as FetchAPI from "../API/FetchAPI";

const localStorageMock = (function () {

    let localStorage = {};

    return {
        getItem(key) {
            let result = localStorage[key];
            if(result === undefined)
            {
                result = null;
            }
            return result;
        },

        setItem(key, value) {
            localStorage[key] = value || '';
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

        key: function (value) {
            const keys = Object.keys(localStorage);
            return keys[value] || null;
        },

        get length() {
            return Object.keys(localStorage).length;
        }
    };
})();

let mockedFetchAPI;

beforeEach(() => {

    FetchAPI.fetchAPIDate = jest.fn().mockResolvedValue({
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    });

    FetchAPI.fetchAPILatest = jest.fn().mockResolvedValue({
        date: "2022-10-06",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    });


    Object.defineProperty(window, "localStorage", { value: localStorageMock });
    window.localStorage.clear();
})

it("fetches data for specified date and currency and saves it to localStorage", async () => {
    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrencyDate('usd', "2021-11-19");

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPIDate).toHaveBeenCalledTimes(1);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);
})

it("fetches data for specified date and currency from local storage", async () => {
    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };
    const localStorageKey = "2021-11-19 usd";

    localStorage.setItem(localStorageKey, JSON.stringify(expected));

    const check = localStorage.getAll();

    const result = await FetchCurrency.fetchCurrencyDate('usd', "2021-11-19");

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPIDate).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);

})

it("fetches data from Latest API and saves it to localStorage", async () => {
    //arrange
    const expected = {
        date: "2022-10-06",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrencyLatest('usd');

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2022-10-06 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPILatest).toHaveBeenCalledTimes(1);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);
})

it("fetches data for based on Latest API response from local storage", async () => {
    //arrange
    const expected = {
        date: "2022-10-06",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    const localStorageKey = "2022-10-06 usd";

    localStorage.setItem(localStorageKey, JSON.stringify(expected));

    const check = localStorage.getAll();

    const result = await FetchCurrency.fetchCurrencyLatest('usd');

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2022-10-06 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPILatest).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);

})
