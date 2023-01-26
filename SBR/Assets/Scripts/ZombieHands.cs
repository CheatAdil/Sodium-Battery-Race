using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHands : Weapon
{
	public float range = 1f;
	public int damage = 5;
	override public void Fire()
	{
		Transform player = GameObject.Find("Player").transform;
		if (Vector3.Distance(player.position, transform.position) < range)
		{
			base.Fire();
			player.GetComponent<Entity>().Damage(damage);
		}
		
	}
}
