import React, { Component } from 'react';
import './App.css';
import { Switch, Route } from "react-router-dom";

class App extends Component {

  render() {
    return (
      <div className="App">
        <Switch>
          <Route path="/" exact/>
          <Route path="/404" />
        </Switch>
      </div>
    );
  }
}

export default App;
