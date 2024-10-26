using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingProjectile : Projectile,ITargetWeapon
{
    public Transform Target;
    public override void Awake()
    {
        base.Awake();

    }
    public override void Init(Transform ptarget)
    {
        base.Init();
        Target = ptarget;

        isReady = true;

        Destroy(this.gameObject, 10f);
    }
    public override void Update()
    {
        if (isReady == false) return;
        if (Target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * brain.projectileSpeed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        //dar dano

        other.gameObject.GetComponent<IDamageble>().TakeDamage(brain.damage);

        Destroy(this.gameObject);
    }
}
