import * as Constants from "../../Constants";
import Enzyme from 'enzyme';
import toJson from "enzyme-to-json";
import { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-17-updated';
import TableHead from "../../Components/Table/TableHead";

Enzyme.configure({ adapter: new Adapter() });

it("renders table head when all props are specified", () => {

    const { tableColumnNames } = Constants;

    const props = {
        columnNames: tableColumnNames,
    };

    const wrapper = shallow(<TableHead {...props} />);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();
})

it("renders table when no props are provided", () => {

    const wrapper = shallow(<TableHead/>);

    const jsonWrapper = toJson(wrapper);

    expect(jsonWrapper).toMatchSnapshot();
});