import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { FormControl, InputLabel, Select, Input, Chip, MenuItem, TextField } from '@material-ui/core'
import { withStyles } from '@material-ui/core/styles'
import { elementList } from '../../../constants';  

const styles = {
    
}

class AddRulesComponent extends Component {

    constructor(props) {
        super(props)

        this.state = {
            rules: [],
        }

        this.setRule = this.setRule.bind(this)
        this.handleChange = this.handleChange.bind(this)
        this.addNewRule = this.addNewRule.bind(this)
        this.renderFormNewRule = this.renderFormNewRule.bind(this)
    }

    setRule(rule) {
        const rules = this.state.rules.filter(r => r.id !== rule.id);
        rules.push(rule);

        this.setState({
            rules
        });
    }

    handleChange(event, id) {
        debugger;
    }

    addNewRule() {
        const rule = {
            id: this.state.rules.length,
            operator: 0,
            weatherCondition: 0
        }

        this.setRule(rule);
    }

    renderFormNewRule(id) {
        return (
            <div>
                <TextField 
                    id="name"
                    type="number"
                    value={this.state.baseManaCost || 0}
                    label="base mana cost"
                    required
                    name="baseManaCost"
                    margin="dense"
                    onChange={this.onChangeInput}
                    fullWidth={false}
                />
            </div>
        )
    }

    render() {
        const { classes } = this.props;

        return (
            <div>

            </div>                 
        )
    }
}

const mapStateToProps = state => ({
    
})

const mapDispatchToProps = dispath =>
    bindActionCreators({}, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(AddRulesComponent))