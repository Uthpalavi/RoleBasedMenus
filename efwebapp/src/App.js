import logo from './logo.svg';
import './App.css';

import {Home} from './components/Home';
import {Login} from './components/Login';

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       Uthpalavi Dias - EF Role Based Menu
     </h3>

     {/* <Navigation/> */}

     <Switch>
       <Route path='/' component={Login} exact/>
       {/* <Route path='/department' component={Department}/>
       <Route path='/employee' component={Employee}/> */}
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
