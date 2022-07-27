import { getToken } from "./AuthManager";

const apiUrl = "/api/reviews"


export const getReviewsByExoPlanet = (id) => {
    return fetch(`${apiUrl}/GetAllReviewsByExoPlanet/${id}`)
    .then(res => res.json())
}

export const getReviewById = (id) => {
    return fetch(`${apiUrl}/${id}?_expand=exoPlanet&_expand=user`)
    .then(res => res.json())
}

export const deleteReview = id => {
    return fetch(`${apiUrl}/${id}`, {
        method: "DELETE"
    }).then(res => res.json())
}

export const updateReview  = (editedReview) => {
    return fetch(`${apiUrl}/${editedReview.id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(editedReview)
    });
  }

  export const addReview = (newReview) => {
    return fetch(`${apiUrl}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newReview)
    }).then(res => res.json())
  }