import React, { Component } from "react"
import PropTypes from "prop-types"
import { withStyles } from "@material-ui/core/styles"
import { Card, Typography, CardMedia, CardActionArea, CardActions, CardContent, Button } from "@material-ui/core"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"

import { AVATAR } from "../../../static"
import { showLoaderAction, hideLoaderAction, sendChallengeAction } from "../../../actions"
import { APP_TEXTS } from "../../../constants";

const styles = {
    cardWrapper: {
        padding: 5
    },
    card: {
        width: 150,
        minWidth: 150,
        height: 180,
        border: "gray 0.5px solid"
    },
    media: {
        height: 40,
        backgroundSize: "contain",
        marginTop: "10%",
    },
    cardContent: {
        padding: "10px"
    },
    statusDisplay: {
        height: "10px",
        width: "10px",
        backgroundColor: "green",
        borderRadius: "50%",
        marginRight: "5px",
    },
    statusDisplayWrapper: {
        display: "flex",
        alignItems: "center",
        justifyContent: "center"
    },
    CardActions: {
        justifyContent: "center"
    }
}

class UserCardComponent extends Component {

    render() {
        const { classes, user, ...props } = this.props

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
                        <Button size="small" color="primary" variant="outlined"
                            onClick={() => props.sendChallengeAction({
                                by: {
                                    id: props.login.id
                                },
                                to: {
                                    id: user.id
                                }
                            })}
                        >
                            {APP_TEXTS.challengeText[this.props.language.selected]}!
                        </Button>
                    </CardActions>
                </Card>
            </div>
        )
    }
}

const mapStateToProps = state => ({ 
    login: state.loginReducer,
    language: state.languageReducer
})
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
        showLoaderAction, 
        hideLoaderAction,
        sendChallengeAction
    }, dispath)

UserCardComponent.propTypes = {
    classes: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
}

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(UserCardComponent))