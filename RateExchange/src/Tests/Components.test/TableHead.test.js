import TableHead from "../../Components/Table/TableHead";
import renderer from 'react-test-renderer';
import * as Constants from "../../Constants";
import * as CurrencyFilters from "../../Utils/CurrencyFilters";

it('renders the table body when Array is provided', () => {
    const tableColumnNames = Constants.tableColumnNames;

    const component = renderer.create(
        <TableHead 
            columnNames={ tableColumnNames }/>
    );

    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
})