import "bootstrap/dist/css/bootstrap.css";
import "reflect-metadata";

import React from "react";
import ReactDOM from "react-dom";
import {BrowserRouter} from "react-router-dom";
import {Provider} from "inversify-react";
import {Provider as ReduxProvider} from "react-redux";

import container from "./ioc";
import App from "./components/core/app/App";
import setupStore from "./redux/setupStore";

let baseUrl = document.querySelector("base")?.getAttribute("href") ?? "";
const rootElement = document.getElementById("root");
const store = setupStore();

ReactDOM.render(
  <Provider container={container}>
    <ReduxProvider store={store}>
      <BrowserRouter basename={baseUrl}>
        <App/>
      </BrowserRouter>
    </ReduxProvider>
  </Provider>,
  rootElement);
