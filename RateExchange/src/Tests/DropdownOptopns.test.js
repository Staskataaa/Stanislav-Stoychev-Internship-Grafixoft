import * as DropdownOptions from "../Utils/DropdownOptions";
import * as Constants from "../Constants";

it(" Converts array to dropdown-array", () => {

    //arrange
    const array = Constants.currencyList;

    const expected = [
        { value: 'USD', label: 'USD'},
        { value: 'EUR', label: 'EUR'},
        { value: 'AUD', label: 'AUD'},
        { value: 'CAD', label: 'CAD'},
        { value: 'CHF', label: 'CHF'},
        { value: 'NZD', label: 'NZD'},
        { value: 'BGN', label: 'BGN'}
    ];

    //act and assert
    expect(DropdownOptions.dropdownOptionsData(array)).toStrictEqual(expected);
})