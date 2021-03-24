import React from 'react';
import {Switch, Route} from 'react-router-dom';

import Header from "../header/Header";
import Map from "../map/Map";
import Settings from "../settings/Settings";
import Error404 from "../errors/Error404";

import "./app.css";

const App = () => {
    return (
        <div className="app container">
            <Header/>
            <Switch>
                <Route exact path="/" component={Map}/>
                <Route path="/settings" component={Settings}/>
                <Route component={Error404}/>
            </Switch>
        </div>
    )
}

export default App;