import Navbar from './Navbar';
import HomeContainer from './HomeContainer';
import Create from './Create';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BookDetails from './BookDetails';
import NotFound from './NotFound';

function App() {
  return (
    <Router>
      <div className="App">
        <Navbar />
        <div className="content">
          <Routes>
            <Route exact path="/" element={<HomeContainer />} />
            <Route exact path="/create" element={<Create />} />
            <Route exact path="/books/:name" element={<BookDetails />} />
            <Route path="*" element={<NotFound />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
