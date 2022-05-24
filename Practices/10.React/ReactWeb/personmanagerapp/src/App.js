import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { NavigationBar } from './components/NavigationBar'
import { Home } from './pages/Home';
import { Login } from './pages/Login';
import { People } from './pages/People';
import { NoMatch } from './pages/NoMatch';
import { Layout } from './Layout'

function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar />
        <Layout>
          <Router>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route exact path="Home" element={<Home />} />
              <Route exact path="People" element={<People />} />
              <Route exact path="Login" element={<Login />} />
              <Route element={<NoMatch />} />
            </Routes>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
