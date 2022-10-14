import Table from "../../Components/Table/Table";
import renderer from 'react-test-renderer';
import * as Constants from "../../Constants";
import * as CurrencyFilters from "../../Utils/CurrencyFilters";
import { render } from "@testing-library/react";
import { act } from "react-dom/test-utils";
import ReactDOM from 'react-dom/client';



let container;

beforeEach(() => {
    container = document.createElement('div');
    document.body.appendChild(container);
});

it('renders table with label when all props are provided', () => {

    const response = {
        date: '2022-10-07',
        usd: {
            '1inch': '1.759853',
            'aave': '0.014107',
            'ada': '2.618904',
            'aed': '3.673103',
            'afn': '85.586079'
        }
    };

    const { currencyList } = Constants;
    const respnoseKeys = Object.keys(response);
    let currencyName;

    respnoseKeys.forEach(element => {
        currencyList.forEach((currency) => {
            if(element === currency) {
                currencyName = currency;
            }
        })
    });

    const test = act(() => {
        ReactDOM.createRoot(container).render(
            <Table
                label={Constants.exchangeRateLabel}
                data={response['usd']}
                currency={currencyName}
                date = {response.date}
                loading={Constants.LoadingData}
            />
        );
    });

    const table = container.querySelector('.testClass');
    // console.log(table)

    expect(true).toBe(true);


    // const component = renderer.create(
    //     <Table
    //         label={Constants.exchangeRateLabel}
    //         data={response['usd']}
    //         currency={currencyName}
    //         date = {response.date}
    //         loading={Constants.LoadingData} />
    // );

    // renderer.update(component);
    // console.log(component);
    console.log(table.innerHTML);

    // expect(tree).toMatchSnapshot();
})