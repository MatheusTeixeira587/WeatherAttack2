import React from 'react'
import { connect } from 'react-redux'
import { Card, Typography } from '@material-ui/core'
import { Loop } from '@material-ui/icons'
import { withStyles } from '@material-ui/core/styles'
import { getLocationAction } from '../../../actions'
import { RAINY_ICON, SUNNY_ICON, STORMY_ICON, CLOUDY_ICON, SNOWY_ICON, MISTY_ICON } from '../../../static'
import { bindActionCreators } from 'redux'

const styles = () => ({
    card: {
        width: '40%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-evenly',
        color: 'white',
        backgroundColor: 'inherit'
    },
    icon: {
        backgroundSize: 'cover',
        maxWidth: '50px',
    },
    iconWrapper : {
        padding: 4,
        width: '30%'
    },
    content: {
        width: '100%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-around'
    },
    button: {
        height: 20
    },
    contentColumn: {
        alignItems: 'center',
        justifyContent: 'center',
        display: 'flex',
        flexDirection: 'column',
    },
    reloadIcon: {
        '&:hover': {
            cursor: 'pointer'
        }
    }
})

const WeatherBarComponent = props => {

    const { classes } = props
    let icon;

    if(!!props.weather.weather.length && props.weather.weather[0].icon) {
        icon = props.weather.weather[0].icon.substring(0,2)
    } else {
        props.getLocationAction();

        return (<></>)
    }

    switch (icon) {

        case "03" || "04":
            icon = CLOUDY_ICON;
            break;

        case "09" || "10":
            icon = RAINY_ICON;
            break;

        case "11":
            icon = STORMY_ICON
            break;

        case "13":
            icon = SNOWY_ICON
            break;

        case "50":
            icon = MISTY_ICON
            break;

        default:
            icon = SUNNY_ICON;
            break;
    }
    
    return (
        <Card className={classes.card}>
            <div className={classes.iconWrapper}>
                <img
                    className={classes.icon}
                    src={icon}
                    alt=""
                />
            </div>
            <div className={classes.content}>
                <div className={classes.contentColumn}>
                    <Typography component="h5" variant="h5" color="inherit">
                        {parseInt(props.weather.main.temperature)+"°C"}
                    </Typography>
                    <Typography variant="body1" color="inherit">
                        {props.weather.weather[0].description}
                    </Typography>
                </div>
                <div className={classes.contentColumn}>
                    <Typography variant="subtitle2" color="inherit">
                        {parseInt(props.weather.wind.speed)+"km/h"}
                    
                    </Typography>
                    <Typography variant="body2" color="inherit">
                        {props.weather.cityName}
                    </Typography>
                </div>
                <div className={classes.contentColumn}>
                    <Loop
                        className={classes.reloadIcon}
                        onClick={props.getLocationAction}
                    />
                </div>
            </div>
        </Card>
    )
}

const mapStateToProps = state => ({ 
    weather: state.weatherReducer,
  });
  
const mapDispatchToProps = dispath =>
    bindActionCreators(
        {
            getLocationAction
        }, dispath
    )

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(WeatherBarComponent));