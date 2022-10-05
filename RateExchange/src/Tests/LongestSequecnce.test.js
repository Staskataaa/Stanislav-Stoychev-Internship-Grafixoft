import * as Constants from "../Constants";
import * as LongestSequence from "../Utils/LongestSequence";

it("return values and inverse values from array", () => {

    //arrange
    const array = [1, 2, 4];
    const expectedArray = [0.25, 0.5, 1, 1, 2, 4];

    //act and assert
    expect(LongestSequence.getAllValues(array)).toEqual(expectedArray);
})

it("sorts values of array", () => {
    //arrange
    const array = [2.34, 0.51, 7, 2, 5, 9];
    const expectedArray = [0.51, 2, 2.34, 5, 7, 9];

    //act and assert
    expect(LongestSequence.sortValues(array)).toEqual(expectedArray);
})

it("finds the longest sequence", () => {

    //arrange
    const array = [0.2597, 0.3564, 0.3988, 0.5666, 0.8784, 0.9786, 1.1231, 1.1565];
    const expectedLongestSequence = 4;

    //act and assert
    expect(LongestSequence.findLongestSequesnce(array)).toBe(expectedLongestSequence);
})


