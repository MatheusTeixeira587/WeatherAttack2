import React, { Component } from "react"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { TextField, Select, FormControl, MenuItem, InputLabel } from "@material-ui/core"
import { withStyles } from "@material-ui/core/styles"
import { DeleteOutlined, AddBoxOutlined } from "@material-ui/icons"
import { operators, weatherConditions, APP_TEXTS } from "../../../constants"
import { changeRuleAction, addRuleAction, removeRuleAction } from "../../../actions"

const styles = {
    ruleForm: {
        display: "flex",
        padding: 10,
        margin: 2
    },
    ruleFormFields: {
        minWidth: "30%",
    },
    valueInput: {
        margin: 0,
        marginTop: 3
    },
    rulesFormListWrapper: {
        display: "flex",
        flexDirection: "column",
        paddingTop: 5
    },
    deleteIcon: {
        border: "none",
        background: "inherit",
        cursor: "pointer"
    },
    addRuleButton: {
        display: "flex",
        border: "none",
        background: "inherit",
        width: "fit-content",
        cursor: "pointer",
    },
    addRuleButtonText: {
        alignSelf: "center",
    }
}

class AddRulesComponent extends Component {

    constructor(props) {
        super(props)

        this.addNewRule = this.addNewRule.bind(this)
        this.renderFormRule = this.renderFormRule.bind(this)
    }

    addNewRule() {
        const rule = {
            id: 0,
            operator: 0,
            weatherCondition: 0,
            value: 0
        }

        this.props.addRuleAction(rule)
    }

    renderFormRule() {
 
        return this.props.rules.rules.map((i, k) => {
            return (
                <div key={k} className={this.props.classes.ruleForm}>
                    <FormControl className={this.props.classes.ruleFormFields}>
                        <InputLabel htmlFor="weatherCondition"> {APP_TEXTS.weatherConditionLabel[this.props.language.selected]}  </InputLabel>
                        <Select
                            value={this.props.rules.rules[k].weatherCondition || 0}
                            onChange={(event => this.props.changeRuleAction(event, k))}
                            inputProps={{name: "weatherCondition", id:"weatherCondition"}}
                        >
                            {
                                weatherConditions.map((c, i) => <MenuItem key={i} value={c.value}>{c.name[this.props.language.selected]}</MenuItem>)
                            }
                        </Select>
                    </FormControl>
                    <FormControl className={this.props.classes.ruleFormFields}>
                        <InputLabel htmlFor="operator">{APP_TEXTS.operatorLabel[this.props.language.selected]}</InputLabel>
                        <Select
                            value={this.props.rules.rules[k].operator || 0}
                            onChange={(event => this.props.changeRuleAction(event, k))}
                            inputProps={{name: "operator", id:"operator"}}
                        >
                            {
                                operators.map((c,i) => <MenuItem key={i} value={c.value}>{c.name[this.props.language.selected]}</MenuItem>)
                            }
                        </Select>
                    </FormControl>
                    <TextField
                        id="name"
                        type="number"
                        value={this.props.rules.rules[k].value || 0}
                        label={APP_TEXTS.valueLabel[this.props.language.selected]}
                        required
                        name="value"
                        margin="dense"
                        onChange={
                            (event) => this.props.changeRuleAction(event, k)
                        }
                        fullWidth={false}
                        className={this.props.classes.valueInput}
                    />
                    <button
                        className={this.props.classes.deleteIcon}
                        onClick={
                            () => this.props.removeRuleAction(k)
                        }
                    > 
                        <DeleteOutlined 
                            titleAccess="delete button"
                        />
                    </button>
                </div>               
            )
        })
    }

    render() {
        return (
            <div className={this.props.classes.rulesFormListWrapper}>
                <button 
                    onClick={() => this.addNewRule()}
                    className={this.props.classes.addRuleButton}
                > 
                    <AddBoxOutlined
                        titleAccess="add new rule button"
                    />
                    <span className={this.props.classes.addRuleButtonText}>
                        {APP_TEXTS.addRuleText[this.props.language.selected]}
                    </span>
                </button>
                {
                    this.renderFormRule()
                }
            </div>                 
        )
    }
}

const mapStateToProps = state => ({
    rules: state.rulesReducer,
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        addRuleAction,
        removeRuleAction,
        changeRuleAction
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(AddRulesComponent))