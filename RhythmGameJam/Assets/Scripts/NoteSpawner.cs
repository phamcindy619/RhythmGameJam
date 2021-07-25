using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject Note;
    public GameObject NoteScroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject not = Instantiate(Note, transform.position, Quaternion.identity);
            not.transform.parent = NoteScroller.transform;
        }
    }
}
