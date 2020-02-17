using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speedMove;
    public float speedMoveUp;
    public bool canDown;
    public GameObject player;
    Rigidbody rb;
    public Text Score;
    public Text HighScore;
    private int highScor;
    private int scor;
    public GameObject record;
    public Material[] colors;
    public GameObject losePanel;
    public GameObject pauseBtn;
    public GameObject sText;
    public bool canRand;

    public AudioSource[] sound;
    //public AudioSource scoreUpSpound;
    // Start is called before the first frame update
    void Start()
    {
        //sound[1] = AudioSource.FindObjectOfType<AudioSource>();
        //canRand = true;
        colorRand();
        scor = 0;
        PlayerPrefs.SetInt("Score", scor);
        Score.text = scor.ToString();
        rb = GetComponent<Rigidbody>();
        speedMove = 0f;
        speedMoveUp = 0f;
        canDown = false;
        record.SetActive(false);
        sound[sound.Length - 1] = AudioSource.FindObjectOfType<AudioSource>();

    }


    void colorRand()
    {
        if(canRand)
        {
            GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
        }
    }
    // Update is called once per frame
    void Update()
    {
        scor = PlayerPrefs.GetInt("Score");
        Score.text = scor.ToString();

        highScor = PlayerPrefs.GetInt("HighScore");
        HighScore.text = highScor.ToString();
        if (canDown)
        {
            player.transform.Translate(Vector3.right * speedMove * Time.deltaTime);
            player.transform.Translate(Vector3.down * speedMove * Time.deltaTime);
        }


        if(scor >= 10)
        {
            speedMove = 2.5f;
            speedMoveUp = 4.5f;
        }
        if (scor >= 20)
        {
            speedMove = 3f;
            speedMoveUp = 5f;
        }
        if (scor >= 30)
        {
            speedMove = 4f;
            speedMoveUp = 7f;
        }
        if (scor >= 40)
        {
            speedMove = 4.5f;
            speedMoveUp = 8f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            scor = 0;
            PlayerPrefs.SetInt("Score", scor);
            Score.text = scor.ToString();
            PlayerPrefs.Save();

            highScor = 0;
            HighScore.text = highScor.ToString();
            PlayerPrefs.SetInt("HighScore", highScor);
            PlayerPrefs.Save();
        }
    }

    void OnMouseDrag()
    {
        //canDown = true;
        player.transform.Translate(Vector3.up * speedMoveUp * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            sound[0].Play();
            Time.timeScale = 0f;
            sText.SetActive(false);
            pauseBtn.SetActive(false);
            record.SetActive(false);
            losePanel.SetActive(true);
            //Destroy(gameObject);
            //SceneManager.LoadScene("Play");
        }

        if(other.gameObject.tag == "Respawn")
        {
            sound[0].Play();
            Time.timeScale = 0f;
            sText.SetActive(false);
            pauseBtn.SetActive(false);
            losePanel.SetActive(true);
            record.SetActive(false);
            //Destroy(gameObject);
            //SceneManager.LoadScene("Play");
        }

        if(other.gameObject.tag == "Score")
        {
            sound[1].Play();
            scor += 1; 
            PlayerPrefs.SetInt("Score",scor);
            Score.text = scor.ToString();

            if (scor > highScor)
            {
                highScor = scor;
                HighScore.text = highScor.ToString();
                PlayerPrefs.SetInt("HighScore", highScor);
                PlayerPrefs.Save();
                record.SetActive(true);

            }
            Destroy(other.gameObject);
        }
    }
}
