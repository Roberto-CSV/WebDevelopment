import React, { useState } from 'react';
import { Button, Form  } from 'react-bootstrap';
import { BrowserRouter as Router, Routes, Route, Link  } from 'react-router-dom';


export const Login = () => {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  function validateForm() {
    return email.length > 0 && password.length > 0;
  }

  function handleSubmit(event) {
    event.preventDefault();
  }
  
  return(
    <>
    <h1>Login</h1><div className="Login">
      <Form onSubmit={handleSubmit} style={{border: "2px Silver solid", backgroundColor: "rgba(225,225,225,0.4)" }}>
        <Form.Group className="m-5" controlId="email">
          <Form.Label>Email</Form.Label>
          <Form.Control   
            style={{width: 400, textAlign: "center", display: "block", margin: "auto"}}
            size="sm"        
            autoFocus
            type="email"
            value={email}            
            onChange={(e) => setEmail(e.target.value)} />
        </Form.Group>
        <Form.Group  className="m-3" controlId="password">
          <Form.Label>Password</Form.Label>
          <Form.Control
          style={{width: 400, textAlign: "center", display: "block", margin: "auto"}}
            size="sm"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)} />
        </Form.Group>
        <Button 
        className="m-3" 
        block="true" 
        size="lg" 
        type="submit" 
        disabled={!validateForm()}
        onClick={e => window.location.href='/User'}>
          <strong>Go</strong>
        </Button>
      </Form>
    </div>
    </>
  );
}


