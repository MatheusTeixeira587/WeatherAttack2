import React, { Component } from 'react'
import { Grid, withStyles } from '@material-ui/core';
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { UserCard, PlayerProfile } from '../';
import { showLoaderAction, hideLoaderAction } from '../../../actions';

const styles = {
    dashboardContentWrapper: {
        flex: 1,
        display: 'flex',
        maxWidth: '100%',
        alignItems: 'start',
        flexWrap: 'wrap',
        margin: 10,
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
    },
    profileWrapper: {
        margin: 10,
        flex: 1
    }
}

class DashboardContentComponent extends Component {

    constructor(props) {
        super(props)
        this.renderOnlinePlayers = this.renderOnlinePlayers.bind(this);
        this.renderUserProfile = this.renderUserProfile.bind(this);
    }
    
    renderOnlinePlayers() {
        return this.props.challenge.loggedUsers.map((i, k) => {
            return <UserCard user={i} key={k}/>
        })
    }

    renderUserProfile() {
        return (
            <PlayerProfile 
                user={
                    {
                        username: this.props.login.username,
                    }
                }

                character={this.props.character}
            />
        )
    }

    render() {

        const { classes } = this.props;

        return (
            <div>
                <Grid className={classes.profileWrapper}>
                    {
                        this.renderUserProfile()
                    }
                </Grid>
                <Grid className={classes.dashboardContentWrapper}>
                    {
                        this.renderOnlinePlayers()
                    }
                </Grid>  
            </div>
        )
  }
}

const mapStateToProps = state => ({ 
    loader: state.loaderReducer,
    login: state.loginReducer,
    challenge: state.challengeReducer,
    character: state.characterReducer
  });
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(DashboardContentComponent));