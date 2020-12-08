import 'bootstrap/dist/css/bootstrap.css';
import '@fortawesome/free-brands-svg-icons';
import '@fortawesome/fontawesome-svg-core';
import '@fortawesome/free-regular-svg-icons';
import '@fortawesome/free-solid-svg-icons';
import '@fortawesome/react-fontawesome';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import SnowStorm from 'react-snowstorm';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
        <App />
        <SnowStorm/>
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

