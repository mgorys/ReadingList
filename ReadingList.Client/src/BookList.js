import { Link } from 'react-router-dom';
import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowDown, faArrowUp } from '@fortawesome/free-solid-svg-icons';

const defaultImg =
  'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png';
const BookList = ({ books, isPending, handleChangePriorityNumber }) => {
  return (
    <div className="book-list">
      {console.log(books)}
      {!isPending && Array.isArray(books.dataFromServer) ? (
        books.dataFromServer
          .sort((a, b) => a.priorityNumber - b.priorityNumber)
          .map((book) => (
            <div className="book-preview" key={book.priorityNumber}>
              <div className="imgContainer">
                <Link to={`/books/${book.name}`}>
                  <img
                    src={book.imgUrl ? book.imgUrl : defaultImg}
                    alt={book.name}
                    width="200"
                    height="300"
                  />
                </Link>
              </div>
              <div className="container">
                <Link to={`/books/${book.name}`}>
                  <h2>{book.name}</h2>
                </Link>
                <h2>
                  Have you finished? : {book.finished ? 'Yes' : 'Not yet'}
                </h2>
              </div>
              <div className="button-container">
                <Button
                  value="up"
                  variant="outline-primary"
                  onClick={(e) => {
                    handleChangePriorityNumber(book.name, 'up');
                  }}>
                  <FontAwesomeIcon
                    icon={faArrowUp}
                    style={{ color: 'white' }}
                  />
                </Button>
                <Button
                  value="down"
                  variant="outline-primary"
                  onClick={(e) =>
                    handleChangePriorityNumber(book.name, 'down')
                  }>
                  <FontAwesomeIcon
                    icon={faArrowDown}
                    style={{ color: '#fff' }}
                  />
                </Button>
              </div>
            </div>
          ))
      ) : (
        <h2>---Loading---</h2>
      )}
    </div>
  );
};

export default BookList;
