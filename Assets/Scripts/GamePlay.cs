using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStarted = false;

    public GameObject startGame;
    public GameObject gameOver;

    void Awake()
    {
        isGameOver = false;
        isGameStarted = false;
    }

    void Start()
    {
        Debug.Log("Game Over " + isGameOver);
        Debug.Log("Game Started " + isGameStarted);
    }

    void Update()
    {
        if(isGameStarted == true)
        {
            startGame.SetActive(false);
        }

        if(isGameOver == true && isGameStarted == true)
        {
            gameOver.SetActive(true);
        }
    }
}
