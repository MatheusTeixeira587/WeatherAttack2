import React, { Component } from "react"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { withStyles } from "@material-ui/core/styles"
import { Menu, MenuItem } from "@material-ui/core"
import { LanguageOutlined } from "@material-ui/icons"
import { supportedLanguages } from "../../../constants"  
import { changeLanguageAction } from "../../../actions"
import { BRASIL_FLAG, UNITED_STATES_FLAG } from "../../../static"

const styles = ({
    menuWrapper: {
        height: 60,
        width: 60,
        display: "flex",
        position: "absolute",
        left: 420,
        top: 5,
        cursor: "pointer"
    },
    flagIcon: {
        width: "100%",
        height: "100%"
    },
    menuItem: {
        height: 40,
        width: 45
    },
    icon: {
        color: "#88d0ef",
        borderRadius: "50%",
        border: "1px solid"
    }
})

class LanguageSelectorComponent extends Component {

    constructor(props) {
        super(props)
        
        this.state = {
            anchorEl: null
        }
        
        this.toggleMenu = this.toggleMenu.bind(this)
        this.handleClose = this.handleClose.bind(this)
    }

    toggleMenu = event => this.setState({ anchorEl: event.target})

    handleClose = () => this.setState({ anchorEl: null })

    render() {
        return (
            <div className={this.props.menuWrapper}>           
                <Menu
                    open={Boolean(this.state.anchorEl)}
                    anchorEl={this.state.anchorEl}
                    onClose={this.handleClose}
                >
                    <MenuItem className={this.props.classes.menuItem} onClick={() => {
                        this.props.changeLanguageAction(supportedLanguages.EN_US)
                        this.handleClose()
                    }}>
                        <img
                            className={this.props.classes.flagIcon}
                            alt="english"
                            src={UNITED_STATES_FLAG}
                        />
                    </MenuItem>
                    <MenuItem className={this.props.classes.menuItem} onClick={() => {
                        this.props.changeLanguageAction(supportedLanguages.PT_BR)
                        this.handleClose()
                    }}>
                        <img
                            className={this.props.classes.flagIcon}
                            alt="português"
                            src={BRASIL_FLAG}
                        />
                    </MenuItem>
                </Menu>
                <LanguageOutlined
                    className={this.props.classes.icon}
                    onClick={this.toggleMenu}
                />
            </div>
        )
    }
}

const mapStateToProps = state => ({
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        changeLanguageAction
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(LanguageSelectorComponent));