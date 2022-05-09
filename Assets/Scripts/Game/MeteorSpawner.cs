using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public Projectile Meteor;
    public BoxCollider2D Zone; // Spawn Zone
    public Transform EvadePoint; public float EvasionRadius = 3; // Not spawn near to this point
    public float SpawnCooldown = 0.7f; float CurrentSpawnCooldown = 1f; // Spawn Timer

    private Vector2 SpawnPos;

    void Update()
    {
        CurrentSpawnCooldown -= Time.deltaTime;

        if (CurrentSpawnCooldown < 0) TrySpawn();
    }

    void TrySpawn()
    {
        SpawnPos = GetRandomPointInZone();

        if (CanSpawn()) Spawn();
    }

    Vector2 GetRandomPointInZone()
    {
        return new Vector2( Random.Range(Zone.bounds.min.x, Zone.bounds.max.x), Random.Range(Zone.bounds.min.y, Zone.bounds.max.y) );
    }

    bool CanSpawn()
    {
        return Mathf.Pow(EvadePoint.position.x - SpawnPos.x, 2) + Mathf.Pow(EvadePoint.position.y - SpawnPos.y, 2) > Mathf.Pow(EvasionRadius, 2);
    }

    void Spawn()
    {
        Meteor.gameObject.SetActive(false);
        var M = Instantiate(Meteor, SpawnPos, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));

        M.GetComponent<Projectile>().lifeSpanActive = false;
        M.transform.localScale = Vector3.one;
        M.GetComponent<SpriteRenderer>().color = Color.white;

        M.gameObject.SetActive(true); Meteor.gameObject.SetActive(true);

        CurrentSpawnCooldown += SpawnCooldown;
    }
}
