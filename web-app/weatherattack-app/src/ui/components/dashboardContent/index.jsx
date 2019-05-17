import React, { Component } from 'react'
import { Grid, withStyles } from '@material-ui/core';
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { UserCard } from '../';
import { showLoaderAction, hideLoaderAction } from '../../../actions';


const styles = {
    dashboardContentWrapper: {
        flex: 1,
        display: 'flex',
        maxWidth: '100%',
        alignItems: 'start',
        flexWrap: 'wrap',
        margin: 10,
        justifyContent: 'space-evenly',
        overflowY: 'scroll',
        maxHeight: '40%',
        '&::-webkit-scrollbar': {
            width: 7
        },
        '&::-webkit-scrollbar-thumb': {
            background: '#dbdbdb',
        },
        '&::-webkit-scrollbar-track': {
            background: '#efeded',
        },

    }
}

class DashboardContentComponent extends Component {

    constructor(props) {
        super(props)
        this.renderOnlinePlayers = this.renderOnlinePlayers.bind(this);
    }
    
    renderOnlinePlayers() {
        return this.props.challenge.loggedUsers.map((i, k) => {
            return <UserCard user={i} key={k}/>
        })
    }

    render() {

        const { classes } = this.props;

        return (
        <Grid className={classes.dashboardContentWrapper}>
            {
                this.renderOnlinePlayers()
            }
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

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(DashboardContentComponent));