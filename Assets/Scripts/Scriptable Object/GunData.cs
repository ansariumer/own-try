using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Gun", menuName="Weapon/Gun")]
public class GunData : ScriptableObject
{
	[Header("Info")]
	public new string name;

	[Header("Shooting")] 
	public float damage;
	public float maxDistance;
     
	[Header("Reloading")]
	public int magzines;
	public int currentAmmo;
	public int magSize;
	public float FireRate;
	public float reloadTime;
	
	[HideInInspector]
	public bool reloading;


}
