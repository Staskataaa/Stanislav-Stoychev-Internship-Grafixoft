export const getCurrentDay = () => {

    const date = new Date();
    const getDay = String(date.getDate()).padStart(2, '0');
    const getMonth = String(date.getMonth() + 1).padStart(2, '0');
    const getYear = date.getFullYear();
    const currentDate = getYear + '-' + getMonth + '-' + getDay;

    return currentDate;
}

export default getCurrentDay