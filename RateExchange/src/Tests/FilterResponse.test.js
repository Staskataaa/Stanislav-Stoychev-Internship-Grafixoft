import React from "react";
import ReactDOM from "react";
import * as FilterResponse from "../Utils/FilterResponse";

it("Filters specific currencies", () => {
    const array = [['axs', 0.078786], ['azn', 1.696762], 
    ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
    ['bgn', 1.958842], ['bdt', 104.454034]]

    expect(FilterResponse.filterCurrencies(array)).toStrictEqual([['bgn', 1.958842]]);
});

it("Sorts Currencies into groups", () => {
    const array = [['axs', 0.078786], ['azn', 1.696762], 
    ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
    ['bgn', 1.958842], ['bdt', 104.454034]]

    const expectedResult = {
            firstColumnArray: [['axs', 0.078786]],
            secondColumnArray: [],
            thirdColumnArray: [['azn', 1.696762], 
            ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
            ['bgn', 1.958842], ['bdt', 104.454034]]
    }

    expect(FilterResponse.ArrayGroups(array)).toStrictEqual(expectedResult);
});
