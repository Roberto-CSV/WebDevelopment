import React, { useState } from 'react'
import { Form } from 'react-bootstrap'

export function PersonForm({ person, setPerson, handlePost, handleUpdate }) {
    const handleChange = (e) => {
        setPerson({
            ...person,
            [e.target.name] : e.target.value,
        });
    };

    const handleAction = (e) => {
        if(person.id === 0) {
            console.log(person.firstName);
            handlePost(person);
        } else {
            handleUpdate(person.id, person);
        }
    }
    return (
        <Form onSubmit={handleAction}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Id</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Id"
                    onChange={handleChange}
                    value={person.id}
                    readOnly
                />
            </Form.Group>
            <Form.Group
                className="mb-3"
                controlId="exampleForm.ControlTextarea1"
            >
                <Form.Label>First Name</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="First Name"
                    onChange={handleChange}
                    name="firstName"
                    value={person.firstName}
                    required
                />
            </Form.Group>
            <Form.Group
                className="mb-3"
                controlId="exampleForm.ControlTextarea1"
            >
                <Form.Label>Last Name</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Last Name"
                    onChange={handleChange}
                    name="lastName"
                    value={person.lastName}
                    required
                />
            </Form.Group>
            <Form.Group
                className="mb-3"
                controlId="exampleForm.ControlTextarea1"
            >
                <Form.Label>Date Of Birth</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Date Of Birth"
                    onChange={handleChange}
                    name="dateOfBirth"
                    value={person.dateOfBirth}
                    required
                />
            </Form.Group>
            <Form.Group
                className="mb-3"
                controlId="exampleForm.ControlTextarea1"
            >
                <Form.Label>Sex</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Sex"
                    onChange={handleChange}
                    name="sex"
                    value={person.sex}
                    required
                />
            </Form.Group>
            <Form.Group 
                className="mb-3 d-flex"
                controlId="exampleForm.ControlTextarea1"
            >
                <Form.Control
                    type="submit"
                    value="Enviar"
                    className="btn-primary"
                />
                <Form.Control
                    type="reset"
                    value="Limpiar"

                />
            </Form.Group>
        </Form>
    )
}
