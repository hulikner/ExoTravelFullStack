// Imports
import React, { useState, useEffect, useCallback } from "react";
import Rating from "@mui/material/Rating";
import { useNavigate } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import { getUserByFirebaseId } from '../../modules/AuthManager';
import firebase from "firebase/app";

// Review Card
export const ReviewCard = ({ review }) => {
  // State setState
  const [isLoading, setIsLoading] = useState(false);
  const [fireId, setFireId] = useState([]);
  // const [isLoggedIn, setIsLoggedIn] = useState(null);
  // useEffect(() => {
  //   onLoginStatusChange(setIsLoggedIn);
  // }, []);
  // console.log(user);
  const getMeFire = useCallback(()=>{
    try{
        var fireBaseId =  firebase.auth().currentUser.uid;

    }
    
    catch(e){
        console.log(e.message)
    }finally{
        getUserByFirebaseId(fireBaseId).then(setFireId)
    }
    
    
 },[])
// // var user  =  getUserByFirebaseId(fireBaseId);

// //   setCurrentUser(getLoggedInUser);
//   // State setState

//   // Gets current users id
  
  useEffect( ()  => {
    getMeFire()
// getUserByFirebaseId(fireId).then(setFireId);
  }, [fireId]);

  // React-Router-DOM use
  const navigate = useNavigate();

  // Formats epoch date to a readable date
  const formattedCreateDate = review?.createDate ? epochDateConverter(review?.createDate, "yyy-MM-dd") : "";
  const formattedEditDate = review?.editDate ? epochDateConverter(review.editDate, "yyy-MM-dd") : "";

  // Gets user id
  // Displays review card
  return (
    <div className="review-card-content">
      <div className="review-card-img">
        <img className="review-pic" src={`../../Images/${review.exoPlanet.name}.jpg`} />
        <span className="review-card-name">{review.exoPlanet.name}</span>
      </div>
      <div className="review-card-details">
        <span className="review-card">
          By: {review.userProfile.firstName} {review.userProfile.lastName}
        </span>
        <br />
        <span className="review-card"> {review.message}</span>
        <br />
        <p className="review-card">
          <Rating style={{ color: "#2f53d8" }} value={+review.star} readOnly />{" "}
        </p>
      </div>
      {review.userProfileId === +fireId.id ? (
        <>
          <button type="button" className="edit-cancel-button" disabled={isLoading} onClick={() => navigate(`/exoPlanets/${review.exoPlanetId}/reviews/${review.id}/edit`)}>
            Edit
          </button>
        </>
      ) : (
        <span></span>
      )}
      <div className="review-card-dates">
        <span className="review-card-time">Created: {formattedCreateDate}</span>
      </div>
      {formattedEditDate != 0 ? (
        <>
          <div className="review-card-dates">
            <span className="review-card-time">Edited: {formattedEditDate}</span>
          </div>
        </>
      ) : (
        <span></span>
      )}
    </div>
  );
};
