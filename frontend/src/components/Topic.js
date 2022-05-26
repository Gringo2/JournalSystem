import React from 'react'

import { Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'

function Topic({topic}) {
 
    return (
    
      <Link to={`/topics/${topic._id}`}>
           {topic.name}
      </Link>
  
)


  
}

export default Topic