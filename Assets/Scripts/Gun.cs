using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[Header("References")]
    [SerializeField] private GunData gunData;
	[SerializeField] private Transform muzzle;

	[Header("Keybinds")]
	public KeyCode ReloadKey = KeyCode.R;
	
	float timeSinceLastShot;

	private void Start (){
		PlayerShoot.shootInput += Shoot;
		PlayerShoot.reloadInput += Starteload;
	}

	public void Starteload(){
		if (!gunData.reloading){
			StartCoroutine(Reload());
		}
	}

	private IEnumerator Reload (){
		if(gunData.magzines <= 0){

			gunData.reloading = true;

			yield return new WaitForSeconds(gunData.reloadTime);

			gunData.currentAmmo = gunData.magSize;
			gunData.magzines--;
			
			gunData.reloading = false;
		}
	}

	private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.FireRate / 60f);

	public void Shoot(){
		if (gunData.currentAmmo > 0){

			if (CanShoot()){

				if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance)){

					Debug.Log(hitInfo.transform.name);
				}

				gunData.currentAmmo--;
				timeSinceLastShot = 0;
				OnGunShot();
			}
		}
		
	}
	private void Update(){
		timeSinceLastShot += Time.deltaTime;

		Debug.DrawRay(muzzle.position, muzzle.forward);
	}

	private void OnGunShot(){
	     
	}
}
