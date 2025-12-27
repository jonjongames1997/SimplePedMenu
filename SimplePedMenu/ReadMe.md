# Simple Ped Menu

Simple Ped Menu is a GTA V ScriptHookVDotNet script that provides a quick in-game menu to spawn and manage ped companions, favorite peds/vehicles, weapons, animations and other utilities.

Key features
- Spawn and manage a squad of companion peds (follow, guard, attack nearest, dismiss)
- Save and load squad presets
- Favorite peds and vehicles for quick access
- Weapon and prop weapon shortcuts
- Animations, animals, radio station and other utility menus
- Configurable options via `scripts/SimplePedMenu.ini`, including a safe `MaxCompanions` limit

Requirements
- ScriptHookV
- ScriptHookVDotNet
- LemonUI.SHVDN3 (Included)

Installation

- Drag and Drop "scripts" folder into main GTA Directory

DELETE These Files if exists "SimplePedMenu.dll", "SimplePedMenu.ini", and "SimplePedMenu.pdb" as these new files will generate a new ini file
on launch and it'll migrate your settings on next launch

Configuration
- The script reads settings from `scripts/SimplePedMenu.ini`. If the file does not exist, a default one is created on first run.

- Open menu key can be changed in the `[Options]` section (`OpenMenu`, default `F9`).

Usage notes
- If you try to spawn more companions than `MaxCompanions`, the script will show a message and prevent the spawn to avoid instability or crashes.
- You can manage squad behavior using the Squad submenu in the Options menu.

