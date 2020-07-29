using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Text distanceText;

    public static bool isGameOver = false;
    public static bool isGameStarted = false;

    public GameObject startGame;
    public GameObject gameOver;
    public GameObject distance;
    public GameObject fuel;

    void Awake()
    {
        isGameOver = false;
        isGameStarted = false;
    }

    void Update()
    {
        
        distanceText.text = (EndlessRoad.distance / 1000).ToString("0.00") + "\nKm";

        if (isGameStarted == true)
        {
            distance.SetActive(true);
            fuel.SetActive(true);
            startGame.SetActive(false);
        }

        if(isGameOver == true && isGameStarted == true)
        {
            distance.SetActive(false);
            fuel.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
