import './App.css';
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Switch, Route, Redirect, withRouter } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { Snackbar } from '@material-ui/core';

import { Loader, SnackBarContentWrapper, LoginPage, Interceptor, DashboardPage } from './ui';
import { startChannelAction, showLoaderAction, hideLoaderAction, addNotificationAction, removeNotificationAction, getLocationAction, assignLocationAction, assignWeatherDataAction } from "./actions";

class App extends Component {

  constructor(props) {
    super(props)
    
    this.renderNotifications = this.renderNotifications.bind(this);
    this.getWeather = this.getWeather.bind(this);
  }

  componentDidMount() {
    this.getWeather();
  }

  getWeather() {
    this.props.getLocationAction();
  }

  renderNotifications() {
    if (!!this.props.notification && this.props.notification.notifications.length) {
      return this.props.notification.notifications.map((n, k) => {
        return (
          <Snackbar
            id={k}
            open={true}
            anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
          >
            <SnackBarContentWrapper
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
        <Interceptor/>
        <Loader showLoader={this.props.loader.showLoader} />
        {
          this.renderNotifications()
        }
        <Switch>
          <Route path="/" exact render={() => <LoginPage getWeather={this.getWeather}/>} />
          <Route path="/dashboard" exact component={DashboardPage} />
          <Route path="/404"/>
          <Redirect to="/"/>
        </Switch>
      </div>
    );
  }
}

const mapStateToProps = state => ({
  loader: state.loaderReducer,
  notification: state.notificationReducer,
  geolocation: state.geolocationReducer,
  challenge: state.challengeReducer,

  login: state.loginReducer,
  character: state.characterReducer
});

const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction,
      hideLoaderAction,
      addNotificationAction,
      removeNotificationAction,
      getLocationAction,
      assignLocationAction,
      assignWeatherDataAction,
      startChannelAction
    }, dispath)

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(App));