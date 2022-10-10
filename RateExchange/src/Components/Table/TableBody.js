import * as CurrencyFilters from '../../Utils/CurrencyFilters';

function TableBody(props) {

    return (
        props.data !== undefined &&
        <tbody id="table-body">
            {
                CurrencyFilters.convertToRows(props.data).map((array, arrayIndex) => {
                    return (
                        <tr key={arrayIndex} className="table-row">
                            {
                                array.map((item, itemIndex) => {
                                    if (item !== undefined) {
                                        return (
                                            <td key={itemIndex} className="table-col">
                                                {item[0]} : {item[1]}
                                            </td>
                                        )
                                    }
                                    else {
                                        return (
                                            <td key={itemIndex} className="table-col"></td>
                                        )
                                    }
                                })
                            }
                        </tr>
                    )
                })
            }
            <tr className="table-row">
                {
                        props.data.map((value, index) => {
                        return (
                            <td key={index} className="table-col">
                                Count: {value.length}
                            </td>
                        )
                    })
                }
            </tr>
        </tbody>
    )

}

export default TableBody