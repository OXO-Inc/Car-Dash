using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public int speed = -3;

    private Rigidbody2D rb2d;

    private float roadVerticalLength = 7.5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (transform.position.y < -roadVerticalLength)
        {
            RepositionBackground();
        }

        //TODO
        //if (EndlessRoad.instance.gameOver == true)
        //{
        //   rb2d.velocity = Vector2.zero;
        //}
    }
    private void FixedUpdate()
    {
        speed += -1;
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, roadVerticalLength * 2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
