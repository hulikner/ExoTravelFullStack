
const apiUrl = "/api/exoPlanets"

export const getAllExoPlanets = () => {
    return fetch(`${apiUrl}`)
    .then(res => res.json())
}

export const updateExoPlanet  = (editedPlanet) => {
    return fetch(`${apiUrl}/${editedPlanet.id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(editedPlanet)
    });
  }
  
export const getAllExoPlanetsByLightYearsAsc = () => {
    return fetch(`${apiUrl}/GetAllExoPlanetsByLightYearAsc`)
    .then(res => res.json())
}
export const getAllExoPlanetsByLightYearsDesc = () => {
    return fetch(`${apiUrl}/GetAllExoPlanetsByLightYearDesc`)
    .then(res => res.json())
}
export const getAllExoPlanetsByRatingAsc = () => {
    return fetch(`${apiUrl}/GetAllExoPlanetsByRatingAsc`)
    .then(res => res.json())
}
export const getAllExoPlanetsByRatingDesc = () => {
    return fetch(`${apiUrl}/GetAllExoPlanetsByRatingDesc`)
    .then(res => res.json())
}

export const getExoPlanetById = (id) => {
    return fetch(`${apiUrl}/${id}`)
    .then(res => res.json())
}