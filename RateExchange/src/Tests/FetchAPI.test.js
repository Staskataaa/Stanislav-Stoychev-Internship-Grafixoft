import * as FetchAPI from "../API/FetchAPI";
import * as Constants from "../Constants"


it("Fetches Latest Data for USD", async () => {
    
    FetchAPI.fetchAPILatest = jest.fn().mockReturnValueOnce({ date: "2021-11-19",
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }});

    const result = await FetchAPI.fetchAPI('usd');

    const expected = { date: "2021-11-19",
    usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    expect(result).toEqual(expected);
});

it("Fetches currenct Data for USD", async () => {
    
    FetchAPI.fetchAPILatest = jest.fn().mockReturnValueOnce({ date: Constants.currentDate,
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }});

    const result = await FetchAPI.fetchAPI('usd');

    const expected = { date: Constants.currentDate,
    usd: {  all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    expect(result).toEqual(expected);
});