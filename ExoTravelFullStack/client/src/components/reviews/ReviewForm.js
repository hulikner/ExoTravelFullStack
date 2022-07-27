// Imports
import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { updateExoPlanet } from "../../modules/ExoPlanetManager";
import { addReview, getReviewsByExoPlanet } from "../../modules/ReviewManager";
import "./ReviewForm.css";

export const defaultReview=(log, exoPlanetId)=>
(
    {
    id: "",
    userProfileId: log.userProfileId,
    createDate: new Date().getTime() / 1000,
    editDate: 0,
    exoPlanetId: Number(exoPlanetId),
    message: "",
    star: "",
}
)
export const ReviewForm = () => {
    // React-Router-DOM use
    const { exoPlanetId } = useParams();
    
    // State setState for all reviews
    const [allReviews, setAllReviews] = useState();
    const [isLoading, setIsLoading] = useState(false);
    const [review, setReview] = useState(defaultReview( exoPlanetId));
    const navigate = useNavigate();

  const getStarTotal = (newStar) => {
    const reviewCount = +allReviews.length + 1;
    let totalStars = +newStar;
    allReviews.map((review) => (totalStars += +review.star));
    return totalStars / reviewCount;
  };


  const handleControlledInputChange = (t) => {
    const newReview = { ...review };
    let selectedVal = t.target.value;
    newReview[t.target.id] = selectedVal;
    setReview(newReview);
  };

  const handleClickSaveEvent = (t) => {
    t.preventDefault();

    if (review.message !== "" && review.star) {
      setIsLoading(true);

      const newStarRating = getStarTotal(review.star);
      const exoPlanetObject = { id: +exoPlanetId, rating: +newStarRating };
      updateExoPlanet(exoPlanetObject)
        .then(addReview(review))
        .then(() => navigate(`/exoPlanets/${+exoPlanetId}/reviews`));
    } else {
      window.alert("Complete Each Field");
    }
  };

  
  useEffect(() => {
    getReviewsByExoPlanet(exoPlanetId).then(setAllReviews);
  }, []);

  // Display review form
  return (
    <>
      <div className="review-entire-form">
        <form className="review-form">
          <h2 className="review-header">Create New Review</h2>
          <div className="review-input-fields">
            <fieldset className="review-fields">
              <label htmlFor="message">Review:</label>
              <textarea
                type="text"
                id="message"
                onChange={handleControlledInputChange}
                rows="10"
                cols="50"
                required
                className="form-control message "
                placeholder="Review message"
                value={review.message}
              />
            </fieldset>
            <fieldset className="review-fields">
              <label htmlFor="star">Number of star:</label>
              <input type="number" min="1" max="5" id="star" onChange={handleControlledInputChange} required className="form-control star" placeholder="star" value={review.star} />
            </fieldset>
          </div>
          <div className="review-form-buttons">
            <button type="submit" className="submit-review-button" disabled={isLoading} onClick={handleClickSaveEvent}>
              Submit
            </button>
            <button type="cancel" className="cancel-review-button" disabled={isLoading} onClick={() => navigate(`/logs`)}>
              Cancel
            </button>
          </div>
        </form>
      </div>{" "}
      <div className="review-form-bottom"></div>
    </>
  );
};
