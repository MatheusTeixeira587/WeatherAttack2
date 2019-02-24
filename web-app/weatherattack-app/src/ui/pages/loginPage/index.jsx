import React, { Component } from 'react'
import { connect } from 'react-redux'
import { showLoaderAction, hideLoaderAction } from '../../../actions/loader';
import { bindActionCreators } from 'redux'

class LoginPage extends Component {

  constructor(props) {
    super(props)
    this.state = {
    } 

    this.handleClick = this.handleClick.bind(this);
  }

  handleClick(){
    this.props.showLoaderAction()
    setTimeout(() => {
      this.props.hideLoaderAction()
    }, 5000);
  }
  
  render() {
    return (
      <div className="container-login">
      <button text="a" onClick={this.handleClick}/>
        {console.log(this)}
      </div>
    )
  }
}

const mapStateToProps = state => ({ 
  loader: state.loaderReducer 
});

const mapDispatchToProps = dispath =>
bindActionCreators({showLoaderAction, hideLoaderAction}, dispath)

export default connect(mapStateToProps,mapDispatchToProps)(LoginPage)