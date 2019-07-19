import React from "react"
import axios from "axios"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { LOCATION_PERMISSION_DENIED, LOCATION_UNAVAILABLE, LOCATION_TIMEOUT, LOCATION_UNKNOWN_ERROR } from "../../../constants"
import { showLoaderAction, hideLoaderAction, requestLogoutAction, addNotificationAction, removeNotificationAction } from "../../../actions"

class Interceptor extends React.PureComponent {

    constructor(props) {
        super(props)

        this.configureRequestInterceptor = this.configureRequestInterceptor.bind(this);
    }

    componentDidMount() {
        this.configureRequestInterceptor();
    }


    configureRequestInterceptor() {
        axios.interceptors.request.use((config) => {

            this.props.showLoaderAction()

            return config
        }, (error) => {
            debugger
            console.log(error)
            this.props.hideLoaderAction()
        })
    
        axios.interceptors.response.use((response) => {

            this.props.hideLoaderAction()
            return response

        }, (error) => {

            if (!!error.response) {
    
                if (error.response.status === 401) {
                    this.props.requestLogoutAction()
                }
        
                if (error.response.data && error.response.data.notifications.length) {
                    this.props.addNotificationAction(error.response.data.notifications)
                }

            }
    
            this.props.hideLoaderAction()
    
            return Promise.reject(error)
        })
    }

    render() {
        return null
    }
}

const mapStateToProps = state => ({
    loader: state.loaderReducer,
    notification: state.notificationReducer,
    geolocation: state.geolocationReducer
})
  
const mapDispatchToProps = dispath =>
    bindActionCreators(
        {
            showLoaderAction,
            hideLoaderAction,
            requestLogoutAction,
            addNotificationAction,
            removeNotificationAction,
        }, dispath
    )
  
export default connect(mapStateToProps, mapDispatchToProps)(Interceptor)