using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStarted = false;

    public GameObject total;
    public GameObject highScore;
    public GameObject startGame;
    public GameObject restartGame;
    public GameObject gameOver;
    public GameObject distance;
    public GameObject fuel;
    public GameObject lowFuel;
    public GameObject quitGame;
    public GameObject gameScore;

    public Slider fuelSlider;
    public Image fuelFill;
    public Text distanceText;
    public Text highScoreText;
    public Text gameScoreText;
    public Text totalText;

    public Color colorRed;
    public Color colorOrange;
    public Color colorGreen;

    void Awake()
    {
        isGameOver = false;
        isGameStarted = false;
    }

    void Start()
    {
        float score = PlayerPrefs.GetFloat("highscore", 0);
        if (score > 0)
        {
            highScore.SetActive(true);
            highScoreText.text = (score / 1000).ToString("0.00") + "\nKm";
        }

        float totalDistance = PlayerPrefs.GetFloat("total", 0);
        totalText.text = (totalDistance / 1000).ToString("0.00") + "\nKm";
    }

    void Update()
    {
        distanceText.text = (EndlessRoad.distance / 1000).ToString("0.00") + "\nKm"; ;

        fuelSlider.value = Player.fuel / 10;

        if (Player.fuel < 2.5)
        {
            fuelFill.color = colorRed;
            lowFuel.SetActive(true);
        }
        else if (Player.fuel < 5)
        {
            fuelFill.color = colorOrange;
            lowFuel.SetActive(false);
        }
        else
            fuelFill.color = colorGreen;

        if (isGameStarted == true)
        {
            total.SetActive(false);
            highScore.SetActive(false);
            distance.SetActive(true);
            fuel.SetActive(true);
            startGame.SetActive(false);
            quitGame.SetActive(false);
        }

        if(isGameOver == true && isGameStarted == true)
        {
            restartGame.SetActive(true);
            gameScoreText.text = (Player.gameScore / 1000).ToString("0.00") + "\nKm";
            gameScore.SetActive(true);
            lowFuel.SetActive(false);
            distance.SetActive(false);
            fuel.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    public static void GameOver()
    {
        isGameOver = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
