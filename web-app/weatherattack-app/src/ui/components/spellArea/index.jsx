import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { withStyles } from '@material-ui/core/styles'
import { withRouter } from 'react-router-dom'
import { AddSpellComponent, Button } from '../../components'

const styles = {
    component: {
        width: '90%',
        flex: 1,
        display: 'flex',
        flexDirection: 'column',
        backgroundColor: 'white',
        marginTop: 10
    },
    actionBar: {
        marginBottom: 5
    },
    spellComponentWrapper: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    }
}

class SpellArea extends Component {
   
    render() {
        const { classes } = this.props;
        return (
            <div className={classes.component}>
                <div className={classes.actionBar}>
                    <Button 
                        disabled={false}
                        variant="outlined"
                        color="primary"
                        onClick={() => console.log('clicked')}
                        fullWidth={false}
                        text={"Add a new one!"}
                    />
                </div>
                <div className={classes.spellComponentWrapper}>
                    <AddSpellComponent />
                </div>                
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    
})

const mapDispatchToProps = dispath =>
    bindActionCreators({}, dispath)

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(SpellArea)));