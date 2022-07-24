import React from "react";
import { useEffect, useState } from 'react';
import { ExoPlanetHomeCard } from "./exoPlanets/ExoPlanetHomeCard";
import { LogHomeCard } from "./logs/LogHomeCard";
import { ReceiptHomeList } from "./receipts/ReceiptHomeList";
import { getUserByFirebaseId } from '../modules/AuthManager';
import "./Home.css";

export function Home({ isLoggedIn, getLoggedInUser }) {
  
  return (
    <>
      <div className="home">
        <div className="home-header"></div>
        <div className="home-cards">
          <ExoPlanetHomeCard />
          <LogHomeCard isLoggedIn={isLoggedIn} getLoggedInUser={getLoggedInUser} />
          <ReceiptHomeList />
         
        </div>
      </div>
    </>
  );
}