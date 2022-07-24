// Imports
import React from "react";
import { Link } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import "./LogCard.css";

// log Card
export const LogCard = ({ log }) => {
  // Formats dates from epoch time to a readable date
  const formattedDepartureDate = log?.departureDate && epochDateConverter(log.departureDate, "eee. MMM do");
  const formattedReturnDate = log?.returnDate && epochDateConverter(log.returnDate, "eee. MMM do");

  // Card info sent to DOM
  return (
    <Link className="log-card-link" to={`/logs/${log.id}`}>
      <div className="log-card-content">
        <div className="log-card-img">
          <img className="log-image" src={`./Images/${log.exoPlanet.name}.jpg`} />
          <p className="log-image-title">{log.exoPlanet.name}</p>
        </div>
        <div className="log-card-info">
          <span className="log-card">
            First Name: <span className="log-card-data">{log.userProfile.firstName}</span>
          </span>
          <br />
          <span className="log-card">
            Last Name: <span className="log-card-data">{log.userProfile.lastName}</span>
          </span>
          <br />
          <span className="log-card">
            Departure Date: <span className="log-card-data">{formattedDepartureDate}</span>
          </span>
          <br />
          <span className="log-card">
            Return Date: <span className="log-card-data">{formattedReturnDate}</span>
          </span>
          <br />
          <span className="log-card">
            Travel Mode: <span className="log-card-data">{log.mode}</span>
          </span>
          <br />
        </div>
      </div>
    </Link>
  );
};
