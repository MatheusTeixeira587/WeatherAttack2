import React from "react"
import PropTypes from "prop-types"
import { withStyles } from "@material-ui/core/styles"
import { Card, CardContent, CardMedia, Typography, Button } from "@material-ui/core"
import { APP_TEXTS } from "../../../constants"
import { RAINY_ICON, SUNNY_ICON, CLOUDY_ICON, SNOWY_ICON, MISTY_ICON, STORMY_ICON } from "../../../static"

const styles = () => ({
    card: {
        display: "flex",
        top: "10px",
        right: "10px",
        position: "absolute",
        overflow: "hidden",
        borderRadius: "20px",
        background: "linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3))",
        },
    details: {
        display: "flex",
        flexDirection: "column",
        opacity: 1,
        backgroundAttachment: "fixed"
    },
    content: {
        flex: "1 0 auto",
        opacity: 1,
        color: "white",
        paddingBottom: "0px"
    },
    cover: {
        width: 121,
        height: "70%",
        opacity: 1,
        backgroundSize: "contain",
        overflow: "hidden",
    },
    coverWrapper: {
        padding: 10,
        display: "flex",
        alignItems: "center",
        justifyContent: "center"
    }
})

const WeatherCard = props => {
    const { classes, temperature, description, wind, city, onClick, language } = props
    let icon = props.icon.substring(0,2)

    switch (icon) {

        case "03" || "04":
            icon = CLOUDY_ICON
            break

        case "09" || "10":
            icon = RAINY_ICON
            break

        case "11":
            icon = STORMY_ICON
            break

        case "13":
            icon = SNOWY_ICON
            break

        case "50":
            icon = MISTY_ICON
            break

        default:
            icon = SUNNY_ICON
            break
    }

    return (
        <Card className={classes.card}>
            <div className={classes.details}>
                <CardContent className={classes.content}>
                    <Typography component="h5" variant="h5" color="inherit">
                        {temperature+"°C"}
                    </Typography>
                    <Typography variant="body1" color="inherit">
                        {description}
                    </Typography>
                    <Typography variant="subtitle2" color="inherit">
                        {wind+"km/h"}
                    </Typography>
                    <Typography variant="body2" color="inherit">
                        {city}
                    </Typography>
                    <Button
                        variant="contained"
                        onClick={onClick}
                    >
                        <span>{APP_TEXTS.weatherButtonText[language]}</span>
                    </Button>
                </CardContent>
            </div>
            <div className={classes.coverWrapper}>
                <CardMedia
                    className={classes.cover}
                    image={icon}
                    title="Weather Icon"
                />
            </div>
        </Card>
    )
}

WeatherCard.propTypes = {
    classes: PropTypes.object.isRequired,
    temperature: PropTypes.number.isRequired,
    description: PropTypes.string.isRequired,
    wind: PropTypes.number.isRequired,
    city: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired,
    language: PropTypes.string.isRequired
}
export default withStyles(styles, { withTheme: true })(WeatherCard)