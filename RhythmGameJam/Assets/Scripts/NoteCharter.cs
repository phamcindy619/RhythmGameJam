using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class NoteCharter : MonoBehaviour
{
    public TextMeshProUGUI timertxt;
    public SongManager sm;
    public Dictionary<float, bool> NoteTime = new Dictionary<float, bool>();
    public TMP_InputField filename;
    [SerializeField]
    GameObject UpLaneNote;
    [SerializeField]
    GameObject DownLaneNote;
    [SerializeField]
    Transform UpLane;
    [SerializeField]
    Transform DownLane;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SongManager").GetComponent<SongManager>();
    }


    // Update is called once per frame
    void Update()
    {
        float Beat = Mathf.Round(sm.songPositionInBeats);
        timertxt.text = "Beats: " + Beat;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NoteTime.Add(Beat, true);
            print("UpArrow at beat: " + Beat);
            addToCsv(Beat.ToString(), "up", "Assets/Csv/"+filename.text+".csv");
            GameObject p = Instantiate(UpLaneNote, UpLane.transform.position, Quaternion.identity);
            Destroy(p, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NoteTime.Add(Beat, false);
            print("DownArrow at beat: " + Beat);
            addToCsv(Beat.ToString(), "down", "Assets/Csv/"+filename.text+".csv");
            GameObject p = Instantiate(DownLaneNote, DownLane.transform.position, Quaternion.identity);
            Destroy(p, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("File Created!");
        }
    }


    public static void addToCsv(string beat,string lane, string filepath)
    {
        try
        {
            using (StreamWriter file = new StreamWriter(@filepath, true))
            {
                file.WriteLine(beat + "," + lane);
            }
        }
        catch(Exception ex)
        {
            throw new ApplicationException("This program is not working: " + ex);
        }
    }


}
