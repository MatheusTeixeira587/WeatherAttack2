import React, { Component } from 'react'
import { Redirect } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { showLoaderAction, hideLoaderAction } from '../../../actions';
import { Grid, AppBar } from '@material-ui/core';

class DashboardPage extends Component {

    render() {
        return (
            <Grid>
              <AppBar />
            </Grid>
        )
    }
}

const mapStateToProps = state => ({ 
    loader: state.loaderReducer,
    authorization: state.authorizationReducer
  });
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction,   
    }, dispath)
  
export default connect(mapStateToProps, mapDispatchToProps)(DashboardPage)