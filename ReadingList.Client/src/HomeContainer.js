import { useEffect } from 'react';
import BookList from './BookList';
import useFetch from './useFetch';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { get } from './utilities/Ajax';

const urlServer = 'https://localhost:7138/api/';
const HomeContainer = () => {
  const [booksData, setBooksData] = useState([]);
  const { data: books, isPending, error } = useFetch(urlServer + 'GetBooks');
  const navigate = useNavigate();

  useEffect(async () => {
    console.log('i got rerendered');
    let content = await get(urlServer + 'GetBooks');
    setBooksData(content);
    //     if (books !== undefined && books.length > 0) {
    //       setBooksData(books);
    //     }
  }, []);

  const handleChangePriorityNumber = async (e, f) => {
    //e->book.name , f->value
    const updateImgValue = f;
    await fetch(urlServer + 'MoveBookPriority/' + e, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(updateImgValue),
    });
    console.log(booksData);
    let content = await get(urlServer + 'GetBooks');
    console.log(content);
    setBooksData(content);

    //     navigate(0, { replace: true });
  };

  return (
    <div className="home">
      {error && <div>{error}</div>}

      {isPending && <div>---Loading---</div>}

      {books && (
        <BookList
          books={booksData}
          isPending={isPending}
          handleChangePriorityNumber={handleChangePriorityNumber}
        />
      )}
    </div>
  );
};

export default HomeContainer;
