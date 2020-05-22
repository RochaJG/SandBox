using UnityEngine;

public class GunTarget : MonoBehaviour
{
  public float health = 50f;

  public void TakeDamege(float amount)
  {
    health -= amount;
    if (health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    Destroy(gameObject);
  }
}
