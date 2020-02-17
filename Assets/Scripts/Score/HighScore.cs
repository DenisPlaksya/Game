using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text HighScore_txt;
    public int highScor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highScor = PlayerPrefs.GetInt("HighScore");
        HighScore_txt.text = highScor.ToString();
    }
}
