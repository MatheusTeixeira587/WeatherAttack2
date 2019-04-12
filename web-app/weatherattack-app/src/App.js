import './App.css';
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Switch, Route, Redirect } from "react-router-dom";
import { bindActionCreators } from 'redux';

import { Loader, WeatherCard } from './ui/components';
import { showLoaderAction, hideLoaderAction, setUnauthorizedAction, addNotificationAction, removeNotificationAction } from "./actions/index";

import { Snackbar } from '@material-ui/core';
import axios from 'axios';

import SnackbarContentWrapper from './ui/components/snackbar';
import LoginPage from './ui/pages/loginPage';

class App extends Component {

  constructor(props){
    super(props)

    this.configureRequestInterceptor();
    this.renderNotifications = this.renderNotifications.bind(this);
    this.handleNotifications = this.handleNotifications.bind(this);
  }

  configureRequestInterceptor() {
    const self = this
    axios.interceptors.request.use((config) => {
      self.props.showLoaderAction()
      return config
    });

    axios.interceptors.response.use((response) => {
      self.props.hideLoaderAction()
      return response;
    }, (error) => {
      if (!!error.response) {

        if(error.response.status === 401) {
          self.props.setUnauthorizedAction()
        }

        if(error.response.data.notifications.length) {
          this.handleNotifications(error.response.data.notifications)
        }
        
      }

      self.props.hideLoaderAction()

      return Promise.reject(error)
    })
  }

  handleNotifications(notifications) {
    this.props.addNotificationAction(notifications)

    setTimeout(() => {
      this.props.removeNotificationAction(notifications)
    }, 4000);

  }

  renderNotifications() {
    if(!!this.props.notification && this.props.notification.notifications.length) {
      return this.props.notification.notifications.map((n, k) => {
        return (
          <Snackbar
            id={k}
            open={true}
            anchorOrigin={{vertical: 'top', horizontal: 'right'}}
          >  
            <SnackbarContentWrapper
              variant='error'
              message={n.message}
            />
          </Snackbar>
        )
      })
    }
  }

  render() {
    console.log(this.props)
    return (
      <div className="App">    
        <WeatherCard/> 
        <Loader showLoader={this.props.loader.showLoader}/>
        {
            this.renderNotifications()
        }  
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
  loader: state.loaderReducer,
  notification: state.notificationReducer
});

const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction, 
      setUnauthorizedAction, 
      addNotificationAction, 
      removeNotificationAction
    }, dispath)

export default connect(mapStateToProps, mapDispatchToProps)(App);