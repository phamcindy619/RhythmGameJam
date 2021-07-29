using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private NoteScroller ns;
    public Transform UpLane;
    public Transform DownLane;
    public GameObject NoteUpLane;
    public GameObject NoteDownLane;
    public string pathToCsv = "Assets/Csv/Chicken_Alfredo02.csv";

    // Note spawner based on beat - Cindy
    public SongManager sm;
    public struct Note {
        public float beat;
        public bool upLane;
    };
    List<Note> notes;
    int nextIndex = 0;

    void Start()
    {
        sm = GameObject.Find("SongManager").GetComponent<SongManager>();
        notes = new List<Note>();
        ReadCsvFile(pathToCsv);
    }

    void Update()
    {
        if (ns.hasStarted) {
            if (nextIndex < notes.Count && notes[nextIndex].beat < sm.songPositionInBeats) {
                if(notes[nextIndex].upLane)
                {
                    GameObject n = Instantiate(NoteUpLane, UpLane.transform.position, Quaternion.identity);
                    n.transform.parent = ns.gameObject.transform;
                }
                else
                {
                    GameObject n = Instantiate(NoteDownLane, DownLane.transform.position, Quaternion.identity);
                    n.transform.parent = ns.gameObject.transform;
                }
                nextIndex++;
            }
        }
    }

    void ReadCsvFile(string filepath)
    {
        StreamReader strReader = new StreamReader(filepath);
        bool endoffile = false;
        while (!endoffile)
        {
            string data_string = strReader.ReadLine();
            if(data_string == null)
            {
                endoffile = true;
                break;
            }
            string[] data_values = data_string.Split(',');

            Note newNote = new Note {
                beat = float.Parse(data_values[0]),
                upLane = data_values[1] == "up"? true : false
            };

            notes.Add(newNote);
        }
    }
}
