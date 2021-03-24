import React from "react";
import {NavLink} from "react-router-dom";

const Header = () => {
    return (
        <div className="navbar navbar-dark bg-dark">
            <NavLink exact to="/" className="navbar-brand" activeClassName="current">Mapa</NavLink>
            <ul className="navbar-nav mr-auto">
                <li className="nav-item">
                    <a href="https://paciak.pl" className="btn btn-secondary">Powrót na paciaka</a>
                </li>
            </ul>
        </div>
    );
}

export default Header;