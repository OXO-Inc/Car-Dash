using UnityEngine;

public class SpawnVehicles : MonoBehaviour
{
    public GameObject[] vehiclePrefabss;
    private float spawnTime = 0f;
    public float spawnDelay = 1f;
    public float speedMultiplier = 1f;

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
        int i = Random.Range(0,vehiclePrefabss.Length);
        Quaternion rotation = Quaternion.Euler(180, 0, 0);
        int pos = Random.Range(0, 2);
        GameObject clone = Instantiate(vehiclePrefabss[i], new Vector3(pos == 0 ? -1.2f : 1.2f, 14f, 0), rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -10 * speedMultiplier);
    }
}
