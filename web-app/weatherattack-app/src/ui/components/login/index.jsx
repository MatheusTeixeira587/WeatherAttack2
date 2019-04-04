import React, { Component } from 'react'
import { TextField, Button, Grid, FormLabel } from '@material-ui/core'

const styles = {
  loginContainer: {
    padding: '40px'
  },
  button:{
    marginTop: '8px'
  }
}

export class LoginComponent extends Component {
  
  render() {
    return (
      <Grid
        component="div"
        container
        direction="column"
        alignContent="center"
        alignItems="center"
        justify="center"
        lg={12}
        sm={12}
        item
        style={styles.loginContainer}
      >
        <Grid
          component="div"
          container
          direction="column"
          alignContent="center"
          alignItems="center"
          justify="center"
          item
          lg={12}
          sm={12}
        >
          <FormLabel          >
            <h1>Log in!</h1>
          </FormLabel>
          <TextField
            id="username"
            type="text"
            value={this.props.login.username || ''}
            label="username"
            required
            name="username"
            margin="dense"
            onChange={this.props.changeField}
            fullWidth={true}
          />
          <TextField
            id="password"
            type="password"
            value={this.props.login.password || ''}
            label="password"
            required
            name="password"
            margin="dense"
            onChange={this.props.changeField}
            fullWidth={true}
          />
          <Button
            disabled={!this.props.login.username || !this.props.login.password}
            variant="outlined"
            color="primary"
            onClick={this.props.requestLoginAction}
            style={styles.button}
            fullWidth={true}
          >
            <span> Login </span>
          </Button>
        </Grid>
      </Grid>
    )
  }
}
