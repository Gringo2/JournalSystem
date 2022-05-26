import React from 'react'
import { Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'

function Recent({recent}) {
  return (
    <Card className="my-3 p-3 rounded " >
        <Link to={`/recent/${recent._id}`} className='text-info px-3'>
            <h5>{recent.name}</h5>
        </Link>
        {recent.description}
    </Card>
    
  )
}

export default Recent