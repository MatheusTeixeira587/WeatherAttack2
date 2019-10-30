import React, { Component } from "react"
import { connect } from "react-redux"
import { withStyles } from "@material-ui/core/styles"
import { Tabs, Tab } from "@material-ui/core"
import { bindActionCreators } from "redux"
import { SpellArea, UserArea } from "../../components"

const styles = {
    page: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        flex: 1,
        padding: 10,
    },
    tabsWrapper: {
        backgroundColor: "white",
        borderRadius: 4,
        display: "flex"
    }

}

const tabs = [
    { 
        name: {
            en_us: "Spells",
            pt_br: "Magias"
        }, 
        id: 1 
    },
    { 
        name: {
            en_us: "Users",
            pt_br: "Usuários"
        }, 
        id: 2 
    },
]

class AdministrationContent extends Component {

    constructor(props) {
        super(props)

        this.state = {
            currentTab: 1
        }

        this.classes = props.classes

        this.renderTabs = this.renderTabs.bind(this)
        this.handleChange = this.handleChange.bind(this)
        this.renderTabContent = this.renderTabContent.bind(this)
    }

    handleChange = (event, newValue) => this.setState({currentTab: newValue})

    renderTabs() {

        return (
            <div className={this.classes.tabsWrapper}>
                <Tabs
                    value={this.state.currentTab}
                    onChange={this.handleChange}
                    variant="scrollable"
                    scrollButtons="auto"
                    indicatorColor="primary"
                    >
                    {
                        tabs.map((i, k) => <Tab key={k} label={i.name[this.props.language.selected]} value={i.id}></Tab>)
                    }
                </Tabs>
            </div>
        )
    }

    renderTabContent() {
        return this.state.currentTab === 1 
            ? <SpellArea/>
            : <UserArea/>
    }

    render() {
        return (
            <div className={this.classes.page}>
                {
                    this.renderTabs()
                }
                {
                    this.renderTabContent()
                }
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({}, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(AdministrationContent))