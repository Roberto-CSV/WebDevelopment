import React from 'react';
import PrincipalHomeImg from '../images/PrincipalHomeImg.jpg';
import { Container } from 'react-bootstrap';

export function Home() {
    return (
        <Container id="homePage">
            <h1 className="text-center">Home</h1>
            <Container fluid className="d-flex justify-content-center alig-items-center">
                <img src={PrincipalHomeImg} alt="" />
            </Container>
        </Container>
    );
}