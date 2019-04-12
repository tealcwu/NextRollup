using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    private GameObject gameMusicPlayer;
    private GameMusicPlayer gameMusicPlayerClass;
    private AudioSource friendAudio;
    private AudioSource energyAudio;
    private AudioSource enemyAudio;

    public Toggle SfxToggle;
    public Toggle BgToggle;
    public Slider SfxSlider;
    public Slider BgSlider;

    // Use this for initialization
    void Start()
    {
        gameMusicPlayer = GameObject.Find("GameMusicPlayer");
        gameMusicPlayerClass = gameMusicPlayer.GetComponent<GameMusicPlayer>();
        friendAudio = GameObject.Find("FriendAudio").GetComponent<AudioSource>();
        energyAudio = GameObject.Find("EnergyAudio").GetComponent<AudioSource>();
        enemyAudio = GameObject.Find("EnemyAudio").GetComponent<AudioSource>();
    }

    public void SfxToggleChanged()
    {
        if (SfxToggle.isOn)
        {
            friendAudio.mute = false;
            enemyAudio.mute = false;
            energyAudio.mute = false;
        }
        else
        {
            friendAudio.mute = true;
            enemyAudio.mute = true;
            energyAudio.mute = true;
        }
    }

    public void AdjustSfxVolume()
    {
        float volume = SfxSlider.value;
        friendAudio.volume = volume;
        enemyAudio.volume = volume;
        energyAudio.volume = volume;
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


    #region item settings





    #endregion
}
