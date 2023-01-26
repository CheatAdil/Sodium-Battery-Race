using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mob
{
    private Transform gun;
    
	private void Start()
	{
        base.Start();
        gun = weapon.transform;
	}
	private void Update()
    {
        if (stunDuration > 0)
        {
            stunDuration -= Time.deltaTime;
            return;
        }

        speed = standardSpeed * Time.deltaTime;
        transform.position += (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed);
        WeapongHandling();

    }
    private void WeapongHandling()
	{
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
        gun.localPosition = (mousePos - transform.position).normalized/5;
        gun.LookAt(mousePos);
        /*
        float angle = Mathf.Acos(-gun.localPosition.x / (Mathf.Sqrt(gun.localPosition.x * gun.localPosition.x + gun.localPosition.y * gun.localPosition.y) * -1));
        angle *= 180f / Mathf.PI;
        gun.localRotation = Quaternion.Euler(0f, 0f, angle);
        if (gun.localPosition.y > 0) gun.localRotation = Quaternion.Euler(0f, 0f, angle);
        else gun.localRotation = Quaternion.Euler(0f, 0f, -angle);

        if (gun.localPosition.x > 0) gun.localScale = new Vector3(-0.5f, 0.5f, 1f);
        else gun.localScale = new Vector3(-0.5f, -0.5f, 1f);
        */
        if (Input.GetMouseButton(0)) UseWeapon();
    }
}
