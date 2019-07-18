import React, { Component } from "react"
import { Grid, withStyles } from "@material-ui/core"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"

const styles = ({

})

class ChallengeInviteComponent extends Component {

    render() {
        return (
            <></>
        )
    }
}

const mapStateToProps = state => ({ 
    challenge: state.challengeReducer,
  })
  
const mapDispatchToProps = dispath =>
  bindActionCreators(
    {
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(ChallengeInviteComponent))