import ReactDOM from 'react-dom/client';
import './CSS/index.css';
import reportWebVitals from './reportWebVitals';
import Table from './Components/Table'
import React from 'react';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <Table />
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
