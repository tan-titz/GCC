using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Color selectedColor = Color.yellow;

    private bool isSelected = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (isSelected)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveX, moveY) * moveSpeed;
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnMouseDown()
    {
        isSelected = !isSelected;
        if (isSelected)
            spriteRenderer.color = selectedColor;
        else
            spriteRenderer.color = originalColor;
    }
}