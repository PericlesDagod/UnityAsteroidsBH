using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public Projectile Projectile;
    public Transform GunOffset;
    public bool Enabled = true;
    public float GunCooldown = 0.6f;
    private float CurrentGunCooldown = 1f;

    void Update()
    {
        if (!Enabled) return;

        CurrentGunCooldown -= Time.deltaTime;

        if (CurrentGunCooldown < 0) Shoot();
    }

    void Shoot()
    {
        Instantiate(Projectile, GunOffset.position, transform.rotation);

        CurrentGunCooldown += GunCooldown;
    }
}
