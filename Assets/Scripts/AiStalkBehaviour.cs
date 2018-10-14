using UnityEngine;

public class AiStalkBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float movementAmountPerFrame = 0.03f;
    [SerializeField]
    private float keepDistanceInM = 0.5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            Debug.Log("Player transform in AiStalkBehaviour is null; using Find");
            GameObject temp = GameObject.Find("Player");
            if (temp != null)
            {
                player = GameObject.Find("Player").transform;
            }
        }
    }
    
    void Update()
    {
        if(player == null) //TODO: next add a check for whether AI can see player
        {
            return;
        }

        Vector2 newPosition = transform.position;
        Vector2 distanceVector = (Vector2)player.position - newPosition;

        float maxDistanceToMoveTowardPlayer = distanceVector.magnitude - keepDistanceInM;
        if (maxDistanceToMoveTowardPlayer > 0)
        {
            maxDistanceToMoveTowardPlayer = Mathf.Min(maxDistanceToMoveTowardPlayer, movementAmountPerFrame);
            newPosition += (distanceVector.normalized * maxDistanceToMoveTowardPlayer);

            rb.MovePosition(newPosition);
        }
    }
}
