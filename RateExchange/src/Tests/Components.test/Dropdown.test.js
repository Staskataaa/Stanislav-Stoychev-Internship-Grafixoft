import Dropdown from "../../Components/Dropdown";
import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { mount } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

Enzyme.configure({ adapter: new Adapter() });

it("renders function in its default state", () => {

    const { currencyList, dropdownLabel } = Constants;
    const defaultSelectedValue = "USD";

    const props = {
        options: currencyList,
        defaultSelectedValue: defaultSelectedValue,
        label: dropdownLabel
    };

    const wrapper = mount(<Dropdown {...props}/>);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();

})
