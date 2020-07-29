using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStarted = false;

    public GameObject startGame;
    public GameObject gameOver;
    public GameObject distance;
    public GameObject fuel;
    public GameObject lowFuel;
    public GameObject quitGame;

    public Slider fuelSlider;
    public Image fuelFill;
    public Text distanceText;

    public Color colorRed;
    public Color colorOrange;
    public Color colorGreen;

    void Awake()
    {
        isGameOver = false;
        isGameStarted = false;
    }

    void Update()
    {
        distanceText.text = (EndlessRoad.distance / 1000).ToString("0.00") + "\nKm";

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
            distance.SetActive(true);
            fuel.SetActive(true);
            startGame.SetActive(false);
            quitGame.SetActive(false);
        }

        if(isGameOver == true && isGameStarted == true)
        {
            lowFuel.SetActive(false);
            distance.SetActive(false);
            fuel.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
