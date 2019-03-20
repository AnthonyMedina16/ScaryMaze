using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip music;

    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

}
