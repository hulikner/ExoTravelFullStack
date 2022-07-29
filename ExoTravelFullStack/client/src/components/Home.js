import React from "react";
import { useEffect, useState, useCallback } from 'react';
import { ExoPlanetHomeCard } from "./exoPlanets/ExoPlanetHomeCard";
import { LogHomeCard } from "./logs/LogHomeCard";
import { ReceiptHomeList } from "./receipts/ReceiptHomeList";
import { getUserByFirebaseId } from '../modules/AuthManager';
import "./Home.css";
import firebase from "firebase/app";
import { onLoginStatusChange } from "../modules/AuthManager";


export function Home({ getLoggedInUser }) {
  // const [fireId, setFireId] = useState(null);
  const [isLoggedIn, setIsLoggedIn] = useState(null);
  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
  }, []);

// var user  =  getUserByFirebaseId(fireBaseId);

//   setCurrentUser(getLoggedInUser);
  // State setState

  // Gets current users id
  
  
  return (
    <>
      <div className="home">
        <div className="home-header"></div>
        <div className="home-cards">
          <ExoPlanetHomeCard />
          <LogHomeCard getLoggedInUser={getLoggedInUser} />
          <ReceiptHomeList />
         
        </div>
      </div>
    </>
  );
}