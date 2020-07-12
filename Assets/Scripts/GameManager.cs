using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script is a static instance use stuff from here to access througout the game.. like score health etc. player states/stats anything
/// use GameManager.instance.(Func name / var name) to use
/// 
/// </summary>
public class GameManager : MonoBehaviour

{
    //A singleton
    public static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake ()
    {
        if (instance != null && instance != this)
        {
            Destroy (this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //Game Vars

    [Header ("Player Stats")]
    public bool drunk = true;
    public bool canSpawnObstacles = false;
    //Score Manage
    [Header ("Score and other info")]
    public int currentPlayerScore = 0;
    public int scoreMultiplier = 1;
    public int foodScore = 20;
    public int playerHighScore;

    public int Collected;

    public Slider slider; //Health Slider

    [Header ("Text Fields to be populated")]
    public Text score;
    public Text HighScore;

    [Space]
    [Header ("UI Windows")]
    public GameObject StartGameText, PlaceObjectText, GameOverText; //Text Windows

    private void Start ()
    {
        instance = this;
        // Time.timeScale = 0;
    }
    public void Fail ()
    {

        GameOverText.SetActive (true);
        // Time.timeScale = 0;

    }

    public void Play ()
    {
        Time.timeScale = 1;
        StartGameText.SetActive (false);

    }

    public void MainMenu ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }

    public void Quit ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit ();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateScore ();
    }

    public void UpdateScore ()
    {
        currentPlayerScore += 1 * scoreMultiplier;
        score.text = currentPlayerScore.ToString ();
    }

    public void GameOver ()
    {
        //do this after game gets over
    }
    public void Restart ()
    {
        Debug.Log ("Reloading");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

}