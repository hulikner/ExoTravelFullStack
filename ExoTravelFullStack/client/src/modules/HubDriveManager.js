const apiUrl = "/api/hubDrives"

export const getAllHubDrives = () => {
    return fetch(`${apiUrl}`)
    .then(res => res.json())
}

export const getHubDriveById = (id) => {
    return fetch(`${apiUrl}/${id}`)
    .then(res => res.json())
}