import ReactDOM from 'react-dom/client';
import './CSS/index.css';
import Application from './Components/Application'
import React from 'react';
import * as Constants from "./Constants"

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
        <>
            <Application defaultCurrency = { Constants.defaultCurrency } />
        </>
);

