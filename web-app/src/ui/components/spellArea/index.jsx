import React, { Component } from "react"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { withStyles } from "@material-ui/core/styles"
import { withRouter } from "react-router-dom"
import { AddSpell, Button, SpellTable } from "../../components"
import { APP_TEXTS } from "../../../constants"

class SpellArea extends Component {

    constructor(props) {
        super(props)

        this.state = {
            currentTab: 1
        }

        this._handleButtonClick = this._handleButtonClick.bind(this);
        this._renderContent = this._renderContent.bind(this)
    }

    _handleButtonClick() {
        this.setState({
            currentTab: this.state.currentTab === 1 ? 2 : 1
        })
    }

    _renderContent() {
        return this.state.currentTab === 1 ? <SpellTable /> : <AddSpell/>
    }
   
    render() {
        const { classes } = this.props
        return (
            <div className={classes.component}>
                <div className={classes.actionBar}>
                    <Button 
                        disabled={false}
                        variant="outlined"
                        color="primary"
                        onClick={this._handleButtonClick}
                        fullWidth={false}
                        text={APP_TEXTS.addText[this.props.language.selected]}
                    />
                </div>
                <div className={classes.spellComponentWrapper}>
                    {
                        this._renderContent()
                    }
                </div>                
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({}, dispath)

const styles = {
    component: {
        width: "90%",
        flex: 1,
        display: "flex",
        flexDirection: "column",
        backgroundColor: "white",
        marginTop: 10,
        bordeRadius: 4
    },
    actionBar: {
        marginBottom: 5
    },
    spellComponentWrapper: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
    }
}

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(SpellArea)))