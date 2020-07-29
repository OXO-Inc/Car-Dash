using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public static float distance = 0;

    private int carSpeed = -3;
    private float roadVerticalLength = 7.5f;
    private Rigidbody2D rb2d;

    void Awake()
    {
        distance = 0;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, carSpeed);
    }

    void Update()
    {
        if (GamePlay.isGameStarted)
            distance += 1;
       
        if (transform.position.y < -roadVerticalLength)
        {
            RepositionBackground();
        }
    }

    void FixedUpdate()
    {
        if (GamePlay.isGameStarted && distance % 500 == 0)
        {
            carSpeed -= 1;
            rb2d.velocity = new Vector2(0, carSpeed);
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, roadVerticalLength * 2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
