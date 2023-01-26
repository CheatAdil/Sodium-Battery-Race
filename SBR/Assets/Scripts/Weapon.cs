using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] protected Transform user;
	private AudioSource audioSource;
	[SerializeField] private float bulletsPerSecond;
	public float secondsSinceLastBullet;
	protected void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	protected void Update()
	{
		if (secondsSinceLastBullet <= 1 / bulletsPerSecond) secondsSinceLastBullet += Time.deltaTime;
	}
	public void TryToFire()
	{
		
		if (secondsSinceLastBullet >= 1 / bulletsPerSecond) Fire();
	}
    public virtual void Fire()
	{
		secondsSinceLastBullet = 0f;
		audioSource.Play();
	}
}
