import React, { Component } from 'react'
import { Grid, TextField, FormLabel } from '@material-ui/core'
import { Button } from '../';

export class RegisterComponent extends Component {
  
    constructor(props){
      super(props)

      this.shouldDisableRegisterButton = this.shouldDisableRegisterButton.bind(this);
    }

    shouldDisableRegisterButton() {
      return (
        !this.props.login.username || 
        !this.props.login.password || 
        !this.props.login.email || 
        !this.props.login.confirmPassword
        ) || (
          this.props.login.password !== this.props.login.confirmPassword
        )
    }

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
      >
        <Grid
          component="div"
          container
          direction="column"
          alignContent="center"
          alignItems="center"
          justify="center"
          item
          lg={10}
          sm={10}
        >
          <FormLabel>
            <h1>Create your account!</h1>
          </FormLabel>
          <TextField
            id="email"
            type="email"
            value={this.props.login.email || ''}
            label="email"
            required
            name="email"
            margin="dense"
            onChange={this.props.changeField}
            fullWidth={true}
          />
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
          <TextField
            id="confirmPassword"
            type="password"
            value={this.props.login.confirmPassword || ''}
            label="password"
            required
            name="confirmPassword"
            margin="dense"
            onChange={this.props.changeField}
            fullWidth={true}
          />
          <Button
            disabled={this.shouldDisableRegisterButton()}
            variant="outlined"
            color="primary"
            onClick={() => this.props.requestRegisterAction({
                username: this.props.login.username,
                email: this.props.login.email,
                password: this.props.login.password
            })}
            fullWidth={true}
            text={"Register"}
          />
        </Grid>
      </Grid>
    )
  }
}