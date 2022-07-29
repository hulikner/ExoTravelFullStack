import { getToken } from "./AuthManager";

const apiUrl = "/api/exoPlanets"

export const getAllExoPlanets = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get the ExoPlanets.");
            }
        });
    });
};

export const getByLightYearsAsc = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/GetByLightYearAsc`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get the ExoPlanets.");
            }
        });
    });
};

export const getByLightYearsDesc = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/GetByLightYearDesc`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get the ExoPlanets.");
            }
        });
    });
};

export const getByRatingAsc = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/GetByRatingAsc`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get the ExoPlanets.");
            }
        });
    });
};

export const getByRatingDesc = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/GetByRatingDesc`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }).then((resp) => {
            if (resp.ok) {
                return resp.json();
            } else {
                throw new Error("An unknown error occurred while trying to get the ExoPlanets.");
            }
        });
    });
};

export const getExoPlanetById = (id) => {
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
              throw new Error("An error occurred retrieving exoPlanet");
          }
      });
  });
};

export const updateExoPlanet = (exoPlanet) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/${exoPlanet.id}`, {
            method: "PUT",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(exoPlanet),
        })
    });
  };