import * as FetchAPI from "../API/FetchAPI";
import * as Constants from "../Constants"

//providing mock local storage implementaion 
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

        key: function (value) {
            const keys = Object.keys(localStorage);
            return keys[value] || null;
        },

        get length() {
            return Object.keys(localStorage).length;
        }
    };
})();

beforeEach(() => {

    const mockFetchPromise = Promise.resolve({
        json: () => Promise.resolve({
            date: "2021-11-19",
            usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
        })
    })

    global.fetch = jest.fn(() => mockFetchPromise);

    //initial arrange
    FetchAPI.fetchAPILatest = jest.fn().mockReturnValue({ date: "2021-11-19",
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }});

    FetchAPI.fetchAPIDate = jest.fn().mockReturnValue({ date: Constants.currentDate,
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }});

    Object.defineProperty(window, "localStorage", { value: localStorageMock });
    window.localStorage.clear();
})

it("Fetches Latest Data for USD", async () => {

    //arrange
    const expected = { date: "2021-11-19",
    usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    //act
    const result = await FetchAPI.fetchAPILatest('usd');

    //assert
    expect(result).toEqual(expected);
});

it("Fetches currenct Data for USD", async () => {
  
    //arrange
    const expected = { date: Constants.currentDate,
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }};
    
    //act
    const result = await FetchAPI.fetchAPIDate('usd', Constants.currentDate);

    //assert
    expect(result).toEqual(expected);
});

it("fetches latest data for USD from mocked implementation and puts it into localstorage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    let expectedLocalStorage = JSON.stringify(expected);;
    
    //act
    const result = await FetchAPI.fetchCurrencyLatest('usd');

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];

    //assert
    expect(result).toEqual(expected);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);
})

it("fetches current data for USD from mocked implementation and puts it into localstorage", async () => {

    //arrange
    const expected = {
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    };

    let expectedLocalStorage = JSON.stringify(expected);;

    //act
    const result = await FetchAPI.fetchCurrencyLatest('usd', Constants.currentDate);

    const localStorageItems = localStorage.getAll();
    const localStorageItemUSD = localStorageItems['2021-11-19 usd'];

    //assert
    expect(result).toEqual(expected);
    expect(expectedLocalStorage).toStrictEqual(localStorageItemUSD);
})