using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class CaractherStatusManager : MonoBehaviour, IDamageble
{
    public Status status;

    public event Action OnTakeDamage;


    public void InitStatus(Status pstatus)
    {

        status.Health = pstatus.Health;
        status.Armor = pstatus.Armor;
        status.MagicResist = pstatus.MagicResist;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TOMANDO "+amount+" DE DANO");
        status.Health -= amount;
        OnTakeDamage?.Invoke();

        if (status.Health <= 0)
        {

            Die();
        }
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
