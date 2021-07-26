using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool canBePressed;
    public bool Uplane;
    [SerializeField]
    private KeyBinding keybinds;

    // Start is called before the first frame update
    void Start()
    {
        keybinds = GameObject.Find("KeyBindManager").GetComponent<KeyBinding>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        if (Input.GetKeyDown(keybinds.keys["UpKey"]) && Uplane)
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        }

        if (Input.GetKeyDown(keybinds.keys["DownKey"]) && !Uplane)
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
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
