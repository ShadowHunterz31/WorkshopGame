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
    private CaractherStatusManager IAStatusScript;
    private DamageHandler IADamageHandlerScript;

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
        IAStatusScript = GetComponent<CaractherStatusManager>();
        IADamageHandlerScript = GetComponent<DamageHandler>();


        brain = pbarin;
        IACombatScript.Init(brain);
        IAMovementScript.Init(brain);
        IAStatusScript.InitStatus(brain.Status);

        InstantiateGraphics();
        FindPlayerReference();

        IADamageHandlerScript.Init();

        referenceOk = true;
    }
    void ChasingBehaviour()
    {
        if (playerTransform == null) return;
        if (IAMovementScript == null) return;

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
        var gfx = Instantiate(brain.GFX, GFXTransform);
        gfx.transform.parent = this.transform;
    }

    void FindPlayerReference()
    {
        var playerReference = GameObject.FindGameObjectWithTag("Player");
        if (playerReference == null) return;
        playerTransform = playerReference.transform;
    }

}
