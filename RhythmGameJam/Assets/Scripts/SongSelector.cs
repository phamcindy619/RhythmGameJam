using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelector : MonoBehaviour {
    public string Song1;
    public string Song2;

    public void StartSong1()
    {
        Debug.Log(Song1);
    }

    public void StartSong2()
    {
        Debug.Log(Song2);
    }
}
