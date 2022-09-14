import { useEffect, useState } from 'react';
import { FetchCurrency } from '../Utils/FetchAPI';
import { filterToDefaultValues } from '../Utils/FilterResponse';

function Table(props)
{
    const [items, setItems] = useState({ items: {}, currency: '123'});

    useEffect(() => {
        const currencyChangeRate =  FetchCurrency('eur');
        setItems(currencyChangeRate); 
    }, []);

    return (    
        console.log(items)
    );
}

export default Table;
