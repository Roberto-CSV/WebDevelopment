import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table, Form  } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

export const People = () => {

  const baseUrl = "https://localhost:5001/api/v1/People";

  const [ data, setData]=useState([]);  

  const getUsers=async()=>{
    await axios.get(baseUrl)
    .then (response=>{
      console.log(response.data);
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  const deleteUser = async() => {
    await axios.delete(baseUrl+"/"+ currentUser.id)
    .then (()=>{
      setData(data.filter(usr=>usr.id!==currentUser.id));
      openCloseModalDelete();
    }).catch(error=>{
      console.log(error);
    })
  }  

  const putUser = async() => {
    await axios.put(baseUrl+"/"+ currentUser.id, currentUser)
    .then (response=>{
      var result = response.data;
      var updatedData = data;
      updatedData.map(usr=>{
        if(usr.id===currentUser.id){
          usr.email = result.email;
          usr.name = result.name;
          usr.username = result.username;
          usr.password = result.password;
        }
      });
    getUsers();
      openCloseModalUpdate();
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    getUsers();
  },[]);

  // Control data
  const [currentUser, setCurrentUser]= useState({
    id: '', 
    firstName: '',
    lastName: '',
    sex: '',
    dateOfBirth: ''
  });

  const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentUser({
      ...currentUser,
      [name]: value
    });
    }

  // Create 
  const [showModalCreate, setShowModalCreate]= useState(false);
  const openCloseModalCreate=()=>{
  setShowModalCreate(!showModalCreate);
  }  

  // Update
const [showModalUpdate, setShowModalUpdate]= useState(false);
const openCloseModalUpdate=()=>{
  setShowModalUpdate(!showModalUpdate);
}

// Details
const [showModalDetails, setShowModalDetails]= useState(false);
const openCloseModalDetails=()=>{
  setShowModalDetails(!showModalDetails);
}
  // Delete
  const [showModalDelete, setShowModalDelete]= useState(false);
  const openCloseModalDelete=()=>{
    setShowModalDelete(!showModalDelete);
  }

  const postUser = async() => {
    delete currentUser.id;
    await axios.post(baseUrl, currentUser)
    .then (response=>{
      getUsers();
      openCloseModalCreate();
    }).catch(error=>{
      console.log(error);
    })
  }

  const selectCurrentUser=(user, action)=>{
    setCurrentUser(user);
    switch (action) {
      case "Edit":
        openCloseModalUpdate();
        break;
      case "Details":
        openCloseModalDetails();
        break;
      case "Delete":
        openCloseModalDelete();
        break; 
      default:
        break;
    }     
    }



  return (
    <Container className="text-center text-md-left">
      {/* Create Modal Save*/}
    <Modal isOpen={showModalCreate} >
      <ModalHeader style={{justifyContent: "center"}}><strong>Create User</strong></ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group className='my-2'>
            <Form.Label>Id:</Form.Label>
            <Form.Control type="email" id="txtEmail" name="id" placeholder="Identification" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group className='my-2'>
            <Form.Label>First Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="firstName" placeholder="Pepito" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group className='my-2'>
            <Form.Label>Last Name:</Form.Label>
            <Form.Control type="text" id="txtUsername" name="lastName" placeholder="Perez" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group className='my-2'>
            <Form.Label>Sex:</Form.Label>
            <Form.Control type="text" id="txtUsername" name="sex" placeholder="M or F" required max={1} onChange={handleChange}/>
          </Form.Group>    
          <Form.Group className='my-2'>
            <Form.Label>Date of Birth:</Form.Label>
            <Form.Control type="date" id="txtUsername" name="dateOfBirth" placeholder="30/1/2000" required onChange={handleChange}/>
          </Form.Group>                  
          
        </Form>
      </ModalBody>
      <ModalFooter style={{justifyContent: "center"}}>
        <Button variant="primary" onClick={()=>postUser()}>Create</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Update */}
<Modal isOpen={showModalUpdate}>
  <ModalHeader>Edit User</ModalHeader>
  <ModalBody>
    <Form>
      <Form.Group>
        <Form.Label>Id:</Form.Label>
        <Form.Control type="text" id="txtId" name="id" readOnly value={currentUser && currentUser.id}/>
      </Form.Group>
      <Form.Group className='my-2'>
            <Form.Label>First Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="firstName" placeholder="First Name" required onChange={handleChange} value={currentUser && currentUser.firstName}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Last Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="lastName" placeholder="Last Name" required onChange={handleChange} value={currentUser && currentUser.lastName}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Sex:</Form.Label>
            <Form.Control type="text" id="txtName" name="sex" placeholder="M o F" required onChange={handleChange} value={currentUser && currentUser.sex}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Birth Of Date:</Form.Label>
            <Form.Control type="date" id="txtName" name="dateOfBirth" placeholder="Date" required onChange={handleChange} value={currentUser && currentUser.dateOfBirth}/>
        </Form.Group>
    </Form>
  </ModalBody>
  <ModalFooter>
    <Button variant="primary" onClick={()=>putUser()}>Save</Button>
    <Button variant="outline-info" onClick={()=>openCloseModalUpdate()}>Back</Button>
  </ModalFooter>
</Modal>
{/* Details */}
<Modal isOpen={showModalDetails}>
  <ModalHeader>Details User</ModalHeader>
  <ModalBody>
    <Form>
      <Form.Group>
        <Form.Label>Id:</Form.Label>
        <Form.Control type="text" id="txtId" name="id" readOnly value={currentUser && currentUser.id}/>
      </Form.Group>
      <Form.Group className='my-2'>
            <Form.Label>First Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="firstName" readOnly value={currentUser && currentUser.firstName}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Last Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="lastName" readOnly value={currentUser && currentUser.lastName}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Sex:</Form.Label>
            <Form.Control type="text" id="txtName" name="sex" readOnly value={currentUser && currentUser.sex}/>
        </Form.Group>
        <Form.Group className='my-2'>
            <Form.Label>Birth Of Date:</Form.Label>
            <Form.Control type="date" id="txtName" name="dateOfBirth" readOnly value={currentUser && currentUser.dateOfBirth}/>
        </Form.Group>
    </Form>
  </ModalBody>
  <ModalFooter>
    <Button variant="outline-info" onClick={()=>openCloseModalDetails()}>Back</Button>
  </ModalFooter>
</Modal>
{/* Delete */}
<Modal isOpen={showModalDelete}>
  <ModalHeader>Are you sure to delete this user?</ModalHeader>
  <ModalBody>
    <Form>
      <Form.Group>
        <Form.Label><b>Id:</b></Form.Label>
        <Form.Label>{currentUser && currentUser.id}</Form.Label><br/>
        <Form.Label><b>First Name:</b></Form.Label>
        <Form.Label>{currentUser && currentUser.firstName}</Form.Label><br/>
        <Form.Label><b>Last Name:</b></Form.Label>
        <Form.Label>{currentUser && currentUser.lastName}</Form.Label><br/>
        <Form.Label><b>Sex:</b></Form.Label>
        <Form.Label>{currentUser && currentUser.sex}</Form.Label><br/>
        <Form.Label><b>Date Of Birth:</b></Form.Label>
        <Form.Label>{currentUser && currentUser.dateOfBirth}</Form.Label><br/>
      </Form.Group>
    </Form>
  </ModalBody>
  <ModalFooter>
    <Button variant="danger" onClick={()=>deleteUser(currentUser.id)}>Delete</Button>
    <Button variant="outline-info" onClick={()=>openCloseModalDelete()}>Back</Button>
  </ModalFooter>
</Modal>
      <h1>People (API)</h1>
      <p>
        <Button className="left" variant="success btn-xl" onClick={()=>openCloseModalCreate()}> <Fas icon={faPlus} /> New Person</Button>
      </p>
      <Table id="UsersTable">
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>sex</th>
                <th>Date of Birth</th>
                <th>Actions</th>
            </tr>
          </thead>
        <tbody>
          {data.map(usr=>(
            <tr key={usr.id}>
              <td>{usr.id}</td>
              <td>{usr.firstName}</td>
              <td>{usr.lastName}</td>
              <td>{usr.sex}</td>
              <td>{usr.dateOfBirth}</td>
              <td >
              <Button variant="primary" onClick={()=>selectCurrentUser(usr, "Edit")}>Edit</Button>{"  "}
              <Button variant="warning" onClick={()=>selectCurrentUser(usr, "Details")}>Details</Button>{"  "}
              <Button variant="danger" onClick={()=>selectCurrentUser(usr, "Delete")}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Container>

    
  );
}