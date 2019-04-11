using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject MenuCanvas;
    public Text EnergyText;
    public Text RescueText;
    public int Energy = 100;
    private int rescues = 0;
    public AudioSource friendAudio;
    public AudioSource energyAudio;
    public AudioSource enemyAudio;
    public Canvas WinCanvas; 

    private float deltaX, deltaY;

    //public void LoadSettings()
    //{
    //    EnergyText.text = PlayerPrefs.GetString("Energy");
    //}

    //public void SaveSettings()
    //{
    //    PlayerPrefs.SetString("Energy", EnergyText.text);
    //}

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //SetEnergy();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                case TouchPhase.Ended:
                    rb2d.velocity = Vector2.zero;
                    break;
                case TouchPhase.Moved:
                    rb2d.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("friend"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            rescues++;
            SetRescue();

            friendAudio.Play();
        }

        // if it's enemy
        if (collision.CompareTag("enemy"))
        {
            // game over
            Destroy(collision.gameObject);

            enemyAudio.Play();
            GameOver();
        }

        if (collision.CompareTag("energy"))
        {
            Destroy(collision.gameObject);
            Energy += 10;
            SetEnergy();
            energyAudio.Play();
        }
    }

    #region Menu manager
    private void restart()
    {
        // reload game scene
        SceneManager.LoadScene("game");
    }

    public void GameOver()
    {
        // show menu canvas
        MenuCanvas.SetActive(true);
    }

    private void hideMenu()
    {
        // hide menu canvas
        MenuCanvas.SetActive(false);
    }

    public void Replay()
    {
        // restart
        restart();
        // show 
    }

    public void ExitGame()
    {
        // exit game
        SceneManager.LoadScene("main");

        // clear settings
    }


    #endregion


    #region Win

    public void ToNextLevel(string level)
    {
        // hide
        WinCanvas.gameObject.SetActive(false);

        SceneManager.LoadScene(level);
    }

    #endregion

    #region

    private void SetEnergy()
    {
        EnergyText.text = "Energy: " + Energy;
        // SaveSettings();
    }

    private void SetRescue()
    {
        RescueText.text = "Rescues: " + rescues;

        if(rescues>=5)
        {
            // you win!
            
            WinCanvas.gameObject.SetActive(true);
        }
    }

    #endregion
}
