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
    public GameObject NoteUplane;
    public GameObject NoteDownLane;
    public GameObject notescroller;
    public string Pathtocsv = "Assets/Csv/song.csv";
    //public Dictionary<float, System.Tuple<string,string>> NoteTimes = new Dictionary<float, System.Tuple<string,string>>();

    // Note spawner based on beat - Cindy
    public SongManager sm;
    float[] notes = {1f, 2f, 3f, 4f, 7f};
    int nextIndex = 0;


    void Start()
    {
        sm = GameObject.Find("SongManager").GetComponent<SongManager>();
    }

    void Update()
    {
        if (ns.hasStarted) {
            if (nextIndex < notes.Length && notes[nextIndex] < sm.songPositionInBeats) {
                //Generates a random number between 0 and 1-Lawful
                float random = Random.Range(0f, 1f);
                Debug.Log(random);
                //If the random number is greater than .5 create a UpNote else create a DownNote-Lawful
                if(random > .5)
                {
                    GameObject n = Instantiate(NoteUplane, UpLane.transform.position, Quaternion.identity);
                    n.transform.parent = notescroller.transform;
                }
                else
                {
                    GameObject n = Instantiate(NoteDownLane, DownLane.transform.position, Quaternion.identity);
                    n.transform.parent = notescroller.transform;
                }

                nextIndex++;
            }
        }
    }

    private void FixedUpdate()
    {
        if (ns.hasStarted)
        {
            //ReadCsvFile(Pathtocsv);
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
            var data_values = data_string.Split(',');
            //NoteTimes.Add(data_values[0]);
            if (Time.time.ToString("0.00") == data_values[0])
            {
                if(data_values[1] == "normal")
                {
                    if(data_values[2] == "up")
                    {
                        Debug.Log("Normal Note! Up Lane");
                        CreateNote(true);

                    }
                    else if (data_values[2] == "down")
                    {
                        Debug.Log("Normal Note! Down Lane");
                        CreateNote(false);
                    }
                }
                else if(data_values[1] == "special")
                {
                    Debug.Log("Special Note!");
                }
            }
        }
    }

    void CreateNote(bool up)
    {
        if (up)
        {
            GameObject n = Instantiate(NoteUplane, UpLane.transform.position, Quaternion.identity);
            n.transform.parent = notescroller.transform;
        }
        else
        {

            GameObject n = Instantiate(NoteDownLane, DownLane.transform.position, Quaternion.identity);
            n.transform.parent = notescroller.transform;
        }
    }


}
