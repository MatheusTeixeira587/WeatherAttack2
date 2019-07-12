import React from 'react'
import { withStyles, Button } from '@material-ui/core';
import PropTypes from 'prop-types';

const styles = ({

    button: {
        color: '#666666',
        fontFamily: 'Roboto',
        fontStyle: 'normal',
        lineHeight: 'normal',
        fontSize: '10px',
        border: 'none',
        backgroundColor: 'transparent',

        '&:hover': {
            textDecorationLine: 'underline',
            cursor: 'pointer',
            position: 'relative',        
            outline: 'none',
            border: 'none',
            backgroundColor: 'transparent',
        }
    }
})

const Link = (props) => {
    const { onClick, classes, message } = props

    return (
        <Button
            className={classes.button}
            onClick={onClick}
        >
            {message}
        </Button>
    );
}

Link.propTypes = {
    onClick: PropTypes.func.isRequired,
    message: PropTypes.string.isRequired,
};

export default withStyles(styles)(Link);