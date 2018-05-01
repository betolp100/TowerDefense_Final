using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {

    protected static SongManager instance=null;

    public AudioSource manager;
    public AudioClip[] songs;
    public int counter = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!manager.isPlaying)
        {
            manager.clip = songs[counter];
            manager.Play();
            
            counter++;
            if (counter == 5)
            {
                counter = 0;
            }
        }

    }
}
