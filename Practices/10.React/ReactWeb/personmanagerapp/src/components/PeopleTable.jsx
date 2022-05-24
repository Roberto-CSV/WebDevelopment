import React from 'react';
import {  Table } from 'react-bootstrap';
import { PersonRow } from './PersonRow';

export function PeopleTable({ people, setPerson, handleShow, handlePost, handleRemove, handleUpdate }) {
    return (
        <>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Date Of Birth</th>
                        <th>Sex</th>
                        <th>Opciones</th>
                    </tr>
                </thead>
                <tbody>
                    {people.map((person) => {
                        return <PersonRow key={person.id} person={person} setPerson={setPerson} handleRemove={handleRemove} handleShow={handleShow}></PersonRow>
                    })}
                </tbody>
            </Table>
        </>
    );
}