using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : Weapon
{
	[SerializeField] private GameObject weaponBullet;
	[SerializeField] private Transform shootingPoint;
	[SerializeField] private int energyUse;
	[SerializeField] private float userKnockback;
    override public void Fire()
	{
		Rigidbody2D bullet = Instantiate(weaponBullet, shootingPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
		bullet.GetComponent<Bullet>().SetDirection(bullet.transform.position - transform.position);
		user.position += ((bullet.transform.position - transform.position).normalized * -userKnockback);
		base.Fire();
	}
}
