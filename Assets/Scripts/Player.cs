using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementAmountPerFrame = 0.03f;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        if(Input.GetButton("Up"))
        {
            newPosition = new Vector2(newPosition.x, newPosition.y + movementAmountPerFrame);
        }
        if(Input.GetButton("Down"))
        {
            newPosition = new Vector2(newPosition.x, newPosition.y - movementAmountPerFrame);
        }
        if (Input.GetButton("Left"))
        {
            newPosition = new Vector2(newPosition.x - movementAmountPerFrame, newPosition.y);
        }
        if (Input.GetButton("Right"))
        {
            newPosition = new Vector2(newPosition.x + movementAmountPerFrame, newPosition.y);
        }
        rb.MovePosition(newPosition);
    }
}
