import React from "react"
import { Table, TableBody, TableCell, TableHead, TableRow, Paper } from "@material-ui/core"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { withRouter } from "react-router-dom"
import { withStyles } from "@material-ui/core/styles"
import { KeyboardArrowLeftOutlined, KeyboardArrowRightOutlined } from "@material-ui/icons"
import { getPagedSpellsAction, changeRowsPerPageAction } from "../../../actions"
import { APP_TEXTS } from "../../../constants"

const styles = theme => ({
    root: {
        width: "100%",
        marginTop:3,
        overflowX: "auto",
    },
    table: {
        minWidth: 650,
    },
    actionButton: {
        border: "none",
        outline: "none",
        background: "unset"
    },
    tableControl: {
        display: "flex",
        justifyContent: "center",
        alignItems: "center"
    }
})

class SpellTable extends React.Component {

    constructor(props) {
        super(props)

        this._calculateWinRate = this._calculateWinRate.bind(this)
        this._renderTable = this._renderTable.bind(this)
        this._renderTableControls = this._renderTableControls.bind(this)
        this._getPage = this._getPage.bind(this)
    }

    componentDidMount() {
       this._getPage()
    }

    _getPage(page = 1) {
        this.props.getPagedSpellsAction({
            pageSize: this.props.spellArea.pageSize,
            pageNumber: page,
        })
    }

     _calculateWinRate = row => 
        (((row.character.wins * 100) / row.character.battles) || 0).toPrecision(2)

    _renderTableControls(classes) {
        return (
            <div className={classes.tableControl}>
                <button className={classes.actionButton} onClick={() => 
                    this._getPage(this.props.spellArea.pageNumber - 1 ? this.props.spellArea.pageNumber - 1 : 1)
                }
                    disabled={this.props.spellArea.pageNumber <= 1}
                >
                    {
                        <KeyboardArrowLeftOutlined/> 
                    }
                </button>
                <button className={classes.actionButton}> {this.props.spellArea.pageNumber} {APP_TEXTS.ofLabel[this.props.language.selected]} {this.props.spellArea.pageCount} </button>
                <button className={classes.actionButton} onClick={() => 
                    this._getPage(this.props.spellArea.pageNumber + 1)
                }
                    disabled={this.props.spellArea.pageNumber === this.props.spellArea.pageCount}
                >
                    {
                        <KeyboardArrowRightOutlined/>
                    }
                </button>
            </div>
        )
    }

    _renderTable(classes, rows) {
        debugger
        return (
            <Table className={classes.table}>
                <TableHead>
                    <TableRow>
                        <TableCell align="center"> {APP_TEXTS.spellnameLabel[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.baseDamageLabel[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.baseManaCostLabel[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.elementsText[this.props.language.selected]} </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map(row => (
                        <TableRow key={row.name}>
                            <TableCell component="th" scope="row" align="center">
                                {row.name}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.baseDamage}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.baseManaCost}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.elements}
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        )
    }

    render() {
        const { classes, ...props } = this.props
        const rows = props.spellArea.spells

        return (
            <Paper className={classes.root}>
                { this._renderTable(classes, rows) }
                { this._renderTableControls(classes) }
            </Paper>
        )
    }
}

const mapStateToProps = (state) => ({
    spellArea: state.spellAreaReducer,
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        getPagedSpellsAction,
        changeRowsPerPageAction
    }, dispath)

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(SpellTable)))
