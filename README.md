# SoilMoistureChanger

SoilMoistureChanger is a Timberborn mod that alters the values used to determine how far land will irrigate from water.

# Usage

There are three values to alter, listed below:
* MoistureDistance: How far the water will irrigate land (Default 16)
* UphillPenalty: How much going up a hill costs in irrigation reach (Default 6)
* DroughtMoistureMultiplier: Number by which MoistureDistance is multiplied during the drought. 0.5 equals half (Default 1)

Change the value of of the variables in the config, which is probably in BepInEx\plugins\SoilMoistureChanger\configs\SoilMoisture.json

If the config is not showing, try to launch the game and start up a save, that should create it.

# Issues

If there's a warning message in the log about a missing JSON property on game launch, delete the config file and restart the game to recreate it.

# Changelog

## v1.0.1 - 9.10.2022
- Added option to create Drought Moisture Multiplier

## v1.0.0 - 6.10.2022
- Added option to alter UphillPenalty

## v0.0.1 - 5.10.2022
- Initial release