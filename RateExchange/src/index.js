import { render } from 'react-dom';
import './CSS/index.css';
import Application from './Components/Application'
import React from 'react';

const root = document.getElementById("root");

render(
        <>
            <Application />
        </>
, root);

