export const dropdownOptionsData = (array) => {

    const dropdownAraray = [];

    for(let index = 0; index < array.length; index++)
    {
        const dropdownArarayItem = {
            value: array[index],
            label: array[index],
        };

        dropdownAraray.push(dropdownArarayItem);
    }

    return dropdownAraray;
}

export default dropdownOptionsData;