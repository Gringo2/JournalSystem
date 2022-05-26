import React from 'react'
import { Carousel, Image } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import disciplines from '../disciplines'

function DisciplineCrousel() {
  return (
    <Carousel pause='hover' className='bg-info'>
        {disciplines.map(discipline => (
            <Carousel.Item key={discipline._id}>
                <Link to={`/discipline/${discipline._id}`}>
                    <Image src={discipline.image} alt={discipline.name} fluid />
                    <Carousel.Caption className='carousel.caption'>
                        
                        <h4>{discipline.name}</h4>
                    </Carousel.Caption>
                </Link>
            </Carousel.Item>
        ))}
    
    </Carousel>
  )
}

export default DisciplineCrousel