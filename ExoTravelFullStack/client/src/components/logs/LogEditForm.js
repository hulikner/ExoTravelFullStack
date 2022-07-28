// Imports
import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { updateLog, getLogById } from "../../modules/LogManager";
import { epochDateConverter } from "../util/epochDateConverter";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpaceShuttle } from "@fortawesome/free-solid-svg-icons";
import "./LogEditForm.css";

export const LogEditForm = () => {
  // React-Router-DOM uses
  const navigate = useNavigate();
  const { logId } = useParams();

  // State setState
  const [isLoading, setIsLoading] = useState(false);
  const [log, setLog] = useState({
    id: "",
    userProfileId: "",
    exoPlanetId: "",
    departureDate: "",
    returnDate: "",
    reviewId: "",
    mode: "",
  });

  // Formats epoch date to readable date
  const formatteddepartureDateDate = log?.departureDate ? epochDateConverter(log?.departureDate, "yyy-MM-dd") : "";
  const formattedreturnDateDate = log?.returnDate ? epochDateConverter(log?.returnDate, "yyy-MM-dd") : "";

  // Handles change of fields in the edit form
  const handleFieldChange = (i) => {
    const isDate = i.target.id === "departureDate" || "returnDate";
    let epochDate = "";

    if (isDate) {
      epochDate = new Date(i.target.value).getTime() / 1000;
    }

    const stateToChange = { ...log };
    stateToChange[i.target.id] = isDate ? epochDate : i.target.value;
    setLog(stateToChange);
  };

  // Updates log with new user inputs
  const updateExistingLog = (t) => {
    setIsLoading(true);

    const editedLog = {
      id: +logId,
      userProfileId: log.userProfileId,
      exoPlanetId: log.exoPlanetId,
      departureDate: log.departureDate,
      returnDate: log.returnDate,
      reviewId: log.reviewId,
      mode: log.mode,
    };

    updateLog(editedLog).then(() => navigate("/logs"));
  };

  // Handles the change in mode when user clicks one of the buttons
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

  // Gets the log clicked on and sets it
  useEffect(() => {
    getLogById(logId).then((log) => {
      setLog(log);
      setIsLoading(false);
    });
  }, []);

  // Details and buttons sent to DOM for the user to edit
  return (
    <>
      <div className="log-edit-form">
        <h2 className="edit-log-title">Edit log</h2>
        <div className="editDetails">
          <div className="edit-log-pic">
            <img className="edit-log-img" src={`../../Images/${log.exoPlanet?.name}.jpg`} />
            <span className="edit-log-img-name">{log.exoPlanet?.name}</span>
          </div>
          <div className="edit-detailsContainer">
            <div className="edit-exoPlanet-fields">
              <label htmlFor="departureDate">departure Date: </label>
              <input type="date" id="departureDate" onChange={handleFieldChange} required className="edit-control departureDate " placeholder="exoPlanet departureDate" value={formatteddepartureDateDate} />
            </div>
            <div className="edit-exoPlanet-fields">
              <label htmlFor="returnDate">return Date: </label>
              <input type="date" id="returnDate" onChange={handleFieldChange} required className="edit-control returnDate " placeholder="exoPlanet returnDate" value={formattedreturnDateDate} />
            </div>
          </div>
          <div className="edit-mode-buttons">
            {log.mode === "Ion-Drive" ? (
              <button onClick={() => handleModeChange1(log.mode)} className="edit-ion-selected">
                {" "}
                Ion-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            ) : (
              <button onClick={() => handleModeChange1(log.mode)} className="edit-ion-not-selected">
                {" "}
                Ion-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            )}
            {log.mode === "Warp-Drive" ? (
              <button onClick={() => handleModeChange2(log.mode)} className="edit-warp-selected">
                {" "}
                Warp-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            ) : (
              <button onClick={() => handleModeChange2(log.mode)} className="edit-warp-not-selected">
                {" "}
                Warp-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            )}
            {log.mode === "Wormhole-Drive" ? (
              <button onClick={() => handleModeChange3(log.mode)} className="edit-wormhole-selected">
                {" "}
                Wormhole-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            ) : (
              <button onClick={() => handleModeChange3(log.mode)} className="edit-wormhole-not-selected">
                {" "}
                Wormhole-Drive
                <FontAwesomeIcon icon={faSpaceShuttle} />
              </button>
            )}
          </div>
          <div className="edit-save-cancel">
            <button type="button" className="log-edit-save-button" disabled={isLoading} onClick={updateExistingLog}>
              Save
            </button>
            <button type="button" className="log-edit-cancel-button" disabled={isLoading} onClick={() => navigate("/logs")}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </>
  );
};
