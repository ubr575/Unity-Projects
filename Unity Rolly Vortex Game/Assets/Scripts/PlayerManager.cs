using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public static bool LevelStarted;
    public GameObject GameStarted;
    public static bool IsGameOver;
    public static int gems;
    public TextMeshProUGUI gemsText;
    AudioManager audioM;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public static int score;
    public GameObject highscore;

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver=LevelStarted = false;
        Time.timeScale = 1f;
        score=gems = 0;
        highscore.SetActive(false);
        audioM = FindObjectOfType<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        gemsText.text = (PlayerPrefs.GetInt("TotalGems") + gems).ToString();
        scoreText.text = "Score: "+score.ToString();

        Touchscreen ts = Touchscreen.current;
        if (ts != null && ts.primaryTouch.press.isPressed && !LevelStarted)
        {
            LevelStarted = true;
            audioM.Play("click");
            GameStarted.SetActive(false);
        }
        if (IsGameOver)
        {
            Time.timeScale = 0f;
            PlayerPrefs.SetInt("TotalGems",PlayerPrefs.GetInt("TotalGems",0)+gems);
            
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                //display high score
                highscoreText.text = "New High Score: " + score;
                highscore.SetActive(true);

                //update high score
                PlayerPrefs.SetInt("HighScore", score);
            }
            this.enabled = false;
        }
    }
}
