import TableBody from "../../Components/Table/TableBody";
import renderer from 'react-test-renderer';
import * as Constants from "../../Constants";
import * as CurrencyFilters from "../../Utils/CurrencyFilters";

it('renders the table body when Array with Arrays is provided', () => {

    const respnoseCurrency = {
        '1inch': '1.759853',
        'aave': '0.014107',
        'ada': '2.618904',
        'aed': '3.673103',
        'afn': '85.586079',
    }

    const data = CurrencyFilters.applyFilters(respnoseCurrency);

    const props = {
        data: data,
        label: Constants.tableColumnsLenghtsLabel
    };

    const component = renderer.create(
        <TableBody
            data = {data}
            label = {Constants.tableColumnsLenghtsLabel} />
    );

    renderer.create(() => {
        component.TableData;
    });

    renderer.create(() => {
        component.TableColumnsLenghts;
    });

    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
})