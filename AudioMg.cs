using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AudioMg : MonoBehaviour
{
    public AudioSource audioSrc;

    public static float musicVolume = 0.5f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

       
    }

    void Update(){
        audioSrc.volume = musicVolume;
    }

    public void updateVolume(float volume){
        musicVolume = volume;

    }


}
