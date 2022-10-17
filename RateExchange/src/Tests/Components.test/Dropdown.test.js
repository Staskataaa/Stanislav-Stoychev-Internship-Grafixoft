import Table from "../../Components/Table/Table";
import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { mount } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

it("renders dropdown component when all props are provided", () => {

    const { currencyList, label } = Constants;
    const defaultSelectedCurrency = 'USD';
    
    const props = {
        options: currencyList,
        onValueChange: ,
        defaultSelectedValue: defaultSelectedCurrency,
        label: label
    }
})