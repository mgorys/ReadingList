import { NavLink } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <h1>List of your Books</h1>
      <div className="links">
        <NavLink to="/">Home</NavLink>
        <NavLink to="/create">
          <Button className="button">Add Book</Button>
        </NavLink>
      </div>
    </nav>
  );
};

export default Navbar;
