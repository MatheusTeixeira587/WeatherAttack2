import React from "react"
import { Card, CardContent, CardMedia, Typography } from "@material-ui/core"
import PropTypes from "prop-types"
import { withStyles } from "@material-ui/core/styles"
import { CHARACTER, WINS, MEDALS, LOSSES, BATTLES } from "../../../static"
import { APP_TEXTS } from "../../../constants"

const styles= () => ({
  card: {
    display: "flex",
  },
  details: {
    display: "flex",
    flexDirection: "column",
  },
  content: {
    flex: "1 0 auto",
    display: "flex",
    flexDirection: "column",
    alignItems: "start"
  },
  cover: {
    width: "140px",
    filter: "drop-shadow(10px 1px 5px gray)",
    backgroundSize: "contain"
  },
  infoDetail: {
      marginLeft: "5px"
  }
})

function MediaControlCard(props) {
  const { classes, user, character, language } = props

  return (
    <Card className={classes.card}>
    <CardMedia
        className={classes.cover}
        image={CHARACTER}
        title="Profile pic"
      />
      <div className={classes.details}>
        <CardContent className={classes.content}>
          <Typography variant="h6" color="textPrimary">
            {user.username}
          </Typography>
          <Typography variant="subtitle2" color="textPrimary">
            <img src={BATTLES} alt=""/>
            <span className={classes.infoDetail}>
                {APP_TEXTS.battlesLabelText[language]}: {character.battles}
            </span>
          </Typography>
          <Typography variant="subtitle2" color="textPrimary">
            <img src={WINS} alt=""/>
            <span className={classes.infoDetail} >
                {APP_TEXTS.winsLabelText[language]}: {character.wins}
            </span>
          </Typography>
          <Typography variant="subtitle2" color="textPrimary">
            <img src={LOSSES} alt=""/>
            <span className={classes.infoDetail} >
                {APP_TEXTS.lossesLabelText[language]}: {character.losses}
            </span>
          </Typography>
          <Typography variant="subtitle2" color="textPrimary">
            <img src={MEDALS} alt=""/>
            <span className={classes.infoDetail} >
                {APP_TEXTS.medalsLabeltext[language]}: {character.medals}
            </span>
          </Typography>
        </CardContent>
      </div>
      
    </Card>
  )
}

MediaControlCard.propTypes = {
  classes: PropTypes.object.isRequired,
}

export default withStyles(styles)(MediaControlCard)