using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SongSelector : MonoBehaviour {
    
    public AudioClip song1;
    public float bpm1;
    public AudioClip song2;
    public float bpm2;

    public SongManager sm;

    void Start() {
        sm = GameObject.Find("SongManager").GetComponent<SongManager>();
    }

    public void StartSong1(string scenename)
    {
        sm.musicSource.clip = song1;
        sm.songBpm = bpm1;
        SceneManager.LoadScene(scenename);
    }

    public void StartSong2(string scenename)
    {
        sm.musicSource.clip = song2;
        sm.songBpm = bpm2;
        SceneManager.LoadScene(scenename);
    }
}
