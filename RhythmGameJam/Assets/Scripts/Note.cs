using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public bool canBePressed;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        // Start game by pressing any key
        if (!hasStarted) {
            if (Input.anyKeyDown) {
                hasStarted = true;
            }
        }
        // Have notes scroll left
        else {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }

        // Get input
        if (Input.GetKeyDown(keyToPress)) {
            if (canBePressed) {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = false;
            gameObject.SetActive(false);

            GameManager.instance.NoteMissed();
        }
    }
}
