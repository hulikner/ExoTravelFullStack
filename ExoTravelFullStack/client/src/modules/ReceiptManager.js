import { getToken } from "./AuthManager";
const apiUrl = "/api/receipts"


export const getAllReceipts = () => {
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
				throw new Error("An unknown error occurred while trying to get the Receipts.");
			}
		});
	});
};

export const getAllReceiptsByUserId = () => {
	return getToken().then((token) => {
		return fetch(`${apiUrl}/GetAllReceiptsByUserId`, {
			method: "GET",
			headers: {
				Authorization: `Bearer ${token}`,
			},
		}).then((resp) => {
			if (resp.ok) {
				return resp.json();
			} else {
				throw new Error("An unknown error occurred while trying to get the Receipts.");
			}
		});
	});
};

export const getReceiptById = (id) => {
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
            throw new Error("An error occurred retrieving Receipt");
          }
      });
  });
};

export const getReceiptByLogId = (id) => {
  return getToken().then((token) => {
      return fetch(`${apiUrl}/GetReceiptByLogId/${id}`, {
          method: "GET",
          headers: {
              Authorization: `Bearer ${token}`,
          },
      }).then((resp) => {
          if (resp.ok) {
              return resp.json();
          } else {
            throw new Error("An error occurred retrieving Receipt");
          }
      });
  });
};

export const addReceipt = (receipt) => {
	return getToken().then((token) => {
		return fetch(apiUrl, {
			method: "POST",
			headers: {
				Authorization: `Bearer ${token}`,
				"Content-Type": "application/json",
			},
			body: JSON.stringify(receipt),
		}).then((resp) => {
			if (resp.ok) {
				return resp.json();
			} else if (resp.status === 401) {
				throw new Error("Unauthorized");
			} else {
				throw new Error("An unknown error occurred while trying to save a new receipt.");
			}
		});
	});
};

export const editReceipt = (receipt) => {
  return getToken().then((token) => {
      return fetch(`${apiUrl}/${receipt.id}`, {
          method: "PUT",
          headers: {
              Authorization: `Bearer ${token}`,
              "Content-Type": "application/json",
          },
          body: JSON.stringify(receipt),
      }).then((resp) => {
          if (resp.ok) {
              return resp.json();
          } else if (resp.status === 401) {
              throw new Error("Unauthorized");
          } else {
              throw new Error(
                  "An unknown error occurred while trying to save changes to category."
              );
          }
      });
  });
};


export const deleteReceipt = (id) => {
  return getToken().then((token) => {
      return fetch(`${apiUrl}/${id}`, {
          method: "DELETE",
          headers: {
              Authorization: `Bearer ${token}`,
          },
      });
  });
};


  
  export const getReceiptByUserId = (id) => {
    return fetch(`${apiUrl}?_expand=exoPlanet&_expand=user&_expand=log&userId=${id}`)
    .then(res => res.json())
}