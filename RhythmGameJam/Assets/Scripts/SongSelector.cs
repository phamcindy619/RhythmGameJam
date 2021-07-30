using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class SongSelector : MonoBehaviour {
    private Dictionary<string, float> songList;      // Key: Song name, Value: BPM
    public GameObject song;

    void Start() {
        Vector3 startPos = new Vector3(0, 0, 0);
        GameObject songMenu = GameObject.Find("Song Menu");

        // Initialize song list
        songList = new Dictionary<string, float>
        {
            {"Chicken Alfredo", 129f},
            {"Sushi", 155f},
        };

        // Display songs dynamically
        foreach (var item in songList) {
            // Instantiate song object
            GameObject newSong = Instantiate(song) as GameObject;
            newSong.transform.parent = songMenu.transform;
            newSong.transform.localPosition = startPos;

            // Update song info
            TextMeshProUGUI songText = newSong.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            songText.text = item.Key;

            // Add button listener
            newSong.GetComponent<Button>().onClick.AddListener(() => ChooseSong(item.Key));

            startPos += new Vector3(0, -150, 0);
        }
    }
    
    public void ChooseSong(string name) {
        // Load in the correct song
        AudioClip song = Resources.Load<AudioClip>("Audio/" + name);
        SongManager.instance.musicSource.clip = song;
        SongManager.instance.songBpm = songList[name];
        SongManager.instance.songName = name;

        // Switch to game scene
        SceneManager.LoadScene("Game");
    }
}
