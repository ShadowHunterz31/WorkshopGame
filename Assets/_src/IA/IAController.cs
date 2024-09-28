using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;
    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Scripts Reference")]
    private IAStates IAStatesScript;
    private IAMovement IAMovementScript;
    private IACombat IACombatScript;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTransform;

    [Header("References Check")]
    [SerializeField] private bool referenceOk;

    private void Update()
    {
        if (referenceOk == false) return;
        if (playerTransform == null) return;

        if (IAStatesScript.states == IAStateType.CHASING)
        {
            ChasingBehaviour();
            return;
        }
        if (IAStatesScript.states == IAStateType.ATTACKING)
        {
            AttackingBehaviour();
            return;
        }
    }
    public void Init(EnemyScriptable pbarin)
    {
        referenceOk = false;
        IAStatesScript = GetComponent<IAStates>();
        IAMovementScript = GetComponent<IAMovement>();
        IACombatScript = GetComponent<IACombat>();

        brain = pbarin;
        IACombatScript.Init(brain);

        InstantiateGraphics();
        FindPlayerReference();
        referenceOk = true;
    }
    void ChasingBehaviour()
    {
        var sucess = IAMovementScript.Chase(playerTransform);
        if (sucess == false)
        {
            IAStatesScript.ChangeToState(IAStateType.ATTACKING);
        }
    }
    void AttackingBehaviour()
    {
        var sucess = IACombatScript.CheckAndAttack(playerTransform);
        if (sucess == false)
        {
            IAStatesScript.ChangeToState(IAStateType.CHASING);
        }
    }
    void InstantiateGraphics()
    {
        Instantiate(brain.GFX, GFXTransform);
    }

    void FindPlayerReference()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
