using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public Transform UpLane;
    public Transform DownLane;
    public GameObject NoteUpLane;
    public GameObject NoteDownLane;

    // Note spawner based on beat - Cindy
    public struct Note {
        public float beat;
        public bool upLane;
    };
    List<Note> notes;
    int nextIndex = 0;

    void Start()
    {
        notes = new List<Note>();
        TextAsset chart = Resources.Load<TextAsset>("CSV/" + SongManager.instance.songName);
        ReadFile(chart);
    }

    void Update()
    {
        if (GameManager.instance.isPlaying) {
            if (nextIndex < notes.Count && notes[nextIndex].beat < SongManager.instance.songPositionInBeats + GameManager.instance.beatsShownInAdvance) {
                if(notes[nextIndex].upLane)
                {
                    GameObject note = Instantiate(NoteUpLane, UpLane.transform.position, Quaternion.identity);
                    note.GetComponent<Arrow>().currBeat = notes[nextIndex].beat;
                }
                else
                {
                    GameObject note = Instantiate(NoteDownLane, DownLane.transform.position, Quaternion.identity);
                    note.GetComponent<Arrow>().currBeat = notes[nextIndex].beat;
                }
                nextIndex++;
            }
        }
    }

    void ReadFile(TextAsset textObj)
    {
        string[] data_string = textObj.text.Split('\n');
        foreach (string line in data_string) {
            if (line != "") {
                string[] data_values = line.Split(',');

                Note newNote = new Note {
                    beat = float.Parse(data_values[0]),
                    upLane = data_values[1] == "up"? true : false
                };

                notes.Add(newNote);
            }
        }
    }
}
