using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public static float distance = 0;

    private int carSpeed = -3;
    private float roadVerticalLength = 7.5f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, carSpeed);
    }

    void Update()
    {
        if(GamePlay.isGameStarted)
            distance += 1;
       
        if (transform.position.y < -roadVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, roadVerticalLength * 2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
