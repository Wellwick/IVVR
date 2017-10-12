# Starting SteamVR

To boot Steam from the terminal type `steam`.
Either provide your own personal login, or use the group account:

> Username: ivvrgrp
> Password: r3a7itY#

SteamVR is already installed in the local area, on the beta branch. If needed, it can be found at `~/.local/share/Steam/steamapps/common/SteamVR`.

Make sure that everything is properly connected with the Vive. A light will be displayed on the left hand side of the Vive when it is properly connected and the controllers can be activated by pressing the desktop button (below the trackpad). If the controllers do not activate, they may need charging.

When setting up the base stations again, the room setup will likely have to be completed again. They work best when less than 5 metres apart.

Beware the mesh at the edge of your area. It has been setup that way for a reason. Don't go and kill your group members.

# Booting Unity with SteamVR

In order to have the Vive running within Unity, it is booted through the Steam Runtime. The aliased command `unity` can be used.

For a scene to be able to catch the Vive's input, the default camera must be removed and the Prefab CameraRig must be placed into the scene. When the scene is run, the Vive will catch the input and SteamVR will show that `Unity` is running.

# Current Problems

The audio jack for the Vive does not seem to be working. For now, will need a long cable to attach to the tower in order to hear audio.
