import React, { Component } from 'react'
import { Redirect } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { showLoaderAction, hideLoaderAction } from '../../../actions';
import { Grid, withStyles } from '@material-ui/core';

import { AppBarWithMenu, DashboardContent } from '../../';

const styles = {
    page: {
        height: '100%',
    }
}

class DashboardPage extends Component {

    constructor(props) {
        super(props)
        this.requiredAuthorization = this.requiredAuthorization.bind(this)
    }

    requiredAuthorization() {
        if (!this.props.login.token) {
            return <Redirect to='/'/>
        }
    }

    render() {
        const { classes } = this.props
        return (
            <Grid className={classes.page}
            >
                {this.requiredAuthorization()}
                <AppBarWithMenu 
                />
                <DashboardContent>
                    <span>
                    </span>
                </DashboardContent>
            </Grid>     
        )
    }
}

const mapStateToProps = state => ({ 
    loader: state.loaderReducer,
    login: state.loginReducer,
    challenge: state.challengeReducer
  });
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction
    }, dispath)
  
export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(DashboardPage));