using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public float songBpm;       // Beats per minute
    public float secPerBeat;    // Number of seconds per beat
    public float songPositionInSec;     // Current song position, in seconds
    public float songPositionInBeats;   // Current song position, in beats
    public float dspSongTime;   // How many seconds have passed since song started
    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        // Calculate number of seconds per beat
        secPerBeat = 60f / songBpm;

        // Record when music starts
        dspSongTime = (float) AudioSettings.dspTime;

        // Play music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate song position
        songPositionInSec = (float) (AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPositionInSec / secPerBeat;
    }
}
