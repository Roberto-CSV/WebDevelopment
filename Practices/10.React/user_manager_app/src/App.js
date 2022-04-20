import logo from './logo.svg';
import './App.css';
import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container, Image, Navbar, Nav } from 'react-bootstrap';
import './components/NavigationBar'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout } from './Layout';
import { NoMatch } from './components/NotFound';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Person } from './components/Users';
import { NavigationBar } from './components/NavigationBar';


function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar />
        <Layout>
          <Router>
            <Routes>
              <Route exact path="/" component={<Home/>} />
              <Route path="/Home" component={<Home/>} />
              <Route path="/Users" element={<Person />} />
              <Route path="/Login" component={<Login/>} />
              <Route component={NoMatch} />
            </Routes>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
