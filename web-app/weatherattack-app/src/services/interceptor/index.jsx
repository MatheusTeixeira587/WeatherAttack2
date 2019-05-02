import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { LOCATION_PERMISSION_DENIED, LOCATION_UNAVAILABLE, LOCATION_TIMEOUT, LOCATION_UNKNOWN_ERROR } from '../../../constants';
import { showLoaderAction, hideLoaderAction, setUnauthorizedAction, addNotificationAction, removeNotificationAction } from '../../../actions';
import axios from 'axios';

class Interceptor extends React.Component {

    constructor(props) {
        super(props)

        this.handleNotifications = this.handleNotifications.bind(this)
        this.configureRequestInterceptor = this.configureRequestInterceptor.bind(this)

        this.configureRequestInterceptor();
    }

    handleNotifications(notifications) {
        this.props.addNotificationAction(notifications)
    
        setTimeout(() => {
          this.props.removeNotificationAction(notifications)
        }, 4000);
    }

    handleGetLocationError() {
        if (this.props.geolocation.error) {
    
            const error = this.props.geolocation.error;
            let notification = {};
    
            switch (this.props.geolocation.error) {
    
                case error.PERMISSION_DENIED:
                notification = LOCATION_PERMISSION_DENIED;
                break;
        
                case error.POSITION_UNAVAILABLE:
                notification = LOCATION_UNAVAILABLE;
                break;
        
                case error.TIMEOUT:
                notification = LOCATION_TIMEOUT;
                break;
        
                case error.UNKNOWN_ERROR:
                notification = LOCATION_UNKNOWN_ERROR
                break;
        
                default:
                break;
            }
    
            if (notification.code) {
                this.props.addNotificationAction([notification])
        
                setTimeout(() => {
                this.props.removeNotificationAction(notification)
                }, 4000)
            }
        }
    }

    configureRequestInterceptor() {
        axios.interceptors.request.use((config) => {

            this.props.showLoaderAction()

            return config
        });
    
        axios.interceptors.response.use((response) => {

            this.props.hideLoaderAction()
            return response;

        }, (error) => {

            if (!!error.response) {
    
                if (error.response.status === 401) {
                    this.props.setUnauthorizedAction()
                }
        
                if (error.response.data.notifications.length) {
                this.handleNotifications(error.response.data.notifications)
                }

            }
    
            this.props.hideLoaderAction()
    
            return Promise.reject(error)
        })
    }

    render() {
        return null;
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
            setUnauthorizedAction,
            addNotificationAction,
            removeNotificationAction,
        }, dispath
    )
  
export default connect(mapStateToProps, mapDispatchToProps)(Interceptor);