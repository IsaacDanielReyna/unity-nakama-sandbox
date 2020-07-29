using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lobby : MonoBehaviour
{
    public TMP_Text username;

    // Start is called before the first frame update
    void Start()
    {
        username.text = PlayerPrefs.GetString("USERNAME");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
