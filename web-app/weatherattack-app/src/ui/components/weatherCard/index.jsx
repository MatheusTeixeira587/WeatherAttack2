import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Card, CardContent, CardMedia, Typography, Button } from '@material-ui/core';
import { weatherButtonText } from '../../../constants'
import { RAINY_ICON, SUNNY_ICON } from '../../../static';

const styles = theme => ({
  card: {
    display: 'flex',
    top: '10px',
    right: '10px',
    position: 'absolute',
    overflow: 'hidden',
    borderRadius: '20px',
    background: 'linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3))',
  },
  details: {
    display: 'flex',
    flexDirection: 'column',
    opacity: 1,
    backgroundAttachment: 'fixed'
  },
  content: {
    flex: '1 0 auto',
    opacity: 1,
    color: 'white',
    paddingBottom: '0px'
  },
  cover: {
    width: 121,
    height: '70%',
    opacity: 1,
    backgroundSize: 'contain',
    overflow: 'hidden',
  },
  coverWrapper: {
      padding: 10,
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center'
  }
});

const WeatherCard = props => {
    const { classes, temperature, description, wind, city, onClick } = props;
    let icon = props.icon;

    switch (icon) {

        case "09d":
            icon = RAINY_ICON;
            break;

        default:
            icon = SUNNY_ICON;
            break;
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
                    <span>{weatherButtonText}</span>
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
);
}

WeatherCard.propTypes = {
    classes: PropTypes.object.isRequired,
    theme: PropTypes.object.isRequired,
    temperature: PropTypes.number.isRequired,
    description: PropTypes.string.isRequired,
    wind: PropTypes.number.isRequired,
    city: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired
};
export default withStyles(styles, { withTheme: true })(WeatherCard);