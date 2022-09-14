import React from 'react';
import './App.css';

export default class Rows extends React.Component {
    
  constructor(props) {
    super(props);
    this.state = {
        items: this.props.items,
    }
  }

  componentWillMount()
  {
    this.state.items = 
    fetch("https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/eur.json")
    .then((res) => res.json())
    .then((res) => { 
      let array = Object.entries(res.eur);
      let sorted = array.sort((a ,b) => a[1] - b[1])
      console.log(sorted);
      this.setState({
        items: sorted,
      });
    })     
    .catch((err) => console.log(err));
  }

  render() {
    console.log(this.state.items);
    let tableBody = document.getElementById('table-body');
    let firstColArray = this.filterItems(this.state.items, 0, 1);
    let secondColArray = this.filterItems(this.state.items, 1, Number(1,5));
    let thirdColArray = this.filterItems(this.state.items, Number(1,5), Number.MAX_VALUE);
    for(let rowIndex = 0; rowIndex < this.findMaxLength(this.state.items); rowIndex++)
    {
        tableBody.insertRow(rowIndex);
        if(firstColArray != [])
        {
            <td>{firstColArray[0]} : {firstColArray[1]}</td>
        }
        else
        {
            <td></td>
        }
        if(secondColArray != [])
        {
            <td>{secondColArray[0]} : {secondColArray[1]}</td>
        }
        else
        {
            <td></td>
        }
        if(thirdColArray != [])
        {
            <td>{thirdColArray[0]} : {thirdColArray[1]}</td>
        }
        else
        {
            <td></td>
        }
    }

    return {
        tableBody
    }
  }
}
