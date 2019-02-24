import React, { Component } from 'react'

export class Login extends Component {

  constructor(props) {
    super(props)
  
    this.state = {
       email:"",
       username:"",
       password:"",
       isValid:"",
    }

    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }
  
  render() {
    return (
      <div>
        
      </div>
    )
  }
}
