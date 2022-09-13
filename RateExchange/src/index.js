import React, { useState } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { useEffect } from "react";

function FetchAll(props) {

  const [items, setItems] = useState([]);
  let array;

  useEffect(() => {
    fetch("https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/eur.json")
    .then((res) => res.json())
    .then((res) => { 
      array = Object.entries(res.eur);
      let sorted = array.sort((a ,b) => a[1] - b[1])
      console.log(sorted);
      setItems(sorted);
    })     
    .catch((err) => console.log(err))
  }, []);

  function filter(items, minRange, maxRange)
  {
    let result = [...items];
    return (
      result.filter((item) => item[1] > minRange && item[1] <= maxRange)
    );
  }

  return (
  <div>
    <table>
      <thead>
        <tr>
          <th>Conversion Rates below 1</th>
          <th>Conversion Rates between 1 and 1,5</th>
          <th>Conversion Rates above 1,5</th>
        </tr>
      </thead>
      <tbody>
        {
          <div>
            ${
            filter(items, 0, 1).map(( index, value ) => {
            return (
            <tr key={index}>
              <td>{index}</td>
              <td>{value}</td>
            </tr>
          );
        })}<div/>
        {
          filter(items, 1, 1,5).map(( index, value ) => {
          return (
            <tr key={index}>
              <td>{index}</td>
              <td>{value}</td>
            </tr>
          );
        })}
        </tbody>
      </table>
    </div> )
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <FetchAll />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
