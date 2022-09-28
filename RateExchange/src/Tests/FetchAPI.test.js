import * as FetchAPI from "../APICalls/FetchAPI";
import * as Constants from "../Constants/Constants"

/*global.fetch = jest.fn(() => {
    Promise.resolve({
        json: () => ,
    })
})*/

FetchAPI.FetchCurrency(currency, date) = jest.fn(() => Promise.resolve({ 
    date: "2021-11-19", usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 } 
}))

it("Fetches Data for USD", async () => {
    const dataUSD = await FetchAPI.FetchCurrency('usd', Constants.currentDate);

    const response = { date: "2021-11-19", usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    expect(dataUSD).toEqual(response);
});