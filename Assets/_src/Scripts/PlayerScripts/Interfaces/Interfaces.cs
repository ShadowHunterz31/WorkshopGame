using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IDamageble
    {
        public void TakeDamage(int amount);
    }
    public interface IEnemy
    {

    }
    public interface ITargetWeapon
    {
    public void Init(Transform ptarget);
    }
