import Table from "../../Components/Table/Table";
import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { mount } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

Enzyme.configure({ adapter: new Adapter() });

it('renders table with label when all props are provided', () => {

    const data = {
        'cad': '1.759853',
        'aud': '0.014107',
        'bgn': '2.618904',
        'eur': '3.673103',
        'afn': '85.586079'
    };

    const date = '2022-08-22';
    const currencyName = 'usd';

    const props = {
        label: Constants.exchangeRateLabel,
        data: data,
        currency: currencyName,
        date: date,
        loading: Constants.LoadingData,
    }

    const wrapper = mount(<Table {...props}/>);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();
})

it("renders table when data is still loading", () => {
    let currencyName = 'usd';

    const response = null;

    const props = {
        label: Constants.exchangeRateLabel,
        data: currencyName,
        currency: currencyName,
        date: null,
        loading: Constants.LoadingData,
    };

    const wrapper = mount(<Table {...props} />);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();
})