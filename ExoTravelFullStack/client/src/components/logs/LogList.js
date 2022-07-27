//Imports
import React, { useCallback, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import { LogCard } from "./LogCard";
import { deleteLog, getLogsByUserId } from "../../modules/LogManager";
import "./LogList.css";
import { getUserByFirebaseId } from '../../modules/AuthManager';
import firebase from "firebase/app";

// Lists Logs by user id
export const LogList = () => {
  // State setState
  const [fireId, setFireId] = useState(null);
  const [logs, setLogs] = useState();
  const handleDeleteLog = (fireId) => {
    deleteLog(fireId.id).then(() => getLogsByUserId(fireId.id).then(setLogs));
  };
//   console.log(user);
  const getMeFire = useCallback(async()=>{
    try{
        var fireBaseId =  firebase.auth().currentUser.uid;

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
  
  // Gets all the logs by user for Home page
  useEffect(  ()  => {
      if(fireId){
          // console.log(fireId)
          getLogsByUserId(fireId.id).then(setLogs)
        }
    }, [fireId]);
    useEffect( ()  => {
      getMeFire()
    }, []);
console.log(logs)
  // Displays all the Logs the user has
  return (
    <div className="log-container">
      <div className="log-list">
        <h2 className="log-list-header">Logs</h2>
        <div className="log-list-content">
          {logs?.map((i) => (
            <LogCard key={i.id} log={i} handleDeleteLog={handleDeleteLog} />
          ))}
        </div>
      </div>
    </div>
  );
};
