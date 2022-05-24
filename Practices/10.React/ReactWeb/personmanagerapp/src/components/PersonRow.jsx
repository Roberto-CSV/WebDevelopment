import React from 'react';
import { Button } from 'react-bootstrap';

export function PersonRow({ person, setPerson, handleRemove, handleShow }) {
    const handleAction = () => {
        setPerson({
            id: parseInt(person.id, 10),
            firstName: person.firstName,
            lastName: person.lastName,
            dateOfBirth: person.dateOfBirth,
            sex: person.sex
        });
        handleShow();
    }
    return (
        <tr key={person.id}>
            <td>{person.id}</td>
            <td>{person.firstName}</td>
            <td>{person.lastName}</td>
            <td>{person.dateOfBirth}</td>
            <td>{person.sex}</td>
            <td>
                <Button onClick={handleAction}>Editar</Button>
                <Button variant="danger" onClick={() => handleRemove(person.id)}>Eliminar</Button>
            </td>
        </tr>
    );
}