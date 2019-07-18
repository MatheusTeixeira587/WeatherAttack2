import React, { Component } from "react"
import { connect } from "react-redux"
import { withStyles } from "@material-ui/core/styles"
import { Tabs, Tab } from "@material-ui/core"
import { bindActionCreators } from "redux"
import { SpellAreaComponent, UserAreaComponent } from "../../components"

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
            EN_US: "Spells",
            PT_BR: "Magias"
        }, 
        id: 1 
    },
    { 
        name: {
            EN_US: "Users",
            PT_BR: "Usuários"
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
        if(this.state.currentTab === 1) {
            return <SpellAreaComponent/>
        } else if (this.state.currentTab === 2) {
            return (<UserAreaComponent/>)
        }
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