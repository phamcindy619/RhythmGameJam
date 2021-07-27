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
    public float Timer;
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
    }


    // Update is called once per frame
    void Update()
    {
        Timer = GameObject.Find("SongManager").GetComponent<SongManager>().songPositionInSec;
        timertxt.text = "Timer: " + Timer.ToString("0.00");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NoteTime.Add(Timer, true);
            print("UpArrow at time: " + Timer.ToString("0.00"));
            addToCsv(Timer.ToString("0.00"), "normal", "up", "Assets/Csv/"+filename.text+".csv");
            GameObject p = Instantiate(UpLaneNote, UpLane.transform.position, Quaternion.identity);
            Destroy(p, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NoteTime.Add(Timer, false);
            print("DownArrow at time: " + Timer.ToString("0.00"));
            addToCsv(Timer.ToString("0.00"), "normal", "down", "Assets/Csv/"+filename.text+".csv");
            GameObject p = Instantiate(DownLaneNote, DownLane.transform.position, Quaternion.identity);
            Destroy(p, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("File Created!");
        }
    }


    public static void addToCsv(string time, string type, string lane, string filepath)
    {
        try
        {
            using (StreamWriter file = new StreamWriter(@filepath, true))
            {
                file.WriteLine(time + "," + type + "," + lane);
            }
        }
        catch(Exception ex)
        {
            throw new ApplicationException("This program is not working: " + ex);
        }
    }


}
