using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource song;
    public bool isPlaying;
    public Note note;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) {
            if (Input.anyKeyDown) {
                isPlaying = true;
                note.hasStarted = true;
            }
        }
    }

    public void NoteHit() {
        Debug.Log("note hit");
    }

    public void NoteMissed() {
        Debug.Log("note missed");
    }
}
