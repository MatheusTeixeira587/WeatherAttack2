import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Card, Typography, CardMedia, CardActionArea, CardActions, CardContent, Button } from '@material-ui/core'

import { AVATAR } from '../../../static'
import { showLoaderAction, hideLoaderAction } from '../../../actions'

import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'

const styles = {
    cardWrapper: {
        padding: 5
    },
    card: {
    width: 150,
    minWidth: 150,
    height: 180,
    border: 'gray 0.5px solid'
    },
    media: {
    height: 40,
    backgroundSize: 'contain',
    marginTop: '10%',
    },
    cardContent: {
        padding: '10px'
    },
    statusDisplay: {
        height: '10px',
        width: '10px',
        backgroundColor: 'green',
        borderRadius: '50%',
        marginRight: '5px',
    },
    statusDisplayWrapper: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },
    CardActions: {
        justifyContent: 'center'
    }
};

function MediaCard(props) {
    const { classes, user } = props;
    return (
        <div className={classes.cardWrapper}>
            <Card className={classes.card}>
                <CardActionArea>
                    <CardMedia
                        className={classes.media}
                        image={AVATAR}
                        title="avatar"
                        />
                        
                    <CardContent className={classes.cardContent}>
                        <Typography gutterBottom variant="subtitle1">
                        {user.username}
                        </Typography>
                        <Typography component="div" className={classes.statusDisplayWrapper}>
                            <div className={classes.statusDisplay}></div>
                            online
                        </Typography>
                    </CardContent>
                </CardActionArea>
                <CardActions className={classes.CardActions}>
                    <Button size="small" color="primary" variant='outlined'>
                        Challenge!
                    </Button>
                </CardActions>
            </Card>
        </div>
    );
}

const mapStateToProps = state => ({ 
});
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
      showLoaderAction, 
      hideLoaderAction
    }, dispath);

MediaCard.propTypes = {
  classes: PropTypes.object.isRequired,
  user: PropTypes.object.isRequired,
};

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(MediaCard));