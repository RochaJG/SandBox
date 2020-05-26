using UnityEngine;

public class Gun : MonoBehaviour
{
  public float damage = 10f;
  public float range = 100f;
  public float fireRate = 15f;
  public float impactForce = 30f;

  public Camera fpsCam;
  public ParticleSystem muzzleFlash;
  public GameObject impactEffect;
  public GameObject bullet;
  public Transform bulletSpawn;

  private float nextTimeToFire = 0f;

  void Update()
  {
    if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
    {
      nextTimeToFire = Time.time + 1f / fireRate;
      Shoot();
    }
  }

  void Shoot()
  {
    muzzleFlash.Play();
    GameObject bulletGO = Instantiate(bullet, bulletSpawn.position, Quaternion.LookRotation(bulletSpawn.transform.up, bulletSpawn.transform.forward));

    RaycastHit hit;
    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    {
      GunTarget target = hit.transform.GetComponent<GunTarget>();

      if (target != null)
      {
        target.TakeDamege(damage);
      }

      if (hit.rigidbody != null)
      {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }

      GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
      Destroy(impactGO, 2f);
    }
    Destroy(bulletGO, 5f);
  }
}
