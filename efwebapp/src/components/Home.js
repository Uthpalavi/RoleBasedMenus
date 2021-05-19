import React, { Component } from 'react';
import Navigation from '../components/Navigation';

class HomePage extends Component {
  render() {
    return (
      <div className="HomePage">
        <Navigation />
        <h2>Home Page</h2>
      </div>
    );
  }
}

export default HomePage;