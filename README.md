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

# Compiling AR for iOS

## Compatibility

In order to compile the ARScene for an iOS device, one must use a computer with the macOS system, with both Unity and Xcode installed and up-to date. The process of compilation involves first building the Unity project into an Xcode project, then compiling the Xcode project for the target iOS device.

At the time of writing, devices which support ARKit are limited to: iPhone 6S, iPhone SE, iPhone 7, iPhone 8, iPhone X and the respective Plus models.

## Unity

In Unity, one must ensure that the correct build settings are used. These settings persist through builds, which means should only have to be changed once when the Unity project is created.

Firstly, iOS must be selected in the Platform window, followed by clicking the 'Switch Platform' button. This commences a lengthy process, however this must only be done once as all testing is done using the Unity player or the iOS build.

After the target platform has been switches to iOS, an option in the 'Player Settings' must be set, 'Camera Usage Description'. One must ensure that this is not empty, however the extent of usage of this is simply the string shown on the screen when the user is prompted to allow the application to use the camera. In this project, this field has been set to 'Augmented Reality'.

Following this, the correct scene must be ticked in the 'Scenes to Build' window. After these steps have been completed, the project can be safely built.

## Xcode

In Xcode, several settings must be changed in the 'Project Settings' Page. These are reset to their default values each time the Unity project is built, meaning they must be set after each build.

Firstly, a development team must be assigned to the project. This requires the developer to have an Apple ID, which is free of charge; a personal team can be used. The bundle identifier must also be set; this must be a unique identifier such as com.ivvr.arscene or com.ivvrgrp.arscene.

Once these two settings have been changed, the Xcode project can be compiled to the iOS device.

## Known Issues

Most issues can be resolved by performing the following steps:

* Quit Xcode, using cmd + q.
* Disconnect iPhone.
* Connect iPhone and turn Xcode back on.

However, some issues persist until the device is disconnected and restarted. These include:

* `<name>’s iPhone is busy: Waiting for Device`
* `<name>’s iPhone is busy: Xcode will continue when <name>’s iPhone is finished.`

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

It is currently possible for enemy capes to get trapped inside their body colliders or have them trapped on the wrong side of the collider.
