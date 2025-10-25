# Shortcut Enter PlayMode

## Features

* Use `F5` shortcut key to enter PlayMode with your scene.
* When exit play mode, automatically back to your editting scene (before enter play mode) without losing anything you modified.

## How to set a startup scene

**Only once**
1. Right click at Project window.
2. `Create` > `Editor Extend` > `Enter Play Mode Settings` to create asset file.
3. Leave file name as default one; `EnterPlayModeSettings.asset`.
4. Move file to `Assets/Editor` folder.
   * The path MUST be `Assets/Editor/EnterPlayModeSettings.asset`.

**Set a scene**
1. D&D your scene file to `Scene` field in settings inspector.
2. Press `F5` and HERE WE GO !

## Installation

### Method 1: Unity Package Manager

### Install via git URL

1. `Window` > `Package Manager` > `+` sign > `Install package from git URL...`
2. Enter `https://github.com/axess-kun/unity-shortcut-playmode.git?path=Packages/me.axess.editorapp.enterplaymode`
3. Click `Install`.

### Method 2: Copy & Paste

1. Clone this repository.
2. Copy `Packages/me.axess.editorapp.enterplaymode` to your Unity `Assets` folder.
3. Edit whatever you want; like shortcut key, no settings asset needed, blah blah blah.

## License

This library is UNLICENSED.
