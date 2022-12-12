import { Link } from 'react-router-dom'

const Navbar = () => {
  return (
    <nav className="navbar">
      <h1>List of my Books</h1>
      <div className="links">
        <Link to="/">Home</Link>
        <Link to="/create" style={{ 
          color: 'white', 
          backgroundColor: '#3554f1',
          borderRadius: '8px' 
        }}>Add Book</Link>
      </div>
    </nav>
  );
}
 
export default Navbar;