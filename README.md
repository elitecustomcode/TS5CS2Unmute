# TS5CS2Unmute
This application is the first version of an auto unmute function for Teamspeak 5 and Counter Strike 2.
The application uses the Gamestate Integration from Counterstrike and the Websocket API from Teamspeak 5 and is save to use on any CS2 Match (even with VAC Servers and Faceit Anticheat). There is no tampering with any of the CS2 files, exept for adding a [Gamestate Integration Configuration](https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration) see also [here](https://www.reddit.com/r/GlobalOffensive/comments/cjhcpy/game_state_integration_a_very_large_and_indepth/)

## How to install
At the moment, there is a pre-compiled, ready to run version (Windows x64) in releases, download [here](https://github.com/elitecustomcode/TS5CS2Unmute/releases). 
Just unpack the ZIP File and start the TS5CS2Unmute.exe

## How to configure Teamspeak 5
1. When running this application for the first time, you will get a little notification which you have to allow.
![TS5-Notification](https://github.com/elitecustomcode/TS5CS2Unmute/blob/master/2024-09-30_16h21_53.png)

2. After that you have to go to your settings and find the hotkey area. There you have the toggle microphone setting.
![TS5-Settings](https://github.com/elitecustomcode/TS5CS2Unmute/blob/master/2024-09-30_16h25_15.png)

3. Now befor you click the "plus" icon to add a new hotkey, you have to press the "Assign Hotkey in 5 Seconds" Button in this application.
![Application](https://github.com/elitecustomcode/TS5CS2Unmute/blob/master/2024-09-30_16h27_22.png)

4. Now you have 5 seconds to press the "plus" symbol in Teamspeak 5 and wait. When everythink worked it should look like this.
![TS5-Hotkey](https://github.com/elitecustomcode/TS5CS2Unmute/blob/master/2024-09-30_16h30_29.png)

## Disclaimer
This application is a little project for my personal need. I always forget to unmute the Teamspeak after the round, start talking and no one of my team is responding. The Round is finished as soon as one time won. So for the "after round" seconds, you are already unmuted. Most of the time this is when all enemies have died or the bomb exploded, or the round time is over. This means, in some cases, you teammates are still fighting for there life (virtually). Be aware. 
The application has no great visuals, no logo, no real name, no installer. I can optimate this, if there is intereset in such application. For the moment it fits my needs, maybe some day I will polish the visuals.

## Want some features or need some help?
If you want some features or need some help, just reach out via github oder e-mail elitecustomcode at protonmail.com.

## Anti-Cheat
No worries, this application only uses available APIs provided by Teamspeak and Counterstrike (as mentioned above). There is no tempering with gamefiles or memory.

## Possible Features, Maybe, if someone is interested
- [ ] More Configuration
- [ ] Anti-Flash Noise Cancelling
- [ ] Config-Features (i.E. Buyscripts)
