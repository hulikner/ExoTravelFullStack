// Imports
import React, { useCallback, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import { getLogsByUserId } from "../../modules/LogManager";
import { getAllLogs } from "../../modules/LogManager";
import { getUserByFirebaseId } from '../../modules/AuthManager';
import firebase from "firebase/app";


import "../Home.css";

export const LogHomeCard = ({ isLoggedIn, getLoggedInUser }) => {
  // React-Router-Dom use
  const { logId } = useParams();
  let [currentUser, setCurrentUser] = useState();
  const [logs, setLogs] = useState();
  // const [isLoggedIn, setIsLoggedIn] = useState(null);
  // useEffect(() => {
  //   onLoginStatusChange(setIsLoggedIn);
  // }, []);
  
// var user  =  getUserByFirebaseId(fireBaseId);

//   setCurrentUser(getLoggedInUser);
  // State setState

  // Gets current users id
  
  
  // Gets all the logs by user for Home page
  useEffect( ()  => {
    

        getLogsByUserId().then(setLogs);
    
  }, []);

  // Sends a list of users logs to Home Page
  return (
    <div className="log-home-container">
      <h2 className="log-home-header">Itineraries</h2>
      <div className="log-home-card">
        {logs?.map((x) => (
          <div className="log-home-content" key={x?.id}>
            <Link className="log-home-link" to={`/logs/${x?.id}`}>
              <div className="log-home-img-container">
                <img className="log-home-img" src={`../Images/${x?.exoPlanet?.name}.jpg`} />
                <span className="log-home-img-name">{x?.exoPlanet?.name}</span>
              </div>
              <div className="log-home-departureDate">Departure: {epochDateConverter(x?.departureDate, "eee. MMM do")}</div>
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
};
