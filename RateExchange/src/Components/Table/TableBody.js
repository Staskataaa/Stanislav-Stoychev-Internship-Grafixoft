
import * as CurrencyFilters from '../../Utils/CurrencyFilters';


function TableBody(props) {

    const TableData = () => {
        return (
            CurrencyFilters.convertToRows(props.data).map((array, arrayIndex) => {
                return (
                    <tr key={arrayIndex} className="table-row">
                        {
                            array.map((item, itemIndex) => {
                                const undefinedItem = [undefined, undefined];
                                const [firstItem, secondItem] = item ?? undefinedItem;
                                return (
                                    <td key={itemIndex} className="table-col">
                                        {firstItem} {secondItem}
                                    </td>
                                )
                            })
                        }
                    </tr>
                )
            })
        )
    }

    const TableColumnsLenghts = () => {
        return (
            <tr className="table-row">
                {
                    props.data.map((value, index) => {
                        return (
                            <td key={index} className="table-col">
                                { props.label } {value.length}
                            </td>
                        )
                    })
                }
            </tr>
        )
    }

    return (
        props.data !== undefined
        && <tbody id="table-body">
            <TableData />
            <TableColumnsLenghts />
        </tbody>
    )

}

export default TableBody