# Cities Skyline: Extended Game Options Mod

This mod is a collection of small features that adds useful functionality to the game.

## Pause on load
Automatically set pause when the game is loaded or started.

The idea was taken from the Pause on load mod by MrLawbreaker (however the implementation is completely different).

## Enable achievements
Usually you cannot get the steam achievements when you are using mods. If this option is enabled, you would be able to get the steam achievements.

The idea was taken from the Mod Achievement Enabler (it is just one line of code).

## Info View buttons are always enabled
Most info buttons (such as education, crime, land value, etc.) are disabled until you unlock a corresponding milestone. If this option is enabled, all the info buttons are enabled from the beginning.

The idea was taken from the Info View Button Enabler mod by Zuppi (the implementation is different though).

## Unlocks
### Basic roads are available from the start
This option unlocks the "Basic Road Created" milestone from the beginning.
This is very minor thing that removes the requirement to build a piece of two-lane road before building any other types of roads. Grateful to BlueSteelAUS for Unlock Basic Roads mod.

### Train tracks can be constructed without a train station
and
### Metro tunnels can be constructed without a metro station
In the vanilla game you have to build a station before constructing a piece of railroad or metro tunnel. Checking these options removes this limitation. Grateful to TPB for Unlock Tracks + Metro Tunnels mod.

### Milestone unlock
Unlock everything up to a particular milestone. Select Megalopolis to unlock all.

All unlock options will take effect only after reloading the game.

## Full refund
Bulldozing structures built recently gives full refund (you can build and erase without loosing money). Consider this as an "undo" feature.

## Enable random disasters for scenarios
If this option is enabled, random disasters would occur even if you are playing a scenario.
(In the vanilla game disasters that occur when you are playing a scenario are only the scripted ones, i.e. defined by the scenario creator. The random disasters do not occur.)

Please remember that you still have to enable random disasters in the game options.

The option is disabled by default because random disasters may make reaching the scenario goals more difficult.

This feature is also implemented as a separate mod.
Disasters Enabler Mod:
http://steamcommunity.com/sharedfiles/filedetails/?id=823348129

## Available areas
In the unmodded game you can unlock (purchase) only 9 areas on the map. With this option you can select how many areas (from 1 to 25) can be unlocked. The value can also be changed during the game.

Most people wants 25 areas - this is set as the default value.

The areas beyond the default 9 areas will be available to purchase after the last milestone is reached.

You should disable this option if you are using 81 tiles mod or other mods that change the number of available areas (just uncheck "Change available areas...").

## Resources depletion rate
This feature is based on the native Unlimited Oil and Ore mod from the vanilla game. Unlike the native version, here you can adjust the rate with which the resources are depleting.

The left position of the sliders (0%) corresponds to unlimited use (resources will not deplete). The right position (100%) sets the same depletion rate as in the unmodded game, i.e. fast.
Default value is set to 50% so that Oil and Ore are depleting with half speed comparing to that of the vanilla game.

### Why this mod was created?
Some mods, which I often use, are so small that it is simpler to add a couple of lines in the code rather than subscribe. Sometimes I also wish different behaviour or more flexible settings.

After my collection of options had grown big enough, I decided to combine them into a separate mod. That's why this mod was created.
