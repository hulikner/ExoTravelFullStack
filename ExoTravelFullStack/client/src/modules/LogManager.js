const apiUrl = "/api/logs"


export const getAllLogs = () => {
    return fetch(`${apiUrl}`)
    .then(res => res.json())
}

export const getLogById = (id) => {
    return fetch(`${apiUrl}/${id}`)
    .then(res => res.json())
}
export const getLogsByUserId = (id) => {
    return fetch(`${apiUrl}/GetLogsByUserProfileId/${id}`)
    .then(res => res.json())
}

export const deleteLog = (id) => {
  console.log(id)
    return fetch(`${apiUrl}/${id}`, {
        method: "DELETE"
    }).then(res => res.json())
}

export const updateLog  = (editedLog) => {
    return fetch(`${apiUrl}/${editedLog.id}`, {
      method: "PATCH",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(editedLog)
    }).then(data => data.json());
  }

  export const addLog = newLog => {
    return fetch(`${apiUrl}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newLog)
    }).then(res => res.json())
  }