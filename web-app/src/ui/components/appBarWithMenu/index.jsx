import React from 'react'
import { Redirect, withRouter, Link } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { withStyles } from '@material-ui/core/styles'
import { AppBar, Toolbar, Typography, CardMedia, Menu, MenuItem } from '@material-ui/core'
import { THEME_COLOR, routes } from '../../../constants'
import { LOGOUT_ICON, MENU_ICON } from '../../../static'
import { startChannelAction, requestLogoutAction } from '../../../actions'
import { WeatherBarComponent } from '..';

const styles = {
    root: {    
        color: 'white',
        width: '100%',
        height: 'min-content'
    },
    grow: {
        flexGrow: 1,
    },
    menuBar: {
        width: '95%',
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
    menuIconDiagonalWrapper: {
        backgroundColor: 'white',
        transform:'skew(-25deg)',
        width: '10%',
        overflow: 'hidden',
        display: 'flex',
        alignItems: 'center',
        zIndex: 2
    },
    menuIconWrapper: {
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
    menuItemsWrapper: {
        width: '60%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-evenly'
    },
    link: {
        textDecoration: 'none',
        color: 'white'
    }
};

class MenuAppBar extends React.Component {

    constructor(props) {
        super(props)

        this.state = {
            anchorEl: null
        }

        this.onClickLogout = this.onClickLogout.bind(this);
        this.toggleMenu = this.toggleMenu.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.renderMenu = this.renderMenu.bind(this);
    }

    onClickLogout() {
        this.props.requestLogoutAction();
    }

    toggleMenu = event => this.setState({ anchorEl: event.target })

    handleClose = () => this.setState({ anchorEl: null })

    renderMenu() {
        return (
            <React.Fragment>           
                <Menu
                    open={Boolean(this.state.anchorEl)}
                    anchorEl={this.state.anchorEl}
                    onClose={this.handleClose}
                >
                    <MenuItem onClick={this.toggleMenu}><Link to={routes.ADMINISTRATION_PAGE}> Admin </Link></MenuItem>
                </Menu>
                <img
                    src={MENU_ICON}
                    onClick={this.toggleMenu}
                    alt="Menu"
                />
            </React.Fragment>
        )
    }

    render() {

        if (!this.props.login.token) {
            return <Redirect to={routes.LOGIN_PAGE}/>
        }
        
        const { classes } = this.props

        return (
        <div className={classes.root}>
            <AppBar position="static" color="inherit" className={classes.menuColor}>
                <Toolbar className={classes.menuBar}>
                    <WeatherBarComponent />
                    <div className={classes.menuItemsWrapper}>
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            <Link to={routes.DASHBOARD_PAGE} className={classes.link}> Weather Attack </Link>
                        </Typography>
                        {this.renderMenu()}
                    </div>
                </Toolbar>
                <div className={classes.menuIconDiagonalWrapper}>
                    <div className={classes.menuIconWrapper} >
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