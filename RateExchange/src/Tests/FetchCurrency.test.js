/*import * as FetchCurrency from "../Utils/FetchCurrency";
import * as FetchAPI from "../API/FetchAPI";

const localStorageMock = ( function () {

    let localStorage = {};

    return {
        getItem(key) {
            let result = localStorage[key];
            if (result === undefined)
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
})();*/

test('should save to localStorage', () => {
    const KEY = 'foo',
        VALUE = 'bar';
    dispatch(action.update(KEY, VALUE));
    expect(localStorage.setItem).toHaveBeenLastCalledWith(KEY, VALUE);
    expect(localStorage.__STORE__[KEY]).toBe(VALUE);
    expect(Object.keys(localStorage.__STORE__).length).toBe(1);
});
/*beforeEach(() => {

    FetchAPI.fetchAPI = jest.fn().mockResolvedValue({
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    });

    Object.defineProperty(window, "localStorage", { value: localStorageMock });
    window.localStorage.clear();
})

it("fetches data for specified date and currency and saves it to local Storage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19");

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPI).toHaveBeenCalledTimes(1);
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

    const result = await FetchCurrency.fetchCurrency('usd', "2021-11-19");

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPI).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);

})

it("fetches data from Latest API and saves it to localStorage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    //act
    const result = await FetchCurrency.fetchCurrency('usd');

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['latest usd'];


    let expectedLocalStorage = JSON.stringify(expected);

    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPI).toHaveBeenCalledTimes(1);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);
})

it("fetches data from Latest API response from local storage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    const localStorageKey = "latest usd";

    localStorage.setItem(localStorageKey, JSON.stringify(expected));

    const result = await FetchCurrency.fetchCurrency('usd');

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['latest usd'];


    let expectedLocalStorage = JSON.stringify(expected);
    //assert
    expect(result).toEqual(expected);
    expect(FetchAPI.fetchAPI).toHaveBeenCalledTimes(0);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);

})*/
