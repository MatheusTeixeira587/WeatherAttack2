import React, { Component } from 'react'
import { Loader } from "app-components";

export class LoginPage extends Component {

  constructor(props) {
    super(props)
  
    this.state = {
       loading:false
    }
  }
  
  render() {
    return (
      <div className="container-login">
        <Loader showLoader={this.state.loading}/>
      </div>
    )
  }
}
