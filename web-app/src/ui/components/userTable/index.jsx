import React from "react"
import { Table, TableBody, TableCell, TableHead, TableRow, Paper } from "@material-ui/core"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { withRouter } from "react-router-dom"
import { withStyles } from "@material-ui/core/styles"
import { KeyboardArrowLeftOutlined, KeyboardArrowRightOutlined } from "@material-ui/icons"
import { getPagedUsersAction, changeRowsPerPageAction } from "../../../actions"
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

class UserTableComponent extends React.Component {

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
        this.props.getPagedUsersAction({
            pageSize: this.props.userArea.pageSize,
            pageNumber: page,
        })
    }

     _calculateWinRate = row => 
        (((row.character.wins * 100) / row.character.battles) || 0).toPrecision(2)

    _renderTableControls(classes) {
        return (
            <div className={classes.tableControl}>
                <button className={classes.actionButton} onClick={() => 
                    this._getPage(this.props.userArea.pageNumber - 1 ? this.props.userArea.pageNumber - 1 : 1)
                }
                    disabled={this.props.userArea.pageNumber <= 1}
                >
                    {
                        <KeyboardArrowLeftOutlined/> 
                    }
                </button>
                <button className={classes.actionButton}> {this.props.userArea.pageNumber} {APP_TEXTS.ofLabel[this.props.language.selected]} {this.props.userArea.pageCount} </button>
                <button className={classes.actionButton} onClick={() => 
                    this._getPage(this.props.userArea.pageNumber + 1)
                }
                    disabled={this.props.userArea.pageNumber === this.props.userArea.pageCount}
                >
                    {
                        <KeyboardArrowRightOutlined/>
                    }
                </button>
            </div>
        )
    }

    _renderTable(classes, rows) {
        return (
            <Table className={classes.table}>
                <TableHead>
                    <TableRow>
                        <TableCell align="center"> {APP_TEXTS.usernameTableHeadLabel[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.permissionLabel[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.medalsLabeltext[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.battlesLabelText[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.winsLabelText[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.lossesLabelText[this.props.language.selected]} </TableCell>
                        <TableCell align="center"> {APP_TEXTS.winRateLabel[this.props.language.selected]} </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map(row => (
                        <TableRow key={row.username}>
                            <TableCell component="th" scope="row" align="center">
                                {row.username}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.permissionLevel === 0 ? <span> {APP_TEXTS.noneLabel[this.props.language.selected]} </span> : <span> Admin </span>}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.character.medals}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.character.battles}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.character.wins}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                {row.character.losses}
                            </TableCell>
                            <TableCell component="th" scope="row" align="center">
                                { this._calculateWinRate(row) || 0 }%
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        )
    }

    render() {
        const { classes, ...props } = this.props
        const rows = props.userArea.users

        return (
            <Paper className={classes.root}>
                { this._renderTable(classes, rows) }
                { this._renderTableControls(classes) }
            </Paper>
        )
    }
}

const mapStateToProps = (state) => ({
    userArea: state.userAreaReducer,
    language: state.languageReducer
})

const mapDispatchToProps = dispath =>
    bindActionCreators({
        getPagedUsersAction,
        changeRowsPerPageAction
    }, dispath)

export default withStyles(styles)(withRouter(connect(mapStateToProps, mapDispatchToProps)(UserTableComponent)))
