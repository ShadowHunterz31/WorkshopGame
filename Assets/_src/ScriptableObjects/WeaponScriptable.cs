using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponScriptable : ScriptableObject
{

    public float damage;
    public float Range;
    public float AttackSpeed;
    public float projectileSpeed;
    public float CurrentCooldown;
    public WeapontType type;

    public GameObject proj;

}
