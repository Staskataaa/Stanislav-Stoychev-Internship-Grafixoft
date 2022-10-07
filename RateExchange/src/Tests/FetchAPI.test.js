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

    mockedFetchAPI = require('../API/FetchAPI');
})

it("Fetches Latest Data for USD", async () => {

    //arrange
    const expected = {  date: "2022-10-06",
    usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    //act
    const result = await FetchAPI.fetchAPILatest('usd');

    //assert
    expect(result).toEqual(expected);
});

it("Fetches Currenct Data for USD", async () => {
  
    //arrange
    const expected = { date: "2021-11-19",
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }};
    
    //act
    const result = await mockedFetchAPI.fetchAPIDate('usd', "2021-11-19");

    //assert
    expect(result).toEqual(expected);
});
