import TableBody from "../../Components/Table/TableBody";
import * as Constants from "../../Constants";
import * as CurrencyFilters from "../../Utils/CurrencyFilters"
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

Enzyme.configure({ adapter: new Adapter() });

it("renders table data when all props are provided correctly", () => {
    
    const response = {  
        'cad': '1.759853',
        'aud': '0.014107',
        'bgn': '2.618904',
        'eur': '3.673103',
        'afn': '85.586079'
    };

    let currencyName = 'usd'

    const data = CurrencyFilters.applyFilters(response);

    const { tableColumnsLenghtsLabel } = Constants;

    const props = {
        data: data,
        countField: tableColumnsLenghtsLabel,
    };

    const wrapper = shallow(<TableBody {...props}/>);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();
})