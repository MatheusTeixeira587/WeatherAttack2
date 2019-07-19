import React, { Component } from "react"
import { connect } from "react-redux"
import { withRouter, Redirect } from "react-router-dom"
import { bindActionCreators } from "redux"
import { getLocationAction, showLoaderAction, hideLoaderAction, changeFieldAction, requestLoginAction, requestRegisterAction, triggerRegisterDisplayAction } from "../../../actions"
import { Grid } from "@material-ui/core"
import { LoginComponent, RegisterComponent, Link, WeatherCardComponent, LanguageSelectorComponent } from "../../"
import { withStyles } from "@material-ui/core/styles"
import { routes, APP_TEXTS } from "../../../constants"
import { BACKGROUND, APP_LOGO } from "../../../static"

const styles = ({
    mainDiv: {
        minHeight: "100vh"
    },
    divStyle: {
        boxShadow: "0 0px 80px rgba(0, 0, 0, 0.7)",
        zIndex: 1,
    },
    background: {
        background: `url("${BACKGROUND}")`,
        backgroundSize: "cover",
        backgroundRepeat: "no-repeat",
        backgroundPosition: "center",
        overflow: "hidden",
    },
    logo: {
        background: `url("${APP_LOGO}")`,
        backgroundSize:"contain",
        backgroundRepeat:"no-repeat",
        backgroundPosition: "center",
        height: "100%",
    },
    logoContainer: {
        height: 200,
    },
    languageSelectorWrapper: {
        display: "flex",
        justifyContent: "flex-end",
        padding: 5,
    },
    [`@media (max-height: ${800}px)`]: {
        logoContainer: {
            height: 150,
        }
    },
    [`@media (max-width: ${960}px)`]: {
        background: {
            display: "none",
        }
    },
})

class LoginPage extends Component {

    constructor(props) {
        super(props)
        this.renderLoginOrRegisterComponent = this.renderLoginOrRegisterComponent.bind(this)
        this.renderWeatherCard = this.renderWeatherCard.bind(this)
    }

    renderLoginOrRegisterComponent() {
        if (this.props.login.shouldRenderRegister) {

            return (
                <RegisterComponent
                    language={this.props.language.selected}
                    login={this.props.login}
                    changeField={this.props.changeFieldAction}
                    requestRegisterAction={this.props.requestRegisterAction}
                />
            )
        }

        return (
            <LoginComponent
                language={this.props.language.selected}
                login={this.props.login}
                changeField={this.props.changeFieldAction}
                requestLoginAction={this.props.requestLoginAction}
            />
        )
    }

    renderWeatherCard() {
        if (this.props.weather.cityName) {
            return (
                <WeatherCardComponent
                    language={this.props.language.selected}
                    city={this.props.weather.cityName}
                    wind={parseInt(this.props.weather.wind.speed, 10)}
                    description={this.props.weather.weather.length > 0 ? this.props.weather.weather[0].description : APP_TEXTS.noWeatherDescriptionAvailableMessage[this.props.language.selected]}
                    temperature={parseInt(this.props.weather.main.temperature, 10)}
                    onClick={this.props.getLocationAction}
                    icon={this.props.weather.weather[0].icon}
                />
            )
        }
    }

    render() {
            if (this.props.login.token) {
                return <Redirect to={routes.DASHBOARD_PAGE} />
            }
            return (
                <Grid
                    container
                    item
                    direction="row"
                    justify="center"
                    lg={12}
                    sm={12}
                    className={this.props.classes.mainDiv}
                >
                    <Grid
                        component="div"
                        container
                        direction="row"
                        alignContent="flex-start"
                        alignItems="center"
                        justify="center"
                        lg={4}
                        md={4}
                        sm={12}
                        item
                        className={this.props.classes.divStyle}
                    >
                        <Grid
                            component="div"
                            item
                            lg={12}
                            sm={12}
                        >
                            <div className={this.props.classes.languageSelectorWrapper}>
                                <LanguageSelectorComponent />
                            </div>
                            <Grid
                                component="div"
                                className={this.props.classes.logoContainer}
                            >
                                <div
                                    className={this.props.classes.logo}
                                >
                                </div>
                            </Grid>
                        </Grid>
                        {this.renderLoginOrRegisterComponent()}
                        <Link
                            onClick={this.props.triggerRegisterDisplayAction}
                            message={this.props.login.shouldRenderRegister ? APP_TEXTS.alreadyHaveAccountMessage[this.props.language.selected] : APP_TEXTS.createAccountMessage[this.props.language.selected]}
                        />
                    </Grid>
                    <Grid
                        item
                        lg={8}
                        md={8}
                        sm={false}
                        container
                        className={this.props.classes.background}
                    >
                        {this.renderWeatherCard()}
                    </Grid>     
                </Grid>
            )
        }
    }

const mapStateToProps = state => ({ 
  loader: state.loaderReducer,
  login: state.loginReducer,
  geolocation: state.geolocationReducer,
  weather: state.weatherReducer,
  authorization: state.authorizationReducer,
  language: state.languageReducer
})

const mapDispatchToProps = dispath =>
bindActionCreators(
  {
    showLoaderAction, 
    hideLoaderAction, 
    changeFieldAction, 
    requestLoginAction, 
    triggerRegisterDisplayAction, 
    requestRegisterAction,
    getLocationAction
  }, dispath)

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(LoginPage)))