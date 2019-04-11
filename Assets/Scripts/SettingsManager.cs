using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    private GameObject gameMusicPlayer;
    private GameMusicPlayer gameMusicPlayerClass;
    private AudioSource friendAudio;

    public Toggle SfxToggle;
    public Toggle BgToggle;
    public Slider SfxSlider;
    public Slider BgSlider;

	// Use this for initialization
	void Start () {
        gameMusicPlayer = GameObject.Find("GameMusicPlayer");
        gameMusicPlayerClass = gameMusicPlayer.GetComponent<GameMusicPlayer>();
        friendAudio = GameObject.Find("FriendAudio").GetComponent<AudioSource>();
    }

    public void SfxToggleChanged()
    {
        if (SfxToggle.isOn) friendAudio.mute = false;
        else friendAudio.mute = true;
    }

    public void BgToggleChanged()
    {
        if (BgToggle.isOn) PlayMusic();
        else StopMusic();
    }

    public void PlayMusic()
    {
        gameMusicPlayerClass.PlayMusic();
    }

    public void StopMusic()
    {
        gameMusicPlayerClass.StopMusic();
    }

    public void AdjustBgVolume()
    {
        gameMusicPlayerClass.AdjustVolume(BgSlider.value);
    }
}
