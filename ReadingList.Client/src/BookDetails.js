import React from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import useFetch from './useFetch';
import { useState , useEffect } from 'react';

const urlServer = 'https://localhost:7138/api/';
const defaultImg = 
'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png'
  const BookDetails = () => {
  const [finished, setFinished] = useState(false);
  const [updateImg, setUpdateImg] = useState(false);
  const { name } = useParams();
  const { data : bookDetails , error , isPending } = 
      useFetch(urlServer +'GetBookBy/'+ name);


    useEffect(() => {
      if(bookDetails.dataFromServer !== undefined && !isPending)
      {
        document.getElementById("checkboxFinished").checked = bookDetails.dataFromServer.finished;
      }
  },[]);

  const handleTick = (e)=>{
    setFinished(e.target.checked)
    handleChangeFinished()
  }
  const handleUpdateImg = async () =>{
    const updateImgValue = document.getElementById("inputUpdateImg").value;
    await fetch(urlServer+'UpdateBookImg/'+ name,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(updateImgValue)
    })
  }
  const handleChangeFinished =async ()=>{
    const checkboxFinished = document.getElementById("checkboxFinished").checked;
    await fetch(urlServer+'ChangeBookFinished/'+ name,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(checkboxFinished)
    })
  }
  const navigate = useNavigate();
  const handleDelete =() =>{
    fetch(urlServer+'DeleteBook/'+ name,{
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