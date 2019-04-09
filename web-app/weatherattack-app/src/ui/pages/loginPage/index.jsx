import React, { Component } from 'react'
import { connect } from 'react-redux'
import { showLoaderAction, hideLoaderAction, changeFieldAction, requestLoginAction, requestRegisterAction, triggerRegisterDisplayAction } from '../../../actions';
import { bindActionCreators } from 'redux';
import { LoginComponent, RegisterComponent } from '../../components';
import { Grid } from '@material-ui/core';
import { createAccountMessage, alreadyHaveAccountMessage } from '../../../constants';

import backgroundImageSvg  from '../../../static/img/background.svg';
import logoSvg from '../../../static/img/logo.svg';

const styles = {
  divStyle: {
    height: '100vh',
    boxShadow: '0 0px 80px rgba(0, 0, 0, 0.7)',
    zIndex: 1,
  },
  background: {
    background: `url('../../..${backgroundImageSvg}')`,
    backgroundSize: 'cover',
    backgroundRepeat: 'no-repeat',
    backgroundPosition: 'center',
    overflow: 'hidden',
  },
  logo: {
    background: `url('../../..${logoSvg}')`,
    backgroundSize:'cover 100%',
    backgroundRepeat:'no-repeat',
    backgroundPosition: 'center',
    height: '100%',
  },
  logoContainer: {
    height: '200px', 
  },
  link: {
    textDecoration: 'underline',
    color: '#666666',
    fontFamily: 'Roboto',
    fontStyle: 'normal',
    lineHeight: 'normal',
    fontSize: '12px',
    textDecorationLine: 'underline',
    cursor: 'pointer',
    position: 'relative',
    border: 'none',
    outline: 'none',
    backgroundColor: 'transparent',
  },
}

class LoginPage extends Component {

  constructor(props) {
    super(props)

    this.renderLoginOrRegisterComponent = this.renderLoginOrRegisterComponent.bind(this);
  }

  renderLoginOrRegisterComponent() {
    if (this.props.login.shouldRenderRegister)
      return (
        <RegisterComponent
          login={this.props.login}
          changeField={this.props.changeFieldAction}
          requestRegisterAction={this.props.requestRegisterAction}
        />
      )

    return (
      <LoginComponent
        login={this.props.login}
        changeField={this.props.changeFieldAction}
        requestLoginAction={this.props.requestLoginAction}
      />
    )
  }
  
  render() {
    return (
      <Grid
        container
        item
        direction="row"
        justify="center"
        lg={12}
        sm={12}
      >
        <Grid
          component="div"
          container
          direction="row"
          alignContent="flex-start"
          alignItems="center"
          justify="center"
          lg={4}
          sm={12}
          item
          style={styles.divStyle}
        >
          <Grid
            component='div'
            item
            lg={12}
            sm={12}
          >
          <Grid
            component='div'
            style={styles.logoContainer}
          >
            <div
              style={styles.logo}
            >
            </div>
          </Grid>
          </Grid>
          {this.renderLoginOrRegisterComponent()}
          <button 
            style={styles.link} 
            onClick={this.props.triggerRegisterDisplayAction}
          >
            {this.props.login.shouldRenderRegister ? alreadyHaveAccountMessage : createAccountMessage}
          </button>
        </Grid>
        <Grid
          item
          lg={8}
          container
          style={styles.background}
        />     
      </Grid>
    )
  }
}

const mapStateToProps = state => ({ 
  loader: state.loaderReducer,
  login: state.loginPageReducer
});

const mapDispatchToProps = dispath =>
bindActionCreators(
  {
    showLoaderAction, 
    hideLoaderAction, 
    changeFieldAction, 
    requestLoginAction, 
    triggerRegisterDisplayAction, 
    requestRegisterAction

  }, dispath)

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage)