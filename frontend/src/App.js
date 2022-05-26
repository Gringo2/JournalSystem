import { Container } from 'react-bootstrap'
import { BrowserRouter as Router, Route  } from 'react-router-dom'
import Header from './components/Header'
import Footer from './components/Footer'
import { Col,Row, Card } from 'react-bootstrap'

import HomeScreen from './screens/HomeScreen'
import DisciplineScreen from './screens/DisciplineScreen'
import Allergies from './screens/Allergies'
import Hospitalizations from './screens/Hospitalizations'
import Injuries from './screens/Injuries'
import Surgeries from './screens/Surgeries'
import fileuploader from './screens/fileuploader'

function App() {
  return (
      <Router> 
        <Header />
        <main className="py-3">
          
          <Route path='/' component={HomeScreen} exact />
          <Container>
          <Route path='/discipline/:id' component={DisciplineScreen} />
          <Route path='/allergies/' component={Allergies} />
          <Route path='/hospitalizations/' component={Hospitalizations} />
          <Route path='/injuries/' component={Injuries} />
          <Route path='/surgeries/' component={Surgeries} />
          <Route path='/fileuploader/' component={fileuploader} />
          </Container>
          
        </main>
        <Footer />
      </Router>
  );
}

export default App;
