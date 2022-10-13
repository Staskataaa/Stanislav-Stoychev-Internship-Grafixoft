import React from "react";
import ReactDOM from "react";
import * as CurrencyFilters from "../Utils/CurrencyFilters";
import * as Constants from '../Constants';

it("Filters specific currencies", () => {

    //arrange
    const array = [['axs', 0.078786], ['azn', 1.696762], 
    ['bam', 1.958886], ['bat', 3.163188],['bbd', 2.018149], 
    ['bgn', 1.958842], ['bdt', 104.454034]];

    //act and assert
    expect(CurrencyFilters.getSpecifiedCurrencies(array)).toStrictEqual([['bgn', 1.958842]]);
});

it("Sorts Currencies into groups", () => {

    //arrange
    const array = [['axs', 0.078786], ['azn', 1.696762], 
    ['bam', 1.954556], ['bbd', 2.018149],
    ['bat', 3.163188], ['bdt', 104.454034]];

    const expectedResult = [[['axs', 0.078786]], [], [['azn', 1.696762],
    ['bam', 1.954556], ['bbd', 2.018149], ['bat', 3.163188], ['bdt', 104.454034]]]

    //act and assert
    expect(CurrencyFilters.sortIntoColumns(array)).toStrictEqual(expectedResult);
});

it("Sorts key-value currencies by values", () => {

    //arrange
    const array = [['azn', 1.696762], ['axs', 0.078786],
    ['bgn', 1.958842], ['bam', 1.958886], ['bat', 3.163188],
    ['bdt', 104.454034], ['bbd', 2.018149]];

    const expectedArray = [['axs', 0.078786], ['azn', 1.696762],
    ['bgn', 1.958842], ['bam', 1.958886], ['bbd', 2.018149],
    ['bat', 3.163188], ['bdt', 104.454034]];

    //act and assert
    expect(CurrencyFilters.sortCurrencyArray(array)).toStrictEqual(expectedArray);
})

it("Determinies key-value item column position", () => {

    //arrange
    const itemThree = ['azn', 1.696762];
    const itemOne = ['axs', 0.078786];
    const itemTwo = ['chf', 1.358886];
      
    const expectColumnOneIndex = 0;
    const expectColumnTwoIndex = 1;
    const expectColumnThreeIndex = 2;

    //act and assert
    expect(CurrencyFilters.determineColumn(itemOne)).toEqual(expectColumnOneIndex);
    expect(CurrencyFilters.determineColumn(itemTwo)).toEqual(expectColumnTwoIndex);
    expect(CurrencyFilters.determineColumn(itemThree)).toEqual(expectColumnThreeIndex);
})

it("Converts to table-rows object", () => {

    //arrange
    const tableColumnArray =  [[['axs', 0.078786]], [], [['azn', 1.696762], 
    ['bam', 1.958886],['bbd', 2.018149], ['bat', 3.163188], ['bdt', 104.454034]]];
       
    const tableRowsObject = [
        [['axs', 0.078786], undefined, ['azn', 1.696762]],
        [undefined, undefined, ['bam', 1.958886]],
        [undefined, undefined, ['bbd', 2.018149]],
        [undefined, undefined, ['bat', 3.163188]],
        [undefined, undefined, ['bdt', 104.454034]],
    ];

    //act and assert
    expect(CurrencyFilters.convertToRows(tableColumnArray)).toEqual(tableRowsObject);
})
