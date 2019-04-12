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
    private AudioSource friendAudio;
    private AudioSource energyAudio;
    private AudioSource enemyAudio;
    public Canvas WinCanvas;
    public Text TimerText;

    public float TimeCount = 10;

    Vector3 offset;
    Vector3 mousePosition;
    private float deltaX, deltaY;
    private bool isWin;
    private bool isFailed;

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
        GenerateCollidersAcrossScreen();

        friendAudio = GameObject.Find("FriendAudio").GetComponent<AudioSource>();
        energyAudio = GameObject.Find("EnergyAudio").GetComponent<AudioSource>();
        enemyAudio = GameObject.Find("EnemyAudio").GetComponent<AudioSource>();
        //SetEnergy();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get offset
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = gameObject.transform.position - mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("GetMouseButton triggered.");

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, 0);
        }

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

        // update timer
        if(TimeCount>0 && !isWin && !isFailed)
        {
            TimeCount -= Time.deltaTime;
            if (TimeCount < 0)
            {
                TimeCount = 0;
                GameOver();
            }

            TimerText.text = TimeCount.ToString();
        }
    }

    void GenerateCollidersAcrossScreen()
    {
        Vector2 lDCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, Camera.main.nearClipPlane));
        Vector2 rUCorner = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        Vector2[] colliderpoints;

        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);
        upperEdge.points = colliderpoints;

        EdgeCollider2D lowerEdge = new GameObject("lowerEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = lowerEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        lowerEdge.points = colliderpoints;

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
        leftEdge.points = colliderpoints;

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();

        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        rightEdge.points = colliderpoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("friend"))
        {
            friendAudio.Play();
            //AudioSource faudio = collision.gameObject.GetComponent<AudioSource>();
            //faudio.Play();

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            rescues++;
            SetRescue();
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
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void GameOver()
    {
        // show menu canvas
        MenuCanvas.SetActive(true);
        isFailed = true;
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
            isWin = true;
            WinCanvas.gameObject.SetActive(true);
        }
    }

    #endregion
}
