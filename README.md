# Sim-Pathie

Une fois le projet importé sous Unity ajouter le package GoogleVR ainsi que la librairie LibPD.
LibPD ne compile pas en 64 bits mais fonctionne parfaitement une fois build sous android 32 bits.

GoogleVR : https://github.com/googlevr/gvr-unity-sdk/releases
LibPD : https://github.com/irllabs/libpd4unity-starter/tree/master/Assets

Project Settings dans Unity avant de build:

Player > Resolution and Presentation > Orientation
set Default Orientation to Portrait

Player > XR Settings
check Virtual Reality Supported
add None first then add Cardboard
