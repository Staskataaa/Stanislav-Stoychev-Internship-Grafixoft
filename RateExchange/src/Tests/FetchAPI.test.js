import * as FetchAPI  from "../API/FetchAPI";
import * as Constants from "../Constants"

beforeEach(() => {

    FetchAPI.fetchAPI = jest.fn().mockResolvedValue({
        date: "2021-11-19",
        usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }
    });
})

it("Fetches Latest Data for USD", async () => {

    //arrange
    const expected = {  date: "2021-11-19",
    usd: { all: 107.149788, amd: 476.240219, ang: 1.801878 }};

    //act
    const result = await FetchAPI.fetchAPI('usd');

    //assert
    expect(result).toEqual(expected);
});
