import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { FormControl, InputLabel, Select, Input, Chip, MenuItem, TextField } from '@material-ui/core'
import { withStyles } from '@material-ui/core/styles'
import { elementList } from '../../../constants';  
import { AddRulesComponent, Button } from '..';
import { addSpellAction } from '../../../actions';

const styles = {
    menuItem: {
    },
    formWrapper: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center'
    },
    numericInputWrapper: {
        display: 'flex',
        justifyContent: 'space-between',
        width: '100%'
    },
    addRulesComponentWrapper: {
        display: 'flex',
        flexDirection: 'column',
        alignSelf: 'flex-start',
    }
}

class AddSpellComponent extends Component {

    constructor(props) {
        super(props)

        this.state = {
            spellname:"",
            baseDamage: 0,
            baseManaCost: 0,
            elements: 0,
            selectedElements: []
        }

        this.handleChange = this.handleChange.bind(this)
        this.setElement = this.setElement.bind(this)
        this.onChangeInput = this.onChangeInput.bind(this)
        this.sumSelectedElements = this.sumSelectedElements.bind(this)
        this.submitSpell = this.submitSpell.bind(this)
    }

    submitSpell() {

        debugger
        const spell = {
            Id: 0,
            Name: this.state.spellname,
            BaseDamage: parseInt(this.state.baseDamage),
            BaseManaCost: parseInt(this.state.baseManaCost),
            Element: this.sumSelectedElements(),
            Rules: [...this.props.rules.rules]
        }

        spell.Rules.forEach(r => r.value = parseInt(r.value));

        this.props.addSpellAction(spell);
    }

    setElement(event) {
        this.setState({
            selectedElements: event
        })
    }

    handleChange(event) {
        this.setElement(event.target.value);
    }

    onChangeInput(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    sumSelectedElements() {
        return this.state.selectedElements.map(e => e.value).reduce((e1, e2) => e1 + e2);
    }

    render() {
        const { classes } = this.props;
        return (
            <div className={classes.formWrapper}>
                <TextField 
                    id="name"
                    type="text"
                    value={this.state.spellname || ''}
                    label="spell name"
                    required
                    name="spellname"
                    margin="dense"
                    onChange={this.onChangeInput}
                    fullWidth={true}
                />
                <div className={classes.numericInputWrapper}>
                    <TextField 
                        id="name"
                        type="number"
                        value={this.state.baseDamage || 0}
                        label="base damage"
                        required
                        name="baseDamage"
                        margin="dense"
                        onChange={this.onChangeInput}
                        fullWidth={false}
                    />
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
                <FormControl 
                    fullWidth={true}
                >
                    <InputLabel htmlFor="select-multiple-chip">
                        Elements 
                    </InputLabel>
                    <Select
                        className={classes.menuItem}
                        multiple
                        value={this.state.selectedElements}
                        fullWidth={true}
                        onChange={this.handleChange}
                        input={<Input id="select-multiple-chip" />}
                        renderValue={
                            selected => (
                                <div>
                                {
                                    selected.map((i, k) => <Chip key={k} label={i.name} />)
                                }
                                </div>
                            )
                        }
                        >
                        {
                            elementList.map((i, k) => (
                                <MenuItem key={k} value={i}>
                                    {i.name}
                                </MenuItem>))
                        }
                    </Select>
                </FormControl>
                <div className={this.props.classes.addRulesComponentWrapper}>
                    <AddRulesComponent 
                    />
                </div>
                <Button 
                    disabled={false}
                    variant="outlined"
                    color="primary"
                    onClick={this.submitSpell}
                    fullWidth={false}
                    text={"Done"}
                />
            </div>
        )
    }
}

const mapStateToProps = state => ({
    rules: state.rulesReducer,
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        addSpellAction
    }, dispath)

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(AddSpellComponent))