import React from 'react'
import { Container, NavDropdown, Nav, Form, Navbar, FormControl, Button } from 'react-bootstrap'


function Header() {
  return (
    <header>
    <Navbar bg="info" variant="dark" expand="lg" collapseOnSelect>
  <Container fluid>
    <Navbar.Brand href="/"><h3> Journal</h3></Navbar.Brand>
    <Navbar.Toggle aria-controls="navbarScroll" />
    <Navbar.Collapse id="navbarScroll">
      <Nav
        className="me-auto my-2 my-lg-0"
        style={{ maxHeight: '100px' }}
        navbarScroll
      >
        <Nav.Link href="/browse">Browse</Nav.Link>
        
        <NavDropdown title="Resource" id="navbarScrollingDropdown">
          <NavDropdown.Item href="/authors">Authors</NavDropdown.Item>
          <NavDropdown.Item href="/editors">Editors</NavDropdown.Item>
          <NavDropdown.Divider />
          <NavDropdown.Item href="/reviwers">
            Reviewers
          </NavDropdown.Item>
        </NavDropdown>
        <Nav.Link href="/sign in"><i className="fas fa-user"></i> Sign In</Nav.Link>
        <Nav.Link href="#" disabled>
          Link
        </Nav.Link>
      </Nav>
      <Form className="d-flex">
        <FormControl
          type="search"
          placeholder="Search"
          className="me-2"
          aria-label="Search"
        />
        <Button variant="outline-success">Search</Button>
      </Form>
    </Navbar.Collapse>
  </Container>
</Navbar>
    </header>
  )
}

export default Header