import React from "react"
import { withRouter, Link } from "react-router-dom"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"
import PropTypes from "prop-types"
import { withStyles } from "@material-ui/core/styles"
import { AppBar, Toolbar } from "@material-ui/core"
import { HomeOutlined, Person, ExitToAppOutlined } from "@material-ui/icons";
import { THEME_COLOR, routes, permissionLevel } from "../../../constants"
import { startChannelAction, requestLogoutAction } from "../../../actions"
import { WeatherBarComponent, LanguageSelectorComponent } from ".."

const styles = {
    root: {    
        color: "white",
        width: "100%",
        height: "min-content"
    },
    grow: {
        flexGrow: 17,
    },
    menuBar: {
        width: "95%",
        },
    menuButton: {
        marginLeft: -12,
        marginRight: 20,
    },
    menuColor: {
        flexDirection: "row",
        backgroundColor: THEME_COLOR,
        overflow: "hidden"
    },
    menuItem: {
        background:"white",
        width: "15%",
    },
    menuIconDiagonalWrapper: {
        backgroundColor: "white",
        transform:"skew(-25deg)",
        width: "10%",
        overflow: "hidden",
        display: "flex",
        alignItems: "center",
        zIndex: 2
    },
    menuIconWrapper: {
        transform:"skew(25deg)",
        width: "100%",
        backgroundColor: "white",
        justifyContent: "center"
    },
    closeIcon: {
        color: "black",
        height: 30,
        width: 30,
        "&:hover": {
            cursor: "pointer"
        }
    },
    adminIcon: {
        color: "black",
    },
    menuItemsWrapper: {
        width: "60%",
        display: "flex",
        alignItems: "center",
        justifyContent: "flex-end",
    },
    link: {
        textDecoration: "none",
        color: "white"
    },
    iconItem: {
        paddingLeft: 5,
        "&:hover": {
            cursor: "pointer"
        }
    }
}

class MenuAppBar extends React.Component {

    constructor(props) {
        super(props)

        this.renderMenu = this.renderMenu.bind(this)
    }

    renderMenu() {
        return (
            <React.Fragment>
                <div className={this.props.classes.iconItem}>
                    <Link to={routes.ADMINISTRATION_PAGE}><Person className={this.props.classes.adminIcon}/></Link>
                </div>    
            </React.Fragment>
        )
    }

    render() {
        const { classes } = this.props
        
        return (
        <div className={classes.root}>
            <AppBar position="static" color="inherit" className={classes.menuColor}>
                <Toolbar className={classes.menuBar}>
                    <WeatherBarComponent />
                    <div className={classes.menuItemsWrapper}>
                        <div className={classes.iconItem}>
                            <Link to={routes.DASHBOARD_PAGE} className={classes.link}>
                                <HomeOutlined/>
                            </Link>
                        </div>
                        <div className={classes.iconItem}>
                            <LanguageSelectorComponent />
                        </div>
                        {this.props.login.permissionLevel === permissionLevel.ADMIN ? this.renderMenu() : <></>}
                    </div>
                </Toolbar>
                <div className={classes.menuIconDiagonalWrapper}>
                    <div className={classes.menuIconWrapper} >
                        <ExitToAppOutlined
                            className={classes.closeIcon}
                            onClick={this.props.requestLogoutAction}
                        />
                    </div>                
                </div>             
            </AppBar>
        </div>
        )
    }
    }

MenuAppBar.propTypes = {
  classes: PropTypes.object.isRequired,
}


const mapStateToProps = state => ({ 
    login: state.loginReducer
  })
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
        requestLogoutAction,
        startChannelAction,
    }, dispath)
  
export default withRouter(connect(mapStateToProps, mapDispatchToProps)(withStyles(styles)(MenuAppBar)))