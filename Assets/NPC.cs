using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject bubbleSprite;
    private bool hasInteracted = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        bubbleSprite.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            hasInteracted = true;
            StartCoroutine(ShowBubbleCoroutine());
        }
    }

    IEnumerator ShowBubbleCoroutine()
    {
        bubbleSprite.SetActive(true);
        yield return new WaitForSeconds(2f);
        bubbleSprite.SetActive(false);
    }

    public void GetPunched(Vector3 playerPosition)
    {
        Vector2 punchDirection = (transform.position - playerPosition).normalized;
        rb.AddForce(punchDirection * 10f, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse);
    }
}