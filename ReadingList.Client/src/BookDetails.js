import React from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import useFetch from './useFetch';
import { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const urlServer = 'https://localhost:7138/api/';
const defaultImg =
  'https://demo.publishr.cloud/assets/common/images/edition_placeholder.png';
const BookDetails = () => {
  const [finished, setFinished] = useState(false);
  const [updateImg, setUpdateImg] = useState(false);
  const { name } = useParams();
  const {
    data: bookDetails,
    error,
    isPending,
  } = useFetch(urlServer + 'GetBookBy/' + name);

  const handleUpdateImg = async (e) => {
    const updateImgValue = document.getElementById('inputUpdateImg').value;
    await fetch(urlServer + 'UpdateBookImg/' + name, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(updateImgValue),
    });
  };

  const handleChangeFinished = async (e) => {
    const checkboxFinished =
      document.getElementById('checkboxFinished').checked;
    console.log(checkboxFinished);
    await fetch(urlServer + 'ChangeBookFinished/' + name, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(checkboxFinished),
    });
    setFinished(checkboxFinished);
    console.log(finished);
  };

  const navigate = useNavigate();

  const handleDelete = () => {
    fetch(urlServer + 'DeleteBook/' + name, {
      method: 'DELETE',
    }).then(() => {
      navigate('/');
      //this.props.render();
    });
  };
  return (
    <div className="book-details">
      {isPending && <div>---Loading---</div>}
      {error && <div>{error}</div>}
      {bookDetails && !isPending && (
        <article className="details-grid">
          <img
            src={
              bookDetails.dataFromServer.imgUrl
                ? bookDetails.dataFromServer.imgUrl
                : defaultImg
            }
            alt={name}
            className="imgDetails"
          />
          <div className="detailsContainer">
            <div>
              <h2>{bookDetails.dataFromServer.name}</h2>
              <div>
                <h2>
                  Have you finished?
                  <input
                    className="checkbox"
                    id="checkboxFinished"
                    type="checkbox"
                    checked={finished}
                    onChange={(e) => handleChangeFinished(e)}></input>
                </h2>
                <h2>
                  Do you want to change image Url?
                  <input
                    type="checkbox"
                    className="checkbox"
                    id="checkboxUpdateImg"
                    checked={updateImg}
                    value={updateImg}
                    onChange={(e) => setUpdateImg(e.target.checked)}></input>
                </h2>
                {!updateImg ? null : (
                  <form onSubmit={handleUpdateImg}>
                    <input type="text" id="inputUpdateImg"></input>
                    <Button className="button" onClick={handleUpdateImg}>
                      Change Img
                    </Button>
                  </form>
                )}
              </div>
            </div>
            <Button variant="danger" onClick={handleDelete}>
              Delete
            </Button>
          </div>
        </article>
      )}
      <div></div>
    </div>
  );
};

export default BookDetails;
