using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D RB;
    public float Speed = 12f;
    public bool lifeSpanActive = true;
    public float lifeSpan = 0.8f;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        RB.AddForce(transform.right * Speed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (lifeSpanActive) Score.Add(1);
    }

    void Update()
    {
        // Check lifeSpan
        if (lifeSpanActive)
        {
            lifeSpan -= Time.deltaTime;
            if (lifeSpan < 0) Destroy(gameObject);
        }
    }
}
