import React from "react";
import { useEffect, useState, useCallback } from 'react';
import { ExoPlanetHomeCard } from "./exoPlanets/ExoPlanetHomeCard";
import { LogHomeCard } from "./logs/LogHomeCard";
import { ReceiptHomeList } from "./receipts/ReceiptHomeList";
import { getUserByFirebaseId } from '../modules/AuthManager';
import "./Home.css";
import firebase from "firebase/app";
import { onLoginStatusChange } from "../modules/AuthManager";
import Carousel from "nuka-carousel";
import { getAllExoPlanets } from "../modules/ExoPlanetManager";
import { color } from "@mui/system";


// const colors = [
//   '7732bb',
//   '047cc0',
//   '00884b',
//   'e3bc13',
//   'db7c00',
//   'aa231f',
//   'e3ac4a',
//   'db7c3e',
//   'ab23ff',
//   'ccc',
//   'ddd',
//   '000',
//   '111',
//   '222'
// ];

export function Home({ getLoggedInUser }) {
  // const [fireId, setFireId] = useState(null);
  const [isLoggedIn, setIsLoggedIn] = useState(null);
  
// export function Home({ getLoggedInUser }) {
//   // const [fireId, setFireId] = useState(null);
//   const [isLoggedIn, setIsLoggedIn] = useState(null);
//   const [exoPlanets, setExoPlanets] = useState([]);
//   const [planets, setPlanets] = useState([]);
//   useEffect(() => {
//     onLoginStatusChange(setIsLoggedIn);
//     getAllExoPlanets().then(setExoPlanets);

//   }, []);
  const [exoPlanets, setExoPlanets] = useState([]);
  const [planets, setPlanets] = useState([]);
  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
    getAllExoPlanets().then(setExoPlanets);

  }, []);

  

// var user  =  getUserByFirebaseId(fireBaseId);

//   setCurrentUser(getLoggedInUser);
  // State setState

  // Gets current users id
  // getAllExoPlanets();

  const slides = exoPlanets.map((color, index) => (
    <>
   <img className="slide-img"
       src={`/Images/${color.name}.jpg`}
       key={color.Id}
       alt={`Slide ${index + 1}`}
       data-slide={`Slide ${index + 1}`}
      
      
     />{color.name}</>
   ));
  
  return (
    <>
        <div className="home-header"></div>
      <div className="home">
        <div className="home-cards">
        <Carousel width="20" cellAlign="center" speed={1000} cellSpacing={15} slideWidth="20px" wrapAround={true}
        slidesToShow={26} autoplay 
        renderTopCenterControls={({ currentSlide }) => (     
        <div className="exoplanets-name">Exo-Planets</div>   )}   
        renderCenterLeftControls={({ previousSlide }) => (     
        <button onClick={previousSlide}>Previous</button>   )}   
        renderCenterRightControls={({ nextSlide }) => (     
        <button onClick={nextSlide}>Next</button>   )}> 
        {slides}
        </Carousel>
        



           {/* <ExoPlanetHomeCard /> */}
        </div>
        <div className="logHomeContainer">

          <LogHomeCard getLoggedInUser={getLoggedInUser} /> 
        </div>
        <div className="recieptContainer">

          <ReceiptHomeList />
        </div>
      </div>
    </>
  );
}