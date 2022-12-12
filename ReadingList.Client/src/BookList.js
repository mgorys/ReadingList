import { Link } from "react-router-dom";

const defaultImg = 
'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png'

function renderSwitch(e) {
  switch(e) {
    case 0:
      return 'For Now';
    case 1:
      return 'Maybe';
    default:
      return 'Later';
  }
}
const BookList = ({ books , name , isPending }) => {
  
  return (
    <div className="book-list">
      <h2>{ name }</h2>
      {!isPending && Array.isArray(books.dataFromServer) ? 
      books.dataFromServer.sort(((a,b)=>a.priority - b.priority))
      .map(book => (
        <div className="book-preview" key={book.orderNumber} >
          <Link to={`/books/${book.name}`}>
          <h2>{ book.name }</h2>
          <h2>Book priority : {renderSwitch(book.priority)}</h2>
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