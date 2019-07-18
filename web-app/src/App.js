import "./App.css"
import React, { Component } from "react"
import { connect } from "react-redux"
import { Switch, Route, Redirect, withRouter } from "react-router-dom"
import { bindActionCreators } from "redux"
import { Snackbar } from "@material-ui/core"
import { Loader, SnackBarContentWrapper, LoginPage, AdministratorPage, Interceptor, DashboardPage } from "./ui"
import { startChannelAction, showLoaderAction, hideLoaderAction, addNotificationAction, removeNotificationAction, getLocationAction } from "./actions"
import { routes } from "./constants"

class App extends Component {

    constructor(props) {
        super(props)

        this.renderNotifications = this.renderNotifications.bind(this)
    }

    componentDidMount() {
        this.props.getLocationAction()
    }

    renderNotifications() {
        const getProperLanguageName = language => {
            return language.charAt(0).toLowerCase() + language.slice(1);
        }

        if (!!this.props.notification && this.props.notification.notifications.length) {
            return this.props.notification.notifications.map((n, k) => {
                return (
                <Snackbar
                id={k}
                open={true}
                anchorOrigin={{ vertical: "top", horizontal: "right" }}
                >
                <SnackBarContentWrapper
                    variant="error"
                    message={n.message[this.props.language.selected] || n.message[getProperLanguageName(this.props.language.selected)]}
                />
                </Snackbar>
                )
            })
        }
    }

    render() {
        return (
            <div className="App">
                <Interceptor/>
                <Loader showLoader={this.props.loader.showLoader} />
                {
                    this.renderNotifications()
                }
                <Switch>
                    <Route path={routes.LOGIN_PAGE} exact component={LoginPage} />
                    <Route path={routes.DASHBOARD_PAGE} exact component={DashboardPage} />
                    <Route path={routes.ADMINISTRATION_PAGE} exact component={AdministratorPage} />
                    <Route path={routes.NOT_FOUND}/>
                    <Redirect to={routes.LOGIN_PAGE}/>
                </Switch>
            </div>
        )
    }
}

const mapStateToProps = state => ({
    loader: state.loaderReducer,
    notification: state.notificationReducer,
    geolocation: state.geolocationReducer,
    challenge: state.challengeReducer,
    language: state.languageReducer,
    login: state.loginReducer,
    character: state.characterReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators(
    {
        showLoaderAction,
        hideLoaderAction,
        addNotificationAction,
        removeNotificationAction,
        getLocationAction,
        startChannelAction
    }, dispath)

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(App))