using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public static float fuel = 3;
    public SpawnVehicles spawnVehicles;
    public SpawnFuelBarrels spawnFuelBarrels;
    public AudioSource gameOver;
    public AudioSource carCrash;
    public AudioSource collectFuel;

    private int dir = 0;
    private Vector3 pos;

    void Awake()
    {
        fuel = 3;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GamePlay.isGameOver == true)
        {
            SceneManager.LoadScene("Main");
            return;
        }

        if (Input.GetMouseButtonDown(0) && GamePlay.isGameStarted == false)
        {
            spawnVehicles.callInvoke();
            spawnFuelBarrels.callInvoke();
            GamePlay.isGameStarted = true;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        { 
            StopCoroutine("movePlayer");
            StartCoroutine("movePlayer");
            dir = ~dir;
        }

        if (GamePlay.isGameStarted == true && EndlessRoad.distance % 500 == 0)
            fuel -= 1;

        if (fuel == 0 && GamePlay.isGameOver == false)
        {
            gameOver.Play(0);
            gameIsOver();
        }
    }

    private IEnumerator movePlayer()
    {
        if (dir == 0) pos = new Vector3(1.2f, -2f, 0f);
        else pos = new Vector3(-1.2f, -2f, 0f);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1)
        {
            transform.position = Vector3.Lerp(transform.position, pos, t);
            yield return null;
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Vehicle")
        {
            carCrash.Play(0);
            gameIsOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fuel")
        {
            collectFuel.Play(0);
            fuel += 1f;
            Destroy(col.gameObject);
        }
    }

    void gameIsOver()
    {
        spawnVehicles.cancelInvoke();
        spawnFuelBarrels.cancelInvoke();
        GamePlay.isGameOver = true;
    }
}
