using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Entity
{
	public GameObject weapon;
	private Weapon mobs_weapon;
	[SerializeField] protected Transform target;
	[SerializeField] protected float distanceToKeep;
	[SerializeField] protected float distanceToAllow;
	protected virtual void Start()
	{
		base.Start();
		if (weapon != null) mobs_weapon = weapon.GetComponent<Weapon>();
	}
	protected virtual void Update()
	{
		if (stunDuration > 0)
		{
			stunDuration -= Time.deltaTime;
			return;
		}
		if (target != null) Pursue();
	}
	private void Pursue()
	{
		Vector3 vectorToTarget = (target.position - transform.position);
		if (vectorToTarget.magnitude - distanceToKeep > speed * Time.deltaTime) transform.position += (vectorToTarget.normalized * speed * Time.deltaTime);
		else
		{
			UseWeapon();
			if (vectorToTarget.magnitude < distanceToAllow) transform.position += (-vectorToTarget.normalized * speed * Time.deltaTime);
		}
			
	}
    protected void UseWeapon()
	{
		mobs_weapon.TryToFire();
	}
}
