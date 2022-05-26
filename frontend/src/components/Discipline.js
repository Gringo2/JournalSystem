import React from 'react'
import { Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'

function Discipline({discipline}) {
  return (
    <Card className="my-3 p-3 rounded" >
        <Link to={`/discipline/${discipline._id}` } className='text-info'>
            <h3>{discipline.name}</h3>
        </Link>
        
    </Card>
  )
}
 
export default Discipline