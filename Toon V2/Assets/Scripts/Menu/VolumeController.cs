using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource door;
    public AudioSource talk;
    public AudioSource music;
    public Slider soundsVol;
    public Slider musicVol;

    void Update()
    {
        door.volume = soundsVol.value * 0.1f;
        talk.volume = soundsVol.value * 0.1f;
        music.volume = musicVol.value * 0.5f;
    }
}
