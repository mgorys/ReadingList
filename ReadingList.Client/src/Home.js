import BookList from "./BookList";
import useFetch from "./useFetch";

const Home = () => {
  const { data: books, isPending, error} = 
  useFetch('https://localhost:7138/api/GetBooks')
  return (
    <div className="home">
      {error && <div>{ error }</div>}
      { isPending && <div>---Loading---</div>}
      {books && <BookList books={books} name="All Books" isPending={isPending}/>}
    </div>
  );
}
 
export default Home;
