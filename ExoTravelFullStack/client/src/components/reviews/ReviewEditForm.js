// Imports
import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { updateReview, getReviewById } from "../../modules/ReviewManager";
import "./ReviewEditForm.css";

// Review Edit Form
export const ReviewEditForm = () => {
  // React-Router-DOM uses
  const { reviewId } = useParams();
  const navigate = useNavigate();

  // State setState
  const [isLoading, setIsLoading] = useState(false);
  const [review, setReview] = useState({
    id: "",
    userProfileId: "",
    exoPlanetId: "",
    createDate: "",
    editDate: "",
    star: "",
    message: "",
  });

  // Handles the changes in fields when user selects field
  const handleFieldChange = (i) => {
    const stateToChange = { ...review };
    stateToChange[i.target.id] = i.target.value;
    setReview(stateToChange);
  };

  // Takes the edits and updates the review
  const updateExistingReview = (i) => {
    setIsLoading(true);

    const editedReview = {
      id: review.id,
      userProfileId: review.userProfileId,
      exoPlanetId: review.exoPlanetId,
      createDate: review.createDate,
      editDate: new Date().getTime() / 1000,
      star: review.star,
      message: review.message,
    };
    console.log(editedReview)
    updateReview(editedReview).then(() => navigate(`/exoPlanets/${editedReview.exoPlanetId}/reviews`));
  };

  // Gets review by id and sets
  useEffect(() => {
    getReviewById(reviewId).then((review) => {
      setReview(review);
      setIsLoading(false);
    });
  }, []);

  // Displays review edit form
  return (
    <>
      <div className="review-inputs">
        <h2 className="review__edit__header">Edit Review</h2>
        <form className="review__edit__form">
          <fieldset className="review-edit-fields">
            <div className="review-edit-message">
              <label htmlFor="message">Review:</label>
              <textarea type="text" id="message" onChange={handleFieldChange} required className="form-control-message" placeholder="Review" value={review.message} />
            </div>
          </fieldset>
          <fieldset className="review-edit-fields">
            <div className="review-edit-stars">
              <label htmlFor="star">Number of Stars:</label>
              <input type="text" max='5' id="star" onChange={handleFieldChange} required className="form-control-star " placeholder="Number of Stars" value={review.star} />
            </div>
          </fieldset>
          <div className="edit-review-save-cancel">
            <button type="button" className="edit-review-save-button" disabled={isLoading} onClick={updateExistingReview}>
              Save
            </button>
            <button type="button" className="edit-review-cancel-button" disabled={isLoading} onClick={() => navigate(`/exoPlanets/${review.exoPlanetId}/reviews`)}>
              Cancel
            </button>
          </div>
        </form>
      </div>
    </>
  );
};
