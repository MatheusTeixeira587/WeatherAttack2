import React, { Component } from 'react';
import Logo from '../../../static/img/logo.svg';
import { Grid, Card, CardContent, CardMedia, Typography } from '@material-ui/core';

export class WeatherCard extends Component {

  constructor(props) {
    super(props)

    this.state = {
      temperatura: 0,
      cidade: "cidade",
      icon: "icon",
      velocidade:"velocidade",
      situacao:"situacao"
    }
  }

  render() {
    return (
        <Card
          style={
            {
              zIndex: '-9999',
              width: '100%',
              display: 'flex',
              flexDirection: 'column'
            }
          }
          lg={3}
        >
          <Grid
            component="div"
            item
            container
            lg={3}
            direction="column"
          >
            <CardContent
              style={{flex: '1 0 auto'}}
            >
              <Typography component="h4" variant="h4">
                {this.state.temperatura + "°C"}
              </Typography>
              <Typography variant="subtitle1">
                {this.state.situacao}
              </Typography>
              <Typography variant="subtitle2">
                {this.state.cidade}
              </Typography>
            </CardContent>     
          </Grid> 
              <CardMedia
                style={{background:'cover'}}
                image="../../../static/img/logo.svg"
              >
                aaaaaaaaaaaaa
              </CardMedia>
        </Card>
    )
  }
}
