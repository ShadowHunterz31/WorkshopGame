using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAStates : MonoBehaviour
{

    public IAStateType states;

    public void ChangeToState(IAStateType state)
    {
        if (states == state) return;

        // animacao troca de estado
        //Coisas ao trocar de estado

        states = state;
    }

}
