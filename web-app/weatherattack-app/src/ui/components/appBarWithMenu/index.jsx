import React from 'react'
import { Redirect, withRouter } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { withStyles } from '@material-ui/core/styles'
import { AppBar, Toolbar, Typography, CardMedia} from '@material-ui/core'

import { THEME_COLOR } from '../../../constants'
import { LOGOUT_ICON } from '../../../static'
import { startChannelAction, requestLogoutAction } from '../../../actions'

const styles = {
    root: {    
        color: 'white',
        width: '100%'
    },
    grow: {
        flexGrow: 1,
    },
    menuBar: {
        width: '95%'
        },
    menuButton: {
        marginLeft: -12,
        marginRight: 20,
    },
    menuColor: {
        flexDirection: 'row',
        backgroundColor: THEME_COLOR,
        overflow: 'hidden'
    },
    menuItem: {
        background:'white',
        width: '15%',
    },
    menuItemDiagonalWrapper: {
        backgroundColor: 'white',
        transform:'skew(-25deg)',
        width: '10%',
        overflow: 'hidden',
        display: 'flex',
        alignItems: 'center',
        zIndex: 2
    },
    menuItemWrapper: {
        transform:'skew(25deg)',
        width: '100%',
        backgroundColor: 'white',
        justifyContent: 'center'
    },
    menuItemText: {
        height:'30px',
        backgroundSize: 'auto',
        '&:hover':{
            cursor:'pointer',
        }
    },
};

class MenuAppBar extends React.Component {

    constructor(props) {
        super(props)

        this.onClickLogout = this.onClickLogout.bind(this);
    }

    componentDidMount() {
        this.props.startChannelAction();
    }

    onClickLogout() {
        this.props.requestLogoutAction();
    }

    render() {
        if (!this.props.login.token) {
            return <Redirect to="/#"/>
        }
        const { classes } = this.props;

        return (
        <div className={classes.root}>
            <AppBar position="static" color="inherit" className={classes.menuColor}>
            <Toolbar className={classes.menuBar}>
                <Typography variant="h6" color="inherit" className={classes.grow}>
                    Placeholder
                </Typography>
            </Toolbar>
                    <div className={classes.menuItemDiagonalWrapper}>
                        <div className={classes.menuItemWrapper} >
                            <CardMedia
                                onClick={this.onClickLogout}
                                image={LOGOUT_ICON}
                                className={classes.menuItemText}
                            ></CardMedia>
                        </div>                
                    </div>             
            </AppBar>
        </div>
        );
    }
    }

MenuAppBar.propTypes = {
  classes: PropTypes.object.isRequired,
};


const mapStateToProps = state => ({ 
    login: state.loginReducer
  });
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
        requestLogoutAction,
        startChannelAction,
    }, dispath)
  
export default withRouter(connect(mapStateToProps, mapDispatchToProps)(withStyles(styles)(MenuAppBar)));