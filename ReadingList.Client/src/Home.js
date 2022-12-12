import BookList from './BookList';
import useFetch from './useFetch';

const urlServer = 'https://localhost:7138/api/';
const Home = () => {
  const { data: books, isPending, error } = useFetch(urlServer + 'GetBooks');

  return (
    <div className="home">
      {error && <div>{error}</div>}

      {isPending && <div>---Loading---</div>}

      {books && <BookList books={books} isPending={isPending} />}
    </div>
  );
};

export default Home;
