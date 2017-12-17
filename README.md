# Cities Skyline: Extended Game Options Mod

This is a collection of mods and features that add usefull options to the game.

## Pause on load
Automatically set pause when the game is loaded or started.

The idea was taken from the Pause on load mod by MrLawbreaker (however the implementation is completely different).

## Enable achievements
Usually you cannot get the steam achievements when you are using mods. If this option is enabled, you would be able to get the steam achievements.

The idea was taken from the Mod Achievement Enabler (it is just one line of code).

## Info View buttons are always enabled
Most info buttons (such as education, crime, land value, etc.) are disabled until you unlock a corresponding milestone. If this option is enabled, all the info buttons would be enabled from the beginning.

The idea was taken from the Info View Button Enabler mod by Zuppi (the implementation is different though).

## Basic roads are available from the start
This option unlocks the "Basic Road Created" milestone from the beginning.
This is very minor thing that removes the requirement to build a piece of two-lane road before building any other types of roads.

## Enable random disasters for scenarios
If this option is enabled, random disasters would occur even if you are playing a scenario.
(In the vanilla game disasters that occur when you are playing a scenario are only the scripted ones, i.e. defined by the scenario creator. The random disasters do not occur.)

Please remember that you still have to enable random disasters in the game options.

The option is disabled by default because the enabling random disasters may prevent you from reaching a scenario goal.

The functionality is the same as in Disasters Enabler Mod (my another mod).
http://steamcommunity.com/sharedfiles/filedetails/?id=823348129

## Available areas
In the unmodded game you can unlock and bue only 9 areas on the map. There are a lot of mods that allow you to get more (25 or 81) areas.
With this option you can select how many areas (from 1 to 25) can be unlocked. The value can also be changed during the game.

Most people wants 25 areas - this is set as the default value.

The areas beyong the default 9 areas will be available to purchase after the last milestone is reached.

## Resources depletion rate
This feature is based on the build-in Unlimited Oil and Ore from the vanilla game. Unlike the build-in version, here you can adjust the rate with wich the resources are depleating.

The left position of the sliders (0%) corresponds to unlimited use (resources will not deplete). The right position (100%) set the same depletion rate as in the unmodded game, i.e. fast.
Default value is set to 50% so that Oil and Ore are depleating with half speed comparing to that of the vanilla game.

### Why this mod was created?

Some mods, which I often use, are so small that it is simpler to add a couple of lines in the code rather than subscribe. Sometimes I also wish different behaviour or more flexible settings.

After the collection of options had grown big enough, I decided to combine them into a separate mod. That's why this mod was created.