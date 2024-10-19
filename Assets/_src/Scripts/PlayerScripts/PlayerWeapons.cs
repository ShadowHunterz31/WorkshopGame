using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public WeaponScriptable[] weapons;
    public LayerMask enemieLayer;

    public void AddWeapon(WeaponScriptable weapon) 
    {
        
    }
    public void UpgradeWeapom(WeaponScriptable weapon)
    {

    }
    public void UseWeapon(WeaponScriptable weapon)
    {

    }


    public void Start()
    {
        InvokeRepeating("UseTargetWeapons",0f,1f);
    }

    public void UseTargetWeapons()
    {
        if (weapons.Length <= 0) return;
        foreach (WeaponScriptable weapon in weapons)
        {
            if (weapon.type != WeapontType.NeedTarget) continue;
            var nearbyEnemies = Physics.OverlapSphere(transform.position,weapon.Range,enemieLayer);
            if (nearbyEnemies.Length <= 0) continue;
            var closestTarget = nearbyEnemies[0];
            var closestDistance = 99999f;

            foreach(Collider enemy in nearbyEnemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);
                
                    if (distance < closestDistance)
                    {
                     closestTarget = enemy;
                    closestDistance = distance;
                     }
                    
                
            }

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.identity);
            projectile.GetComponent<TargetProjectile>().Init(closestTarget.transform);
        }
    }
}
