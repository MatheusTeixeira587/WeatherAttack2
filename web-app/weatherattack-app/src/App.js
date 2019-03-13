import React, { Component } from 'react';
import { connect } from 'react-redux';
import './App.css';
import { Switch, Route, Redirect } from "react-router-dom";
import LoginPage from './ui/pages/loginPage';
import { Loader } from './ui/components';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { showLoaderAction, hideLoaderAction, setAuthorizedAction } from "./actions/index";

class App extends Component {

  constructor(){
    super()
    this.configureRequestInterceptor()
  }

  configureRequestInterceptor() {
    const self = this
    axios.interceptors.request.use((config) => {
      self.showLoader(true)
      return config
    });

    axios.interceptors.response.use((response) => {
      self.showLoader(false)
      return response;
    }, (error) => {
      if (error.response.status === 401) {
        self.setUnauthorized()
      }
      self.showLoader(false)
      return Promise.reject(error)
    })
  }

  setUnauthorized(){
    this.setState({
      unAuthorized: true
    })
  }

  render() {
    return (
      <div className="App">
        <Loader showLoader={this.props.loader.showLoader}/>
        <Switch>
          <Route path="/" exact component={LoginPage}/>
          <Route path="/404" />
          <Redirect to ="/"/>
        </Switch>
      </div>
    );
  }
}

const mapStateToProps = state => ({ 
  loader: state.loaderReducer 
});

const mapDispatchToProps = dispath =>
bindActionCreators({showLoaderAction, hideLoaderAction, setAuthorizedAction}, dispath)


export default connect(mapStateToProps, mapDispatchToProps)(App);
