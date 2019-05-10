import React, { Component } from 'react'
import { Grid, withStyles } from '@material-ui/core';

const styles = {
    dashboardContentWrapper: {
        flex: 1,
        margin: '10px',
        border: '1px solid red',
        height: '100%',
    }
}

class DashboardContentComponent extends Component {
  render() {

    const { classes } = this.props;

    return (
      <Grid className={classes.dashboardContentWrapper}>

      </Grid>
    )
  }
}

export default withStyles(styles)(DashboardContentComponent);