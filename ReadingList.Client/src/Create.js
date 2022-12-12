import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const Create = () => {
  const [name, setName] = useState('');
  const [priorityString, setPriorityString] = useState(0);
  const [finished, setFinished] = useState(false);
  const [imgUrl, setImgUrl] = useState('');
  const [isPending, setIsPending] = useState(false);
  const navigate = useNavigate();



  const handleSubmit = (e) => {
    e.preventDefault();

    const priority = parseInt(priorityString);

    const book = { name , imgUrl , finished , priority };
    setIsPending(true)

    fetch('https://localhost:7138/api/PostBook/', {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(book)
    }).then(() => {
      setIsPending(false);
      navigate('/');
    })
  }

  return (
    <div className="create">
      <h2>Add a New Book</h2>
      <form onSubmit={handleSubmit}>
        <label>Book name:</label>
        <input 
          type="text" 
          required 
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <label>Book Priority:</label>
        <select type="number" 
        required
        value={priorityString}
        onChange={(e) => setPriorityString(e.target.value)}>
        <option value="0">For Now</option>
        <option value="1">Maybe</option>
        <option value="2">Later</option>
          </select>
        <label>Book Finished:</label>
        <input
          className='checkbox' 
          type="checkbox"
          value={finished}
          onChange={(e) => setFinished(e.target.checked)}
        ></input>
        <label>Book Image Url:</label>
        <input 
          type="text" 
          value={imgUrl}
          onChange={(e) => setImgUrl(e.target.value)}
        />
          
        {!isPending ? <button>Add Book</button> : 
        <button disabled>Adding Book</button>}
      </form>
    </div>
  );
}

export default Create