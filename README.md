# Starting SteamVR

Steam VR can be booted with the aliased command `VR`. Make sure that you always run Room Setup when you set up the lighthouses again and make sure to have the tracker's dongle attached to the machine which is running SteamVR. Also make sure that you run VR before you run any VR programs, or it will break!

## Running Steam

> Note: Currently there is a problem with Steam not being able to load due to missing libraries. Additionally, any updates that are pushed through for SteamVR is likely to cause major problems with unresponsive programs.

> DO NOT RUN STEAM IF YOU DON'T KNOW WHAT YOU ARE DOING!

To boot Steam from the terminal type `steam`.
Either provide your own personal login, or use the group account:

> Username: ivvrgrp

> Password: r3a7itY#

## SteamVR additional information

SteamVR is already installed in the local area, on the beta branch. If needed, it can be found at `~/.local/share/Steam/steamapps/common/SteamVR`.

Make sure that everything is properly connected with the Vive. A light will be displayed on the left hand side of the Vive when it is properly connected and the controllers can be activated by pressing the desktop button (below the trackpad). If the controllers do not activate, they may need charging, which can take a long time (3+ hours).

When setting up the base stations again, the room setup will likely have to be completed again. They work best when less than 5 metres apart.

Beware the mesh at the edge of your area. It has been setup that way for a reason. Don't go and kill your group members.

# Unity

This is our engine for Virtual Reality development

## Booting Unity with SteamVR

In order to have the Vive running within Unity, it is booted through the Steam Runtime. The aliased command `unity` can be used.

For a scene to be able to catch the Vive's input, the default camera must be removed and the Prefab CameraRig must be placed into the scene. When the scene is run, the Vive will catch the input and SteamVR will show that `Unity` is running.

## Editing Scripts from Unity

The Unity script editor default has been set to VSCode. Double clicking on any `.cs` file will automatically open up the projects directory for handing files in VSCode.

# Connecting via mobile

The IP you will be using most will start as `137.205.112.XX`. XX tends to align with the viglab-## machine that you are at, displayed on the bash terminal. You can also use `ifconfig` to get information on what your current IP is. Keep in mind the ports that are opened on the DCS machines are in the range 9090-9099, both on TCP and UDP (Unity uses UDP).

# Recording and viewing video

The `record <FILENAME>` can be used to record the screen to the designated fileplacement. It's recommended that you save videos to /var/tmp/ as writing to the disk will be faster than writing to the network.

To view the video after, make use of `mplayer <FILENAME>` to view the video. The file recording is set to be 720p, however this can be edited by looking at the documentation for ffmpeg.

If you need to export the video at all, you can make use of mencoder to convert the video to a more usable format. Have a look at `mencoder -ovc help` for the list of available codecs.

# Current Problems

The audio jack for the Vive does not seem to be working. For now, will need a long cable to attach to the tower in order to hear audio.

If you encounter the error `It looks like another Unity instance is running with this project open.` when opening a Unity project, navigate to it's directory and delete the Temp/UnityLockfile.

If you are having trouble running code in relation to objects in Unity, make sure scripts and appeneded public GameObjects/variables are properly attached to the GameObject in the scene.

If there is ever a problem with viewing anything in the Vive headset, you can close everything or just the VR programs with `endAll` and `endVR` respectively. Should the problem persist, or the computer is running slowly, it is likely a good idea to log out and back in again or restart the computer.

Occassionally, a new driver update comes out for the 1050ti's which are used in 0.01. After the department's technical team push this update through, each machine needs to be restarted to install the new driver. If you are encountering problems (particularly Compositor ones) this may well be caused by a required driver update, but check with others if need be. Computers which are regularly used (ie viglab-41 through to viglab-43) tend to be up to date.
