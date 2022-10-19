import InputAndButtonUpdateCurrency from "../../Components/InputAndButtonUpdateCurrency";
import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { mount } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

Enzyme.configure({ adapter: new Adapter() });

it("shows input and update currency button when not all values are updated", () => {

    const currency = "usd";
    const areValuesUpdated = false;
    const { inputLabel, longestSequenceMessage, updateButtonName} = Constants;
    
    const props = {
        currency: currency,
        areValuesUpdated: areValuesUpdated,
        label: inputLabel,
        longestSequenceMessage: longestSequenceMessage,
        buttonText: updateButtonName
    };

    const wrapper = mount(<InputAndButtonUpdateCurrency {...props}/>);

    const wrapperToJson = toJson(wrapper);

    expect(wrapperToJson).toMatchSnapshot();
});

it("shows input and update currency button when not all values are updated", () => {

    const currency = "usd";
    const areValuesUpdated = true;
    const { inputLabel, longestSequenceMessage, updateButtonName } = Constants;

    const props = {
        currency: currency,
        areValuesUpdated: areValuesUpdated,
        label: inputLabel,
        longestSequenceMessage: longestSequenceMessage,
        buttonText: updateButtonName
    };

    const wrapper = mount(<InputAndButtonUpdateCurrency {...props} />);

    const wrapperToJson = toJson(wrapper);

    expect(wrapperToJson).toMatchSnapshot();
});