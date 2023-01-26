using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string name;
    [SerializeField] private int maxHealth;
	private int health;

	[SerializeField] protected float standardSpeed;
	protected float speed; 

	protected float stunDuration;

	private AudioSource audioSource;
	protected void Start()
	{
		audioSource = GetComponent<AudioSource>();
		health = maxHealth;
		speed = standardSpeed;
	}
	public void Stun(float duration)
	{
		stunDuration = duration;
	}
	public int Damage(int damage)
	{
		audioSource.Play();
        health -= damage;
        if (health <= 0) Die();
        return damage;
	}
    protected virtual void Die()
	{
        Destroy(this.gameObject);
	}
}
