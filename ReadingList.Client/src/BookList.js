import { Link } from "react-router-dom";
import React from 'react';
import useFetch from "./useFetch";
import { useState } from "react";

const urlServer = 'https://localhost:7138/api/';
const defaultImg = 
'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png'
const BookList = ({ books, name, isPending  }) => {
  
  const handleChangePriorityNumber = async (e,f) =>{
  //e->book.name , f->value
  const updateImgValue = f
  await fetch(urlServer+'MoveBookPriority/'+ e,{
      method: 'PUT',
      headers: { "Content-Type": "application/json" },
      body:JSON.stringify(updateImgValue)
    })
    window.location.reload(false);
  }

  return (
    <div className="book-list">{console.log(books)}
      <h2>{ name }</h2>
      {!isPending && Array.isArray(books.dataFromServer) ? 
      books.dataFromServer.sort(((a,b)=>a.priorityNumber - b.priorityNumber))
      .map(book => (
        <div className="book-preview" key={book.priorityNumber} >
          <button value="up" onClick={(e) => handleChangePriorityNumber(book.name,e.target.value)}>
            Up
          </button>
          <button value="down" onClick={(e) => handleChangePriorityNumber(book.name,e.target.value)}>
            Down
          </button>
          <Link to={`/books/${book.name}`}>
          <h2>{ book.name }</h2>
          <h2>Have i finished? : {book.finished ? "Yes" :"Not yet"}</h2>
        <img src={book.imgUrl ? book.imgUrl : defaultImg}
         alt={book.name} width="200" height="300"/>
          </Link>
        </div>
      )) : <h2>---Loading---</h2>}
    </div>
  );
}
 
export default BookList;