import React, {useEffect} from "react";
import {useDispatch, useSelector} from "react-redux";

import 'leaflet/dist/leaflet.css';
import {MapContainer, Marker, Popup, TileLayer} from 'react-leaflet';
import {Icon, IconOptions} from "leaflet";

import RootState from "../../../models/RootState";
import * as MapUsersActions from "../../../redux/map-users/map-users-actions";
import {LoadingState} from "../../../models/LoadingState";
import MapUsersState from "../../../models/MapUsersState";

import "./map.css";

const iconDefaults: IconOptions = {
    iconUrl: '',
    iconSize: [32, 32],
    iconAnchor: [16, 16],
    popupAnchor: [0, -16]
};

const Map = () => {
    const dispatch = useDispatch();    
    const { users, loading } = useSelector<RootState, MapUsersState>(state => state.mapUsers);
    
    useEffect(() => {
        dispatch(MapUsersActions.loadUsers());
    }, [dispatch])
    
    return (
        <div className="map">
            {loading === LoadingState.Loading ? (
                <div className="map-loader"/>
            ) : ''}
            <MapContainer center={[51.85, 18]} zoom={7}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                {users !== null && users.map(user => {
                    const icon = new Icon({
                        ...iconDefaults,
                        iconUrl: user.AvatarUrl
                    });

                    return (
                        <Marker key={user.Uid} position={[user.LocationLatitude, user.LocationLongitude]} icon={icon}>
                            <Popup>
                                <div>
                                    <b>{user.Name}</b>
                                </div>
                                <div>
                                    <a href={"https://paciak.pl/user/" + user.Name}>Pokaż profil</a>
                                </div>
                                {user.Location ? (
                                    <div><i>{user.Location}</i></div>    
                                ) : ''}
                            </Popup>
                        </Marker>
                    );
                })}
            </MapContainer>
        </div>
    )
};

export default Map;