import React, { useState, useEffect} from 'react'
import { useDispatch, useSelector} from 'react-redux'
import { Row,Col,Card, Container, ListGroup } from 'react-bootstrap'
import disciplines from '../disciplines'
import recents from '../recents'


import Discipline from '../components/Discipline'
import Recent from '../components/Recent'
import DisciplineCrousel from '../components/DisciplineCrousel'
import { Link } from 'react-router-dom'
import { listDisciplines } from '../Actions/disciplineActions'

function Homescreen() {
  //const dispatch = useDispatch()
  //const disciplineList = useSelector(state => state.disciplineList)
  //const { error, loading, disciplines } = disciplineList

  //useEffect(() => {
    //  dispatch(listDisciplines())

  //}, [dispatch])

  return (
    <div>
      <Row>
            <Col>
              <Card className="my-4">
                <Card.Img src={'/images/a.jpg'} />
              </Card>
               
            </Col>
        </Row> 
        <Container><h1 className='text-info py-3'>Browse Journals by Discipline</h1></Container>
        
        <DisciplineCrousel/>
        <Container> 
       
       <Row className='py-3'>
         {disciplines.map(discipline =>(
            <Col key={discipline._id} sm={12} md={6} lg={4} xl={3}>
                <Discipline discipline={discipline} />
            </Col>
         ))}
            
        </Row>
        <h3 className='text-info'>Recent Articles</h3> 
        <Row>
         {recents.map(recent =>(
            <Col key={recent._id} sm={12} md={6} lg={4} xl={3}>
                <Recent recent={recent} />
            </Col>
         ))}
            
        </Row>
        
        <Row>
          <Col className="text-center py-3"><h3 className='text-info py-3'>Resources</h3></Col>
        </Row>
        <Row className='px-3'>
          <Col className='py-3 px-3'><Link to="/authors"><h4><i className="fas fa-user text-info px-3"> <Row className='py-3 '>Authors</Row></i></h4></Link></Col>
          <Col className='py-3 px-3'><Link to="/Librarians"><h4><i className="fas fa-university text-info px-3"> <Row className='py-3'>Librarians</Row></i></h4></Link></Col>
          <Col className='py-3 px-3'><Link to="/Editors"><h4><i class="fa fa-edit text-info px-3" > <Row className='py-3'>Editors</Row></i></h4></Link></Col>
          <Col className='py-3 px-3'><Link to="/Societies"><h4><i className="fas fa-users text-info px-3"><Row className='py-3'>Societies</Row> </i></h4></Link></Col>
        </Row>
        <Row>
        
        </Row>
      </Container>  
    </div>
  )
}

export default Homescreen