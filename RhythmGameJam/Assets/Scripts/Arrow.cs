using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool canBePressed;
    private bool pressed;
    public bool Uplane;
    [SerializeField]
    private KeyBinding keybinds;
    private Vector2 startPos;
    private Vector2 endPos;

    public float currBeat;

    // Start is called before the first frame update
    void Start()
    {
        keybinds = GameObject.Find("KeyBindManager").GetComponent<KeyBinding>();
        startPos = transform.position;
        endPos = GameObject.Find("NoteEnd").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        if (Input.GetKeyDown(keybinds.keys["UpKey"]) && Uplane)
        {
            if (canBePressed && !pressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                
                pressed = true;
            }
        }

        if (Input.GetKeyDown(keybinds.keys["DownKey"]) && !Uplane)
        {
            if (canBePressed && !pressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                
                pressed = true;
            }
        }

        transform.position = new Vector2(
            Mathf.Lerp(
                startPos.x,
                endPos.x,
                (GameManager.instance.beatsShownInAdvance - (currBeat - SongManager.instance.songPositionInBeats)) / GameManager.instance.beatsShownInAdvance
            ),
            transform.position.y
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            GameManager.instance.FakePerfect();
        
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            if (gameObject.activeInHierarchy)
            {
                GameManager.instance.NoteMissed();
                gameObject.SetActive(false);
            }
        }
    }
}
