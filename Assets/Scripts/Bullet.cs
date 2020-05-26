using UnityEngine;

public class Bullet : MonoBehaviour
{

  public float bulletVelocity = 30f;

  void FixedUpdate()
  {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.MovePosition(rb.position + transform.up * bulletVelocity * Time.deltaTime);
  }
}