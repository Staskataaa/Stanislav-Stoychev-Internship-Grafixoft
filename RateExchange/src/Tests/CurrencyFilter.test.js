import React from "react";
import ReactDOM from "react";
import * as CurrencyFilters from "../Utils/CurrencyFilters";
import * as Constants from '../Constants';

it("Filters specific currencies", () => {
    const array = [['axs', 0.078786], ['azn', 1.696762], 
    ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
    ['bgn', 1.958842], ['bdt', 104.454034]];

    expect(CurrencyFilters.getSpecifiedCurrencies(array)).toStrictEqual([['bgn', 1.958842]]);
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

    expect(CurrencyFilters.sortIntoColumns(array)).toStrictEqual(expectedResult);
});

it("Sorts key-value currencies by values", () => {
    const array = [['azn', 1.696762], ['axs', 0.078786],
    ['bgn', 1.958842], ['bam', 1.958886], ['bat', 3.163188],
    ['bdt', 104.454034], ['bbd', 2.018149]]

    const expectedArray = [['axs', 0.078786], ['azn', 1.696762],
    ['bgn', 1.958842], ['bam', 1.958886], ['bbd', 2.018149],
    ['bat', 3.163188], ['bdt', 104.454034]]

    expect(CurrencyFilters.sortCurrencyArray(array)).toStrictEqual(expectedArray);
})

it("Determinies key-value item column position", () => {

    const itemOne = ['azn', 1.696762];
    const itemTwo = ['axs', 0.078786];
    const itemThree = ['chf', 1.358886];

    const expectColumnItemOne = Constants.thirdColumn;
    const expectColumnItemTwo = Constants.firstColumn;
    const expectColumnItemThree = Constants.secondColumn;

    expect(CurrencyFilters.determineColumn(itemOne)).toEqual(expectColumnItemOne);
    expect(CurrencyFilters.determineColumn(itemTwo)).toEqual(expectColumnItemTwo);
    expect(CurrencyFilters.determineColumn(itemThree)).toEqual(expectColumnItemThree);
})

/*it("Converts to table-rows object", () => {

    const tableColumnObject = {
        firstColumnArray: [['axs', 0.078786]],
        secondColumnArray: [],
        thirdColumnArray: [['azn', 1.696762], 
        ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
        ['bgn', 1.958842], ['bdt', 104.454034]]
    };

    const tableRowsObject = [
        [[['axs', 0.078786]], undefined, [['azn', 1.696762]]],
        [undefined, undefined, [['bgn', 1.958842]]],
        [undefined, undefined, [['bam', 1.958886]]],
        [undefined, undefined, [['bbd', 2.018149]]],
        [undefined, undefined, [['bat', 3.163188]]],
        [undefined, undefined, [['bdt', 104.454034]]],
    ]

    expect(CurrencyFilters.converColumnsToRows(tableColumnObject)).toEqual(tableRowsObject);
})*/

