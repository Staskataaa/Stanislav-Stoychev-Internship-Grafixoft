import UpdateDateButton from "../../Components/UpdateDateButton";
import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { mount } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';

Enzyme.configure({ adapter: new Adapter() });

it("renders dafault update date button", () => {

    const date = "2022-17-10";
    const { buttonText } = Constants;

    const props = {
        date: date, 
        buttonText: buttonText,
    };
    
    const wrapper = mount(<UpdateDateButton {...props} />);

    const wrapperToJson = toJson(wrapper);

    expect(wrapperToJson).toMatchSnapshot();
});