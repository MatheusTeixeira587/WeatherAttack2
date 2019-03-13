import React, { Component } from 'react'
import styled from 'styled-components'

const labelStyle = styled.label

export class Input extends Component {

  constructor(){
    super()

    this.isRequired = this.isRequired.bind(this);
  }

  isRequired(){
    if(this.props.isRequired){
      return (
        <input
          name={this.props.name}
          placeholder={this.props.placeholder}
          onError={this.props.onError}
          type={this.props.type}
          onChange={this.props.onChange}
          value={this.props.value}
          className={this.props.class}
          id={this.props.name}
          required
        />
      )
    } else {
      return (
        <input
          name={this.props.name}
          placeholder={this.props.placeholder}
          onError={this.props.onError}
          type={this.props.type}
          onChange={this.props.onChange}
          value={this.props.value}
          className={this.props.class}
          id={this.props.name}
        />
      )
    }
  }

  render() {
    return (
      <div>
        {this.isRequired()}
        <label for={this.props.name}>
          <span>{this.props.label}</span>
        </label>        
      </div>
      
    )
  }
}