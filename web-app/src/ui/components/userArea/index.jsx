import React, { Component } from 'react';
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { withStyles } from '@material-ui/core/styles'
import { withRouter } from 'react-router-dom'
import { UserTableComponent } from '../';
import { getPagedUsersAction } from '../../../actions';

const styles = ({
    component: {
        width: '90%',
        flex: 1,
        display: 'flex',
        flexDirection: 'column',
        backgroundColor: 'white',
        marginTop: 10,
        bordeRadius: 4
    },
});

class UserArea extends Component {
   
    render() {
        const { classes } = this.props;
        return (
           <div className={classes.component}>
               <div className={classes.content}>
                    <UserTableComponent/>
               </div>

           </div>
        )
    }
}

const mapStateToProps = (state) => ({
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        getPagedUsersAction
    }, dispath)

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(UserArea)));