using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.P))
        {
            Punch();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Punch()
    {
        Collider2D[] hitNPCs = Physics2D.OverlapCircleAll(transform.position, 2f);
        foreach (Collider2D npc in hitNPCs)
        {
            if (npc.CompareTag("NPC"))
            {
                npc.GetComponent<NPC>().GetPunched(transform.position);
            }
        }
    }
}