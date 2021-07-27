using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChanger : MonoBehaviour
{
    public bool isUp;
    public Sprite normalButton;
    public Sprite pressedButton;
    SpriteRenderer sr;
    private KeyBinding kb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        kb = GameObject.Find("KeyBindManager").GetComponent<KeyBinding>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(kb.keys["UpKey"]) && isUp)
        {
            sr.sprite = pressedButton;
        }
        if(Input.GetKeyUp(kb.keys["UpKey"]) && isUp)
        {
            sr.sprite = normalButton;
        }

        if (Input.GetKeyDown(kb.keys["DownKey"]) && !isUp)
        {
            sr.sprite = pressedButton;
        }
        if (Input.GetKeyUp(kb.keys["DownKey"]) && !isUp)
        {
            sr.sprite = normalButton;
        }
    }
}
