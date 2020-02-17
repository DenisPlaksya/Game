using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScore : MonoBehaviour
{
    public Text Score;
    public int scor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        scor = PlayerPrefs.GetInt("Score");
        Score.text = scor.ToString();
    }
}
