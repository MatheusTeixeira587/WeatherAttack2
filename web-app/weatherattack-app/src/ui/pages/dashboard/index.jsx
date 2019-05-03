import React, { Component } from 'react'
import { Redirect } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { showLoaderAction, hideLoaderAction } from '../../../actions';
import { Grid } from '@material-ui/core';

import { AppBarWithMenu } from '../../';


class DashboardPage extends Component {

    constructor(props) {
        super(props)
        this.requiredAuthorization = this.requiredAuthorization.bind(this)
    }

    requiredAuthorization() {
        if (!this.props.authorization.authorized) {
            return <Redirect to='/'/>
        }
    }

    render() {
        return (
            <Grid>
                {this.requiredAuthorization()}
                <AppBarWithMenu 
                />
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
      hideLoaderAction
    }, dispath)
  
export default connect(mapStateToProps, mapDispatchToProps)(DashboardPage)