using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    private int dir = 0;
    private Vector3 pos;

    public SpawnVehicles spawnVehicles;
    
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && GamePlay.isGameOver == true)
        {
            SceneManager.LoadScene("Main");
            return;
        }

        if (Input.GetMouseButtonDown(0) && GamePlay.isGameStarted == false)
        {
            spawnVehicles.callInvoke();
            GamePlay.isGameStarted = true;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        { 
            StopCoroutine("movePlayer");
            StartCoroutine("movePlayer");
            dir = ~dir;
        }
    }

    private IEnumerator movePlayer()
    {
        if (dir == 0) pos = new Vector3(1.2f, -3f, 0f);
        else pos = new Vector3(-1.2f, -3f, 0f);

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
            GamePlay.isGameOver = true;
            spawnVehicles.cancelInvoke();
        }
    }

}
