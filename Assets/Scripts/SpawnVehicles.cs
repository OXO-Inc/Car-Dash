using UnityEngine;

public class SpawnVehicles : MonoBehaviour
{
    public GameObject[] vehiclePrefabss;

    private float spawnDelay = 1f;
    private float speedMultiplier = 1f;
    private float spawnTime = 0f;

    void Update()
    {
        if (GamePlay.isGameStarted && EndlessRoad.distance % 500 == 0)
        {
            speedMultiplier += .5f;
            spawnDelay -= .05f;
        }
    }

    public void callInvoke()
    {
        InvokeRepeating("spawnVehicle", spawnTime, spawnDelay);
    }

    public void cancelInvoke()
    {
        CancelInvoke("spawnVehicle");
    }

    public void spawnVehicle()
    {
        Quaternion rotation = Quaternion.Euler(180, 0, 0);

        int i = Random.Range(0, vehiclePrefabss.Length);
        int pos = Random.Range(0, 2);
        GameObject clone = Instantiate(vehiclePrefabss[i], new Vector3(pos == 0 ? -1.2f : 1.2f, 14f, 0), rotation);

        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -10 * speedMultiplier);
    }
}
