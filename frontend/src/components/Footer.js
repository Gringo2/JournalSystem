import React from 'react'
import { Container, Row, Col, Navbar  } from 'react-bootstrap'

function Footer() {
  return (    
      <footer>
        <Navbar bg="info" >
        <Container className='py-3'>
        <Row>
          <Col className='text-white' >
            <Row ><h4>Journal</h4></Row>
            <Row ><h7>Membership</h7></Row><Row ><h7>Privacy Policy</h7></Row><Row><h7>Terms & conditions</h7></Row><Row  ><h7>Help</h7></Row> <Row ><h7>Historical Content</h7></Row><Row ><h7>Accessibility</h7></Row>
          </Col>
          <Col className='text-white'>
            <Row><h4>Browse</h4></Row>
            <Row><h7>Health Sciences</h7></Row><Row><h7>Life Sciences</h7></Row><Row><h7>Materials Science & Engineering</h7></Row><Row><h7>Social Sciences & Humanities</h7></Row>
          </Col>
          <Col className='text-white'>
            <Row><h4>Contact Us</h4></Row>
            <Row><h7>Contact Us</h7></Row>
          </Col>
          <Col className='text-white'>
            <Row ><h4>Opportunities</h4></Row>
            <Row><h7>Advertising</h7></Row><Row><h7>Reprints</h7></Row><Row><h7>Content</h7></Row><Row><h7>Permissions</h7></Row>
          </Col>
        </Row>
        
          <Row className='text-white'>
            <Col className="text-center py-3">Copyright &copy; journal</Col>
          </Row>
        </Container>
        </Navbar>
      </footer>
   
  )
}

export default Footer