import React, { Component } from 'react'
import { connect } from 'redux'
import { bindActionCreators } from 'react-redux'
import { showLoaderAction, hideLoaderAction } from '../../../actions';
import { Grid } from '@material-ui/core';

class DashboardPage extends Component {

    render() {
        return (
            <Grid>

            </Grid>
        )
    }
}

const mapStateToProps = state => ({ 
    loader: state.loaderReducer,
  });
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction,   
    }, dispath)
  
export default connect(mapStateToProps, mapDispatchToProps)(DashboardPage)