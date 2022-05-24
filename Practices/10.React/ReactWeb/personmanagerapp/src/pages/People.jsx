import React, { useEffect, useState } from 'react';
import { Button, Container, Modal } from 'react-bootstrap';
import { PeopleTable } from '../components/PeopleTable';
import { PersonForm } from '../components/PersonForm';
import { getAll } from '../services/PeopleService';
import { post, remove, put } from '../services/PeopleService'

const initialPerson = {
    id: 0,
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    sex: ""
}

export function People() {
    const [people, setPeople] = useState([]);
    const [peopleUpdated, setPeopleUpdated] = useState(false);
    const [show, setShow] = useState(false);
    const [person, setPerson] = useState(initialPerson);
    const handleClose = () => {
        setShow(false)
        setPerson({
            id: 0,
            firstName: "",
            lastName: "",
            dateOfBirth: "",
            sex: ""
        });
    };
    const handleShow = () => setShow(true);

    useEffect(() => {
        getAll()
            .then((data) => {
                setPeople(data)
            });
        setPeopleUpdated(false);
    }, [peopleUpdated]);

    const handlePost = (e) => {
        post(person)
            .then(response => response.text())
            .then(response => console.log(response))
        setPerson(
            {
                id: 0,
                firstName: "",
                lastName: "",
                dateOfBirth: "",
                sex: ""
            }
        );
    };

    const handleRemove = (id) => {
        remove(id)
            .then(response => response.text())
            .then(response => console.log(response))
        setPeopleUpdated(true);
    };

    const handleUpdate = (id, person) => {
        console.log(id);
        console.log("HOLA");
        put(id, person)
            .then(response => response.text())
            .then(response => console.log(response))
    };

    return (
        <Container id="peoplePage">
            <h1 className="text-center">People</h1>
            <Button onClick={handleShow}>Crear</Button>
            <PeopleTable people={people} setPerson={setPerson} handleShow={handleShow} handlePost={handlePost} handleRemove={handleRemove} handleUpdate={handleUpdate} />
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Person</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <PersonForm person={person} setPerson={setPerson} handlePost={handlePost} handleUpdate={handleUpdate}  ></PersonForm>
                </Modal.Body>
            </Modal>
        </Container>
    );
}

