const apiUrl = "/api/receipts"


export const getAllReceipts = () => {
    return fetch(`${apiUrl}?_expand=exoPlanet&_expand=user&_sort=return&_order=desc`)
    .then(res => res.json())
}

export const getReceiptById = (id) => {
    return fetch(`${apiUrl}/${id}?_expand=exoPlanet&_expand=user&_expand=log`)
    .then(res => res.json())
}

export const deleteReceipt = id => {
    return fetch(`${apiUrl}/${id}`, {
        method: "DELETE"
    }).then(res => res.json())
}

export const updateReceipt  = (editedReceipt) => {
    return fetch(`${apiUrl}/${editedReceipt.id}`, {
      method: "PATCH",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(editedReceipt)
    }).then(data => data.json());
  }

  export const addReceipt = newReceipt => {
    return fetch(`${apiUrl}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newReceipt)
    }).then(res => res.json())
  }

  export const getReceiptByLogId = (id) => {
    return fetch(`${apiUrl}?_expand=exoPlanet&_expand=user&_expand=log&logId=${id}`)
    .then(res => res.json())
}
  export const getReceiptByUserId = (id) => {
    return fetch(`${apiUrl}?_expand=exoPlanet&_expand=user&_expand=log&userId=${id}`)
    .then(res => res.json())
}