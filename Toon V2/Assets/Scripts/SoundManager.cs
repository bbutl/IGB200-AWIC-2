using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource aSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorChime()
    {
        aSource.enabled = true;
        aSource.Play(0);
    }

}
