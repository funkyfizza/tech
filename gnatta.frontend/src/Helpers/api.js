const BASE_URL = "/api";

export const baseFetch = (url, options = {}) =>
    fetch(BASE_URL + url, { ...options }).then(x => x.headers.get("content-type") === null ? x.text() : x.json());

export const get = (url = {}) => baseFetch(url);
export const del = (url) => baseFetch(url, { method: "DELETE" });
export const post = (url, body) => baseFetch(url, {
    method: "POST",
    headers: {
        "content-type": "application/json",
    },
    body: JSON.stringify(body),
});
