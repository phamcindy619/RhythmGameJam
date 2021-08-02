using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SongSelector : MonoBehaviour {
    private Dictionary<string, float> songList;      // Key: Song name, Value: BPM
    public GameObject song;
    public GameObject start;

    public AudioClip confirmation;

    void Start() {
        confirmation = Resources.Load<AudioClip>("Audio/Menu_Confirm");

        GameObject songMenu = GameObject.Find("Song Menu");
        start = GameObject.Find("Start");
        Vector3 startPos = start.transform.localPosition;

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
            Text songText = newSong.transform.GetChild(1).gameObject.GetComponent<Text>();
            songText.text = item.Key;

            Image dishImage = newSong.transform.GetChild(2).gameObject.GetComponent<Image>();
            dishImage.sprite = Resources.Load<Sprite>("Sprites/" + item.Key);

            // Add button listener
            newSong.GetComponent<Button>().onClick.AddListener(() => ChooseSong(item.Key));

            startPos += new Vector3(0, -300, 0);
        }
    }
    
    public void ChooseSong(string name) {
        SongManager.instance.PlaySingle(confirmation);

        // Load in the correct song
        AudioClip song = Resources.Load<AudioClip>("Audio/" + name);
        SongManager.instance.musicSource.clip = song;
        SongManager.instance.songBpm = songList[name];
        SongManager.instance.songName = name;

        // Switch to game scene
        SceneManager.LoadScene("Game");
    }
}
