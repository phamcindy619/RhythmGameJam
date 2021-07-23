using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Song : MonoBehaviour
{
    [SerializeField]
    public string SongName;
    public TextMeshProUGUI SongNametxt;
    public Image songimage;
    // Start is called before the first frame update
    void Start()
    {
        SongNametxt.text = SongName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
