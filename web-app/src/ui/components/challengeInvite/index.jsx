import React, { Component } from "react"
import { withStyles } from "@material-ui/core/styles"
import { Typography, CardActions, CardContent, Button, SnackbarContent, Snackbar } from "@material-ui/core"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"
import { APP_TEXTS } from "../../../constants"
import { userRefusedChallengeAction, userAcceptedChallengeAction } from "../../../actions"

const styles = {
    snackbar: {
        background: "white",
        width: "15%",
        display: "flex",
        justifyContent: "center",
        border: "1px solid black"
    },
    cardWrapper: {
        padding: 5,
        display: "flex",
        flexDirection: "column",
    },
    card: {
        height: 120,
        border: "gray 0.5px solid",
        flex: 1,
        display: "flex",
        flexDirection: "column",
    },
    cardActions: {
        justifyContent: "center",
        padding: 0,
        flex: 1
    },
    cardContent: {
        padding: 0,
        flex: 1
    },
    cardContentTexts: {
        margin: 0,
        padding: 5
    },
}

class ChallengeInviteComponent extends Component {

    constructor(props) {
        super(props)
        this.props.invite.id = this.props.id;
        this.renderCardChallenge = this.renderCardChallenge.bind(this)
    }

    componentDidMount() {
        setTimeout(() => this.props.userRefusedChallengeAction(this.props.invite), 6000);
    }

    renderCardChallenge() {
        const { classes, invite, ...props } = this.props;
        return (
            <div className={classes.cardWrapper}>
                <CardContent className={classes.cardContent}>
                    <Typography className={classes.cardContentTexts} variant="subtitle1">
                        {APP_TEXTS.challengeInviteCardText[props.language.selected]}!
                    </Typography>
                    <Typography className={classes.cardContentTexts}>
                        {invite.by.username}
                    </Typography>
                </CardContent>
                <CardActions className={classes.cardActions}>
                    <Button 
                        size="small" 
                        color="primary" 
                        variant="outlined"
                        className={classes.actionButton}
                        onClick={() => props.userAcceptedChallengeAction(invite)}
                    >
                        {APP_TEXTS.acceptText[props.language.selected]}!
                    </Button>
                    <Button 
                        size="small" 
                        color="secondary" 
                        variant="outlined"
                        className={classes.actionButton}
                        onClick={() => props.userRefusedChallengeAction(invite)}
                    >
                        {APP_TEXTS.refuseText[props.language.selected]}!
                    </Button>
                </CardActions>
            </div>
        )
    }

    render() {
        return (
            <Snackbar
                open={true}
                anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
            >
                <SnackbarContent
                    className={this.props.classes.snackbar}
                    message={this.renderCardChallenge()}
                />
            </Snackbar>
        )
    }
}

const mapStateToProps = state => ({ 
    challenge: state.challengeReducer,
    language: state.languageReducer,
    login: state.loginReducer
  })
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
        userRefusedChallengeAction,
        userAcceptedChallengeAction
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(ChallengeInviteComponent))