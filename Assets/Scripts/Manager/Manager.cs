using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject gameName;
    public GameObject scoreText;
    public GameObject playBtn;
    public GameObject shopBtn;
    public GameObject pauseBtn;
    public GameObject pauseOff;
    public GameObject highScore;
    public GameObject pausePanel;
    public GameObject ballShop;
    public GameObject losePanel;
    public GameObject record;
    public Text Score;
    public int scor;
    public Text HighScore;
    public int highScor;
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        scor = PlayerPrefs.GetInt("Score");
        Score.text = scor.ToString();

        highScor = PlayerPrefs.GetInt("HighScore");
        HighScore.text = highScor.ToString();
    }

    public void startGame()
    {
        
        gameName.SetActive(false);
        scoreText.SetActive(true);
        playBtn.SetActive(false);
        shopBtn.SetActive(false);
        pauseBtn.SetActive(true);
        highScore.SetActive(false);
        pm.canDown = true;
        pm.speedMove = 2f;
        pm.speedMoveUp = 4f;
    }

    public void Pause()
    {
        gameName.SetActive(false);
        scoreText.SetActive(false);
        playBtn.SetActive(false);
        pauseBtn.SetActive(false);
        //pauseOff.SetActive(true);
        highScore.SetActive(false);
        pausePanel.SetActive(true);
        record.SetActive(false);
        pm.canDown = true;
        pm.speedMove = 2f;
        pm.speedMoveUp = 4f;
        Time.timeScale = 0f;
    }

    public void DontPause()
    {
        record.SetActive(false);
        scoreText.SetActive(true);
        pauseBtn.SetActive(true);
        pauseOff.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Rest()
    {
        pauseBtn.SetActive(false);
        losePanel.SetActive(false);
        SceneManager.LoadScene("Play");

    }

    public void Menu()
    {
        SceneManager.LoadScene("Play");
    }
    public void Back()
    {
        gameName.SetActive(true);
        playBtn.SetActive(true);
        shopBtn.SetActive(true);
        highScore.SetActive(true);
        ballShop.SetActive(false);
    }
    public void Shop()
    {
        gameName.SetActive(false);
        playBtn.SetActive(false);
        shopBtn.SetActive(false);
        highScore.SetActive(false);
        ballShop.SetActive(true);
    }
}
