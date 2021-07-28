using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SongSelector : MonoBehaviour {
    [Serializable]
    public struct Song {
        public string songName;
        public float bpm;
    }

    [SerializeField]
    public Song[] songList;

    void Start() {

    }
    
    public void ChooseSong() {
        Debug.Log("Chose a song");
    }
}
