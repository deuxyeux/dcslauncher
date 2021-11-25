# DCS Launcher
DCS Launcher was created to automate the process of starting DCS World along with all related utilities.

## Initial setup:
* Specify the main folder of your DCS installation (e.g: C:\Program Files\Eagle Dynamics\DCS World) and base DCS Saved Games Folder (e.g: C:\Users\Username\Saved Games\DCS).
* Specify any additional utilities.

### The launcher supports two modes:
 * Flatscreen mode is the default mode and uses DCS World settings from Base Saved Games folder.
 * VR mode requires a separate Saved Games folder to be specified. It can be populated in the Miscellaneous menu.

# Settings Menu

Resolution, Resizing & Reposition Settings:
Allow repositioning & resizing of DCS World window and splash screen in both modes. A custom DCS resolution can be specified (useful for making screen space for debugging windows).

## Miscellaneous Options
Minimize JetSeat Handler (available only when SimShaker is in use): minimizes the JetSeat Handler window after SimShaker startup.
Delete tracks older than X days: deletes .trk files from the Base Saved Games folder which are older than specified number of days.
Delete Older Tacview ACMI files: deletes Tacview files older than specified number of days from %userprofile%\Documents\Tacview folder.
High CPU priority for DCS: temporarily adds a registry entry to enable high CPU priority for DCS.exe. The entry is removed after DCS is stopped.
High Performance Power Plan: switches the system power plan to High Performance on DCS startup. The profile is switched back to Balanced when DCS is stopped.
Auto close SimpleRadio: tries to close SRS-Client on DCS exit if it was automatically started with SRS Auto Connect option.

## Utilities
Specifies utilities to use on DCS start.
The TrackIR & opentrack utilities won't be started in VR mode.
VoiceAttack can be specified either as main VoiceAttack executable or VAICOM PRO watchdog executable.

## Hardware Options
Monitors WMI for currently available USB devices. Two device groups are available: Controllers & HMD for controller and VR headset monitoring respectively. The lists are populated by Device Instance paths. If one or mode devices in the list aren't available, the main Start button is blocked until it becomes available. The scanning interval is 1 second.

## SteamVR Settings
Lighthouse Control: when checked, automates the power-on and power-off of SteamVR 2.0 lighthouses. Uses the lighthouse-v2-manager utility by nouser2013. (https://github.com/nouser2013/lighthouse-v2-manager/). Use the "Discover" button and copy-paste the lighthouse hardware addresses to the appropriate boxes and enable them.
Reposition: repositions SteamVR window on startup.
FSR: Settings related to fholger's OpenVR FSR mod. It is automatically detected and enabled when the .dll is installed in DCS World/bin folder. Tooltips for the settings are displayed on mouse over.

## Pimax Settings (WIP)
Use PiTool: Starts and minimizes PiTool utility on VR mode.
PiService Control: Starts PiService service instead of PiTool.
Options are mutually exclusive.

## VR Mode
Adds a command-line argument to DCS.exe forcing a specific VR-mode.

## GPU Overclocking
Enables GPU overclocking/underclocking/voltage control. Uses NVIDIA Inspector by Orbmu2K (https://techpowerup.com/download/nvidia-inspector/). The settings are applied on DCS start and reset to defaults on DCS stop.

## Auto close Launcher on DCS exit
Autocloses the launcher when DCS has exited.

## Miscellaneous Menu
Delete fxo:
Deletes fxo files from the folder specified by the Browse button. You can also specify the name by typing it in (e.g DCS). It uses the user "Saved Games" folder as a base folder. A confirmation dialog will display the number of files to be deleted.
Delete metashaders:
Deletes metashader files from the folder specified by the Browse button. You can also specify the name by typing it in (e.g DCS). It uses the user "Saved Games" folder as a base folder. A confirmation dialog will display the number of files to be deleted.
Disable Dynamic Ticks & HPET:
Disables dynamic ticks with bcdedit which is a popular system tweak to reduce stutters.
Enable Dynamic Ticks & HPET:
Enables dynamic ticks with bcdedit.
Splash Image Functions:
Allows to choose a custom splash image with a specified size. A default and "VR" preset splashes are provided. The "VR" splash image is a small image with size equal to the SteamVR monitor window.
