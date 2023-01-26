using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage = 5;
	public float speed = 5;
	private Vector3 direction;
	public float knockback = 50;
	public float stunDuration = 0f;
	public float secondsBeforeDying = 5f;
	
	public void SetDirection(Vector3 newDir)
	{
		direction = newDir.normalized;
	}
	private void Update()
	{
		transform.position += direction * speed * Time.deltaTime;
		if (secondsBeforeDying > 0) secondsBeforeDying -= Time.deltaTime;
		else Destroy(this.gameObject);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy" && collision.gameObject.TryGetComponent<Entity>(out Entity entity))
		{
			entity.Damage(damage);
			entity.Stun(stunDuration);
			collision.transform.position += (direction * knockback)/collision.attachedRigidbody.mass;
		}
		Destroy(this.gameObject);
	}
}
