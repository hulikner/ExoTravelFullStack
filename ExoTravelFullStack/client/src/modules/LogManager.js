import { getToken } from "./AuthManager";
const apiUrl = "/api/logs"

export const getAllLogs = () => {
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
				throw new Error("An unknown error occurred while trying to get the logs.");
			}
		});
	});
};

export const getLogById = (id) => {
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
              throw new Error("An error occurred retrieving log");
          }
      });
  });
};

export const getLogsByUserId = () => {
	return getToken().then((token) => {
		return fetch(`${apiUrl}/GetLogsByUserProfileId`, {
			method: "GET",
			headers: {
				Authorization: `Bearer ${token}`,
			},
		}).then((resp) => {
			if (resp.ok) {
				return resp.json();
			} else {
				throw new Error("An unknown error occurred while trying to get the logs.");
			}
		});
	});
};

export const deleteLog = (id) => {
  return getToken().then((token) => {
      return fetch(`${apiUrl}/${id}`, {
          method: "DELETE",
          headers: {
              Authorization: `Bearer ${token}`,
          },
      });
  });
};

export const updateLog = (log) => {
  return getToken().then((token) => {
      return fetch(`${apiUrl}/${log.id}`, {
          method: "PUT",
          headers: {
              Authorization: `Bearer ${token}`,
              "Content-Type": "application/json",
          },
          body: JSON.stringify(log),
      })
  });
};

export const addLog = (log) => {
	return getToken().then((token) => {
		return fetch(apiUrl, {
			method: "POST",
			headers: {
				Authorization: `Bearer ${token}`,
				"Content-Type": "application/json",
			},
			body: JSON.stringify(log),
		}).then((resp) => {
			if (resp.ok) {
				return resp.json();
			} else if (resp.status === 401) {
				throw new Error("Unauthorized");
			} else {
				throw new Error("An unknown error occurred while trying to save a new log.");
			}
		});
	});
};