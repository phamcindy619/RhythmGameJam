using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class KeyBinding : MonoBehaviour
{

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text UpKey;
    public Text DownKey;

    private GameObject currentKey;

    public static KeyBinding instance = null;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("UpKey",(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpKey", "F")));
        keys.Add("DownKey", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("DownKey", "J")));

        if(UpKey != null)
        {
            UpKey.text = keys["UpKey"].ToString();
            DownKey.text = keys["DownKey"].ToString();
        }

    }

    void Awake() {
        // Check if there is another KeyBinding
        if (instance == null)
            instance = this;
        // Destroy any duplicate
        else if (instance != this)
            Destroy(gameObject);
        
        // Don't destroy KeyBinding when reloading the scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
