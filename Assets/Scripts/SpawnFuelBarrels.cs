using UnityEngine;

public class SpawnFuelBarrels : MonoBehaviour
{
    public GameObject fuelBarrel;
    private float spawnTime = 0f;
    public float spawnDelay = 1f;
    public float speedMultiplier = 1f;

    public void callInvoke()
    {

        InvokeRepeating("spawnFuelBarrel", spawnTime, spawnDelay);
    }

    public void cancelInvoke()
    {
        CancelInvoke("spawnFuelBarrel");
    }

    public void spawnFuelBarrel()
    {
        int i = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, 0, i);
        float xPos = Random.Range(-1.2f, 1.2f);
        GameObject clone = Instantiate(fuelBarrel, new Vector3(xPos, 14f, 0), rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -5 * speedMultiplier);
    }
}
