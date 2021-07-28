using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public float songBpm;       // Beats per minute
    public float secPerBeat;    // Number of seconds per beat
    public float songPositionInSec;     // Current song position, in seconds
    public float songPositionInBeats;   // Current song position, in beats
    public float dspSongTime;   // How many seconds have passed since song started
    public AudioSource musicSource;
    public static SongManager instance = null;  // Singleton SongManager

    bool Paused;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        // Check if there is another SongManager
        if (instance == null)
            instance = this;
        // Destroy any duplicate
        else if (instance != this)
            Destroy(gameObject);
        
        // Don't destroy SongManager when reloading the scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate song position
        if (!Paused)
        {
            songPositionInSec = (float) (AudioSettings.dspTime - dspSongTime);
            songPositionInBeats = songPositionInSec / secPerBeat;
        }
        else
        {
        }
    }

    public void PlayMusic() {
        Paused = false;
        // Calculate number of seconds per beat
        secPerBeat = 60f / songBpm;

        // Record when music starts
        dspSongTime = (float) AudioSettings.dspTime;

        // Play music
        musicSource.Play();
    }

    public void PauseMusic()
    {
        Paused = true;
        musicSource.Pause();
    }

}
