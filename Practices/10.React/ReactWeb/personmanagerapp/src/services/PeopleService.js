const apiUrl = "https://localhost:5001/api/v1/People";


export function getAll() {
    return (
        fetch(apiUrl)
            .then(response => response.json())
    );
}

export function post(person) {
    return fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(person)
    })
}

export function getById(id) {
    return (
        fetch(apiUrl + '/' + id)
            .then(response => response.json())
    );
}

export function remove(id) {
    return fetch(apiUrl + '/' + id, {
        method: 'DELETE'
    });
}

export function put(id, person) {
    return fetch(apiUrl + '/' + id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(person)
    })
}

