import { render } from 'react-dom';
import './CSS/index.css';
import Application from './Components/Application'
import React from 'react';
import * as Constants from "./Constants"

const root = document.getElementById("root");

render(
        <>
            <Application defaultCurrency = { Constants.defaultCurrency } />
        </>
, root);

