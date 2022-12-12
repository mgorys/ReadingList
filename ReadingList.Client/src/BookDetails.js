import React from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import useFetch from './useFetch';
import { useState , useEffect } from 'react';

const defaultImg = 
'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png'
  const BookDetails = () => {
  const [finished, setFinished] = useState(false);
  const [updateImg, setUpdateImg] = useState(false);
  const [priority, setPriority] =useState(false);
  const { name } = useParams();
  const { data : bookDetails , error , isPending } = 
      useFetch('https://localhost:7138/api/GetBookBy/'+ name);


    useEffect(() => {
      if(bookDetails.dataFromServer !== undefined && !isPending)
      {
        document.getElementById("checkboxFinished").checked = bookDetails.dataFromServer.finished;
        document.getElementById("dropdownPriority").value = bookDetails.dataFromServer.priority;
      }
  },[]);

  const handleDropdownPriority = (e)=>{
    setPriority(e.target.value)
    handleChangeDropdownPriority()
  }
  const handleTick = (e)=>{
    setFinished(e.target.checked)
    handleChangeFinished()
  }
  const handleUpdateImg = () =>{
    const updateImgValue = document.getElementById("inputUpdateImg").value;
    fetch('https://localhost:7138/api/UpdateBookImg/'+ name,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(updateImgValue)
    })
  }
  const handleChangeDropdownPriority =()=>{
    const dropdownPriority = document.getElementById("dropdownPriority").value;
    fetch('https://localhost:7138/api/ChangeBookPriority/'+ name,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(dropdownPriority)
    })
  }
  const handleChangeFinished =()=>{
    const checkboxFinished = document.getElementById("checkboxFinished").checked;
    fetch('https://localhost:7138/api/ChangeBookFinished/'+ name,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(checkboxFinished)
    })
  }
  const navigate = useNavigate();
  const handleDelete =() =>{
    fetch('https://localhost:7138/api/DeleteBook/'+ name,{
      method: 'DELETE'
    }).then (()=>{
      navigate("/");
    })
  }
  return (
    <div className='book-details'>
        { isPending && <div>---Loading---</div>}
        { error && <div>{error}</div>}
        { bookDetails && !isPending && (
            
          <article>
            <div>
              <h2> Finished :
                <input className='checkbox'
                  id="checkboxFinished"
                  type="checkbox"
                  checked={finished}
                  onChange={(e) => handleTick(e)}
                ></input>
              </h2>
              <h2>Priority:  
                <select type="number" id="dropdownPriority"
                  value={priority}
                  onChange={(e) => handleDropdownPriority(e)}>
                  <option value="0">For Now</option>
                  <option value="1">Maybe</option>
                  <option value="2">Later</option>
                </select></h2>
              <h2>{ bookDetails.dataFromServer.name }</h2>
              <img 
                src={bookDetails.dataFromServer.imgUrl ? bookDetails.dataFromServer.imgUrl : defaultImg} 
                alt={ name } 
                width="200"
                height="300"
              />
            <div>
              <h2>Do you want to change image Url?</h2>
              <input type='checkbox' className='checkbox' id='checkboxUpdateImg' 
                checked={updateImg} value={updateImg}
                onChange={(e)=>setUpdateImg(e.target.checked)}></input>
                {!updateImg ? null : 
                  <form onSubmit={handleUpdateImg}>
                    <input type='text' id='inputUpdateImg'></input>
                    <button className='button' onClick={handleUpdateImg}>Change Img</button>
                  </form> }
            </div>
            </div>
            <button onClick={handleDelete}>Delete</button>
          </article>
        )}
        <div>
        </div>
    </div>
  )
}

export default BookDetails