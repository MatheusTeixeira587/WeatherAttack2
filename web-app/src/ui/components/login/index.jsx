import React, { Component } from "react"
import { TextField, Grid, FormLabel } from "@material-ui/core"
import { Button } from "../"
import { APP_TEXTS } from "../../../constants";

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
      >
        <Grid
          component="div"
          container
          justify="space-around"
          alignItems="center"
          item
          lg={10}
          sm={10}
        >
          <Grid
            justify="center"
            item
            container
            lg={12}
            sm={12}
          >
            <FormLabel          >
              <h1>{APP_TEXTS.loginPageText[this.props.language]}</h1>
            </FormLabel>
          </Grid>
          <Grid
            item
            container
            lg={12}
            sm={12}
          >
            <TextField
              id="username"
              type="text"
              value={this.props.login.username || ""}
              label={APP_TEXTS.usernameLabelText[this.props.language]}
              required
              name="username"
              margin="dense"
              onChange={this.props.changeField}
              fullWidth={true}
            />
          </Grid>
          <Grid
            container
            lg={12}
            sm={12}
            item
          >
            <TextField
              id="password"
              type="password"
              value={this.props.login.password || ""}
              label={APP_TEXTS.passwordLabelText[this.props.language]}
              required
              name="password"
              margin="dense"
              onChange={this.props.changeField}
              fullWidth={true}
            />
          </Grid>
            <Button
              disabled={!this.props.login.username || !this.props.login.password}
              variant="outlined"
              color="primary"
              onClick={() => this.props.requestLoginAction({username: this.props.login.username, password: this.props.login.password})}
              fullWidth={true}
              text={"Login"}
            />
        </Grid>
      </Grid>
    )
  }
}