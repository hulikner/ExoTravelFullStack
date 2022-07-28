import { getToken } from "./AuthManager";
const apiUrl = "/api/reviews"

  export const getAllReviews = () => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else {
          throw new Error("An unknown error occurred while trying to get the reviews.");
        }
      });
    });
  };
  
  export const getReviewsByExoPlanet = (id) => {
    return getToken().then((token) => {
      return fetch(`${apiUrl}/GetAllReviewsByExoPlanet/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else {
          throw new Error("An unknown error occurred while trying to get the reviews.");
        }
      });
    });
  };
  
  export const getReviewById = (id) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An error occurred retrieving review");
            }
        });
    });
  };
  
  export const addReview = (review) => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify(review),
      }).then((resp) => {
        if (resp.ok) {
          return resp.json();
        } else if (resp.status === 401) {
          throw new Error("Unauthorized");
        } else {
          throw new Error("An unknown error occurred while trying to save a new Review.");
        }
      });
    });
  };
  
  export const updateReview = (review) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${review.id}`, {
            method: "PUT",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(review),
        })
    });
  };
  
  export const deleteReview = (id) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${id}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
    });
  };