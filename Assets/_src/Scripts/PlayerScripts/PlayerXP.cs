using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int NeededExperience;
    public int CurrentExpierence;
    public PlayerWeapons WeaponScript;
    public void Awake()
    {
        WeaponScript = GetComponent<PlayerWeapons>();
    }
    public void LevelUp()
    {
        CurrentExpierence = 0;

        NeededExperience += 20;

        //WeaponScript.AddWeapon();
    }
    public void IncreaseXP(int amount)
    {
        CurrentExpierence += amount;
        if (CurrentExpierence >= NeededExperience) { 
            LevelUp();
        }
    }
}
