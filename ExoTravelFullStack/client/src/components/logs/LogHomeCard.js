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
  const [fireId, setFireId] = useState(null);
  const [logs, setLogs] = useState();
//   console.log(user);
  const getMeFire = useCallback(async()=>{
    try{
        var fireBaseId = firebase.auth().currentUser.uid;

    }
    
    catch(e){
        console.log(e.message)
    }finally{
        getUserByFirebaseId(fireBaseId).then(setFireId)
    }
    
    
},[])
// var user  =  getUserByFirebaseId(fireBaseId);

//   setCurrentUser(getLoggedInUser);
  // State setState

  // Gets current users id
  
  useEffect( ()  => {
    getMeFire()
  }, []);
  // Gets all the logs by user for Home page
  useEffect( ()  => {
    if(fireId){

        getLogsByUserId(fireId.id).then(setLogs);
    }
  }, [fireId]);
console.log(fireId)
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