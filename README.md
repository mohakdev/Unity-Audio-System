
# Unity Audio System

## Table of contents
1. [Description](#Description)
2. [Install](#Install)
3. [How to use](#HowtoUse)
	- [Namespace Usage](#NamespaceUsage)
	- [Play Sound](#PlaySound)
	- [Play Sound with changed settings](#PlaySoundwithchangedsettings)
	- [Music System](#BuiltinMusicSystem)
	- [Helper Methods](#HelperMethods)
4. [License](#License)

## Description
Simple, lightweight and Easy to use audio system for your own game in Unity Game Engine. 

---
## Install
- use the command at your desired download location 

git clone https://github.com/mohakdev/Unity-Audio-System.git

- Once installed open the repository folder in Unity
![FolderImage](https://i.imgur.com/zqmBTCm.png)
- Drag the Audio System GameObject into your first scene of the game
![DragPrefab](https://i.imgur.com/ZfhoMkf.png)
- Go to Scripts/AudioManager.cs
![AudioManagerDir](https://i.imgur.com/KLobYMw.png)
- Find SoundTypes enum. This is the place where you need to enter all the types of sound you want to play.
![SoundTypesEnum](https://i.imgur.com/hADJ2uF.png)
- Once added go back to Inspector, Click on AudioSystem GameObject and find Audio List.
![AudioList](https://i.imgur.com/lMt1IZv.png)
- Drag & Drop the sounds you want to play when a certain Sound Type is called.
![DragDropAudio](https://i.imgur.com/O0GbeDa.gif)
- Once all the audios are dragged and dropped you will be finished with the installation.
## How to Use
### Namespace usage
In whichever script you wanna play audio simply add 
```cs
using RadiantTools.AudioSystem;
```
Note -> If you are using Assembly Definitions then don't forget to add this assembly as a reference.
### Play Sound
```cs
AudioManager.Instance.PlayAudio(AudioManager.SoundTypes.AudioTwo);
```
### Play Sound with changed settings
 ```cs
 //Changing settings of audio as well
 AudioSettings audioSettings = new()
 {
     pitch = 1.3f,
     volume = 0.6f
 };
AudioManager.Instance.PlayAudio(AudioManager.SoundTypes.AudioOne, audioSettings);
 ```
### Built in Music System
This audio-system also has a built in music system so not only can you play audio but also play your favourite music as background music for your game.

- Simply go into AudioSystem GameObject and then go into Music
![MusicList](https://i.imgur.com/pwIpQnw.png)
- Add your favourite music in MusicList and it will automatically start playing when the game begins and once the playlist comes to an end it will restart from the beginning.
### Helper Methods
These helper methods will save you a lot of time.
1. `AudioManager.Instance.GetMusicSource()` - Returns you the Audio Source which plays all music.
2. `AudioManager.Instance.GetAudioClip(SoundTypes soundType)` - Returns you the Audio Clip and takes SoundType as Input.
## License
This code is licensed under MIT License which you can read [here](https://github.com/mohakdev/Unity-Audio-System/blob/main/LICENSE)
