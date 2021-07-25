using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChanger : MonoBehaviour
{
    public KeyCode pressedKey;
    public Sprite normalButton;
    public Sprite pressedButton;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pressedKey))
        {
            sr.sprite = pressedButton;
        }
        if(Input.GetKeyUp(pressedKey))
        {
            sr.sprite = normalButton;
        }
    }
}
