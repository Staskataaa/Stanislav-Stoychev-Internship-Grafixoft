export const dropdownOptionsData = (array) => {

    const dropdownAraray = [];

    array.map((item, index) => {
        const dropdownArarayItem = {
            value: array[index],
            label: array[index],
        };

        dropdownAraray.push(dropdownArarayItem);
    });

    return dropdownAraray;

}

export default dropdownOptionsData;