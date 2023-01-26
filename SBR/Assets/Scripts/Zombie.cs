using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Mob
{
	private void Start()
	{
		base.Start();
		target = GameObject.Find("Player").transform;
		//Temporary solution for while zombies can't find player otherwise
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") target = other.transform; 
		//Doesn't work
		//Will have to spawn zombies very close
	}
}
