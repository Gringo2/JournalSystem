import React, { useState, useEffect }  from 'react'
import { useDispatch, useSelector } from 'react-redux'
import{ Link } from 'react-router-dom'
import { Row, Col, Image, ListGroup, Card, Table} from 'react-bootstrap'
import disciplines from '../disciplines'
import topics from '../topics'
import Topic from '../components/Topic'
import { listDisciplineDetails } from '../Actions/disciplineActions'

function DisciplineScreen({ match }) {
  const discipline = disciplines.find((p) => p._id == match.params.id)
  //const dispatch = useDispatch()
  //const desciplineDetails = useSelector(state => state.desciplineDetails)
  //const {loading, error, discipline} = desciplineDetails
 
  //useEffect(() => {
    //  dispatch(listDisciplineDetails(match.params.id))
 //}, [])

  return (
    <div>
        <Link to='/' className='btn btn-light my-3 text-info'> Go Back</Link>
        <Row>
            <Col md={6}>
                <Image src={discipline.image} alt={discipline.name} fluid />
            </Col>
            <Col>
            <ListGroup variant="flush">
               
                <ListGroup.Item>
                    <h3 className='text-info'>{discipline.name}</h3>
                </ListGroup.Item>
                <ListGroup.Item>
                    <h3>{discipline.description}</h3>
                </ListGroup.Item>
            </ListGroup>
            </Col>
        </Row>
        <Row>
           <Col className='py-3'>
              The topics related to this journal include but are not limited to:
           </Col>
        </Row>
        
        
        <Col className='py-3'>
         {topics.map(topic =>(
            <Row key={topic._id} >
                <Topic topic={topic} />
            </Row>
         ))}
            
        </Col>
    
       <Col className="text-center py-3"> <h3 className='text-info'>Upcoming From Journal Publishing</h3></Col>
        <Col className='py-3'>
        <Row>
          <Col><Link to="/data-planet"><h4><i className="fas fa-database text-info"> <Row className='py-3'>Data Planet</Row></i></h4></Link><Row>A universe of data</Row></Col>
          <Col><Link to="/business-cases"><h4><i className="fas fa-briefcase text-info"> <Row className='py-3'>Business Cases</Row></i></h4></Link><Row>Real world cases at your finger tips</Row></Col>
          <Col><Link to="/video"><h4><i class="fa fa-play text-info"> <Row className='py-3'>Video</Row></i></h4></Link><Row>Streaming video collections</Row></Col>
          <Col><Link to="/journal-campus"><h4><i className="fas fa-university text-info"><Row className='py-3'>Journal campus</Row> </i></h4></Link><Row>Online skills and methods courses</Row></Col>
        </Row>
        </Col>
    </div>
  )





}

export default DisciplineScreen