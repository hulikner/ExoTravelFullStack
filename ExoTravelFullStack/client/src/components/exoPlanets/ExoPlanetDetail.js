// Imports
import React, { useState, useEffect, useCallback } from "react";
import { getExoPlanetById } from "../../modules/ExoPlanetManager";
import { useParams, useNavigate } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import { addLog } from "../../modules/LogManager";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpaceShuttle } from "@fortawesome/free-solid-svg-icons";
import { getUserByFirebaseId } from '../../modules/AuthManager';
import firebase from "firebase/app";
import Rating from "@mui/material/Rating";
import "./ExoPlanetDetail.css";

// Exo-Planet details page
export const ExoPlanetDetail = (isLoggedIn) => {
  // React-Router-DOM uses
  const navigate = useNavigate();
  const { exoPlanetId } = useParams();
  const [fireId, setFireId] = useState([]);
console.log(fireId)


//   // Get user
// //   const currentUser = JSON.parse(sessionStorage.getItem("exoTravel_user"));
  const getMeFire = useCallback(()=>{
    try{
        var fireBaseId = firebase.auth().currentUser.uid;

    }
    
    catch(e){
        console.log(e.message)
    }finally{
        getUserByFirebaseId(fireBaseId).then(setFireId)
    }
    
    
},[fireId])

  
  useEffect( ()  => {
    getMeFire()
  }, []);
  // Gets all the logs by user for Home page

  // State setState
  const [isLoading, setIsLoading] = useState(false);
  const [exoPlanet, setExoPlanet] = useState({
    name: "",
    mass: "",
    radius: "",
    eqTemp: "",
    orbit: "",
    lightYears: "",
    rating: "",
  });
  const [log, setLog] = useState({
    departureDate: "",
    returnDate: "",
    exoPlanetId: Number(exoPlanetId),
    reviewId: 0,
    mode: 0,
  });

  // Formatting for all the dates from epoch time to readable date
  const formattedDepartureDate = log?.departureDate ? epochDateConverter(log.departureDate, "yyyy-MM-dd") : "";
  const formattedReturnDate = log?.returnDate ? epochDateConverter(log.returnDate, "yyyy-MM-dd") : "";

  // When a departureDate date is chosen, it gets set in epoch time in itineraries
  const handleControlleddepartureDateChange = (i) => {
    const isDepartureDate = i.target.id === "departureDate";
    let epochDepartureDate = "";
    if (i.target.id === "departureDate") {
      epochDepartureDate = new Date(i.target.value).getTime() / 1000;
    }
    const newLog = { ...log };
    let selectedVal = isDepartureDate ? epochDepartureDate : i.target.value;

    newLog[i.target.id] = selectedVal;
    setLog(newLog);
  };

  // When a returnDate date is chosen, it gets set in epoch time in itineraries
  const handleControlledreturnDateChange = (i) => {
    const isReturnDate = i.target.id === "returnDate";
    let epochReturnDate = "";
    if (i.target.id === "returnDate") {
      epochReturnDate = new Date(i.target.value).getTime() / 1000;
    }
    const newLog = { ...log };
    let selectedVal = isReturnDate ? epochReturnDate : i.target.value;

    newLog[i.target.id] = selectedVal;
    setLog(newLog);
  };

  // When all fields have been filled out and save is clicked, adds the Log and navigates to the Log list
  const handleClickSaveEvent = (i) => {
    i.preventDefault();
    if (log.departureDate !== "" && log.returnDate !== "" && log.mode !== "") {
      setIsLoading(true);
      console.log(log)
      addLog(log).then(() => navigate("/logs"));
    } else {
      window.alert("Complete Each Field");
    }
  };

  // Handles which mode of transportation they chose and sets it in itineraries
  const handleModeChange1 = (i) => {
    const newLog = { ...log };
    let selectedVal = i ? 0 : "Ion-Drive";
    newLog.mode = selectedVal;
    setLog(newLog);
  };
  const handleModeChange2 = (i) => {
    const newLog = { ...log };
    let selectedVal = i ? 0 : "Warp-Drive";
    newLog.mode = selectedVal;
    setLog(newLog);
  };
  const handleModeChange3 = (i) => {
    const newLog = { ...log };
    let selectedVal = i ? 0 : "Wormhole-Drive";
    newLog.mode = selectedVal;
    setLog(newLog);
  };

  // Sets the details page by the Exo-Planet chosen
  useEffect(() => {
    getExoPlanetById(exoPlanetId).then((exoPlanet) => {
      setExoPlanet(exoPlanet);
    });
  }, [exoPlanetId]);

  // Details info being sent to the DOM
  return (
    <div className="exoPlanetContainer">
      <div className="exoPlanet-pic-name-details">
      <div className="exoPlanet-img">
      <h2 className="exoPlanet-title">{exoPlanet.name}</h2>
        <img className="exoPlanet-pic" src={`/Images/${exoPlanet.name}.jpg`} />
      </div>
      <section className="exoPlanet">
        <div className="exoPlanet-info">
          <div className="exoPlanet__mass">
            <span className="detailsLabel">Ratio to Earth's Mass </span>
            <span className="exoPlanet-mass-label">1 : {exoPlanet.mass}</span>
          </div>
          <div className="exoPlanet__radius">
            <span className="detailsLabel">Ratio to Earth's Radius </span> <span className="exoPlanet-radius-label">1 : {exoPlanet.radius}</span>
          </div>
          <div className="exoPlanet__eqTemp">
            <span className="detailsLabel">Ratio to Earth's Temperature </span>
            <span className="exoPlanet-eqTemp-label">1 : {exoPlanet.eqTemp}</span>
          </div>
          <div className="exoPlanet__orbit">
            <span className="detailsLabel">Days to Orbit It's Star </span> <span className="exoPlanet-orbit-label">{exoPlanet.orbit} days</span>
          </div>
          <div className="exoPlanet__lightYears">
            <span className="detailsLabel">Light-Years Away </span>
            <span className="exoPlanet-lightYears-label">{exoPlanet.lightYears} Light-Years</span>
          </div>
        </div>
        <div className="card-exoPlanet-starRating">
          <Rating style={{ color: "#f4100f" }} value={+exoPlanet.rating} readOnly />{" "}
        </div>
      </section>
      </div>
      <div className="exoPlanet-detail">
        <span className="detailsLabel"> </span> {exoPlanet.detail}
      </div>
      <div className="detailsContainer">
        <div className="exoPlanet__fields">
          <label htmlFor="departureDate">Departure Date: </label>
          <input type="date" id="departureDate" onChange={handleControlleddepartureDateChange} required className="form-control departureDate " placeholder="exoPlanet departureDate" value={formattedDepartureDate} />
        </div>
        <div className="exoPlanet__fields">
          <label htmlFor="returnDate">Return Date: </label>
          <input type="date" id="returnDate" onChange={handleControlledreturnDateChange} required className="form-control returnDate " placeholder="exoPlanet returnDate" value={formattedReturnDate} />
        </div>
      </div>
      <div className="mode-buttons">
        {log.mode === "Ion-Drive" ? (
          <button onClick={() => handleModeChange1(log.mode)} className="ion-select">
            {" "}
            Ion-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        ) : (
          <button onClick={() => handleModeChange1(log.mode)} className="ion-not-select">
            {" "}
            Ion-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        )}
        {log.mode === "Warp-Drive" ? (
          <button onClick={() => handleModeChange2(log.mode)} className="warp-btn">
            {" "}
            Warp-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        ) : (
          <button onClick={() => handleModeChange2(log.mode)} className="warp-not-btn">
            {" "}
            Warp-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        )}
        {log.mode === "Wormhole-Drive" ? (
          <button onClick={() => handleModeChange3(log.mode)} className="wormhole-selected">
            {" "}
            Wormhole-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        ) : (
          <button onClick={() => handleModeChange3(log.mode)} className="wormhole-not-selected">
            {" "}
            Wormhole-Drive
            <FontAwesomeIcon icon={faSpaceShuttle} />
          </button>
        )}
      </div>
      <div className="exoPlanet-detail-buttons">
        <button
          type="submit"
          className="submit-Log-button"
          disabled={isLoading}
          onClick={handleClickSaveEvent}
        >
          Save
        </button>
        <button type="button" className="back-button" onClick={() => navigate(`/exoPlanets`)}>
          Back
        </button>
        <button type="button" className="review-button" onClick={() => navigate(`/exoPlanets/${exoPlanetId}/reviews`)}>
          Reviews
        </button>
      </div>
    </div>
  );
};
