using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class IpodController : MonoBehaviour
{
    
    private AudioSource ipodAudioSource;
    [SerializeField] private Track[] tracks;
    private int trackIndex;
    [SerializeField] private TextMeshProUGUI trackText;
    // Start is called before the first frame update
    void Start()
    {
        trackIndex = 0;
        ipodAudioSource = GetComponent<AudioSource>();
        ipodAudioSource.loop = false;
        ipodAudioSource.clip = tracks[trackIndex].trackClip;
        trackText.text = $"Song #{trackIndex + 1}";

       
    }

    // Update is called once per frame
    void Update()
    {
        if (ipodAudioSource.isPlaying == false)
        {
            SkipFoward();
        }
        if(trackIndex < 0)
        {
            trackIndex = tracks.Length - 1;
        }
    }
    public void PlayAudio()
    {
        ipodAudioSource.Play();
    }
    public void PauseAudio()
    {
        
        ipodAudioSource.Pause();
    }
    public void SkipFoward()
    {
        if (trackIndex >= tracks.Length -1)
        {
            trackIndex = 0;
        }
        else
        {
            trackIndex++;
        }
        
        UpdateTrack(trackIndex);

    }
    public void SkipBack()
    {
        if (trackIndex < 1)
        {
            trackIndex = tracks.Length - 1;
        }
        else
        {
            trackIndex--;
        }
            
        UpdateTrack(trackIndex);
    }
    public void UpdateTrack(int index)
    {
        
        ipodAudioSource.clip = tracks[index].trackClip;
        trackText.text = $"Song #{trackIndex + 1}";
        ipodAudioSource.Play();
    }
    
}
