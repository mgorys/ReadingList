import React from 'react'
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <div className='not-found'>
        <h2>Not Found</h2>
        <h4>That page cannot be found</h4>
        <Link to="/">Back to Home</Link>    
    </div>
  )
}

export default NotFound