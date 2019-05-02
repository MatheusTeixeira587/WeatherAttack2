import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';

const styles = theme => ({
  button: {
    margin: theme.spacing.unit,
    marginTop: '8px'
  },
  input: {
    display: 'none',
  },
});

function OutlinedButtons(props) {
  const { classes } = props;
  return (
      <Button 
        variant={props.variant} 
        color={props.color}
        className={classes.button}
        onClick={props.onClick}
        fullWidth={props.fullWidth}
        disabled={props.disabled}
    >
        <span>{props.text}</span>
    </Button>
  );
}

OutlinedButtons.propTypes = {
  classes: PropTypes.object.isRequired,
  variant: PropTypes.string.isRequired,
  color: PropTypes.string.isRequired,
  text: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  fullWidth: PropTypes.bool.isRequired,
};

export default withStyles(styles)(OutlinedButtons);