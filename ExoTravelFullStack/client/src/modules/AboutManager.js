const apiUrl = "/api/abouts"

export const getAllAbouts = () => {
    return fetch(`${apiUrl}`)
    .then(res => res.json())
}

export const getAboutById = (id) => {
    return fetch(`${apiUrl}/${id}`)
    .then(res => res.json())
}

