using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    //piscar o inimigo

    private CaractherStatusManager StatusScript;

    public MeshRenderer myRenderer;
    private void Start()
    {
        if (gameObject.tag != "Enemy")
        {
            Init();
        }
    }
    public void Init()
    {
       StatusScript= GetComponent<CaractherStatusManager>();
       myRenderer= GetComponentInChildren<MeshRenderer>();

        SubscribeEvent();
    }
    private void SubscribeEvent()
    {
        Debug.Log("Inscrevi");

        StatusScript.OnTakeDamage += BlinkMaterial;
    }
    private void OnDisable()
    {
        Debug.Log("Desinscrevi");
        StatusScript.OnTakeDamage -= BlinkMaterial;
    }
    public void BlinkMaterial()
    {
        if (StatusScript == null) {
            Debug.LogError("Missing Status Script");
            return;
        } 
        
        if (myRenderer == null)
        {
            Debug.LogError("Missing MeshRenderer");
            return;
        }
        StartCoroutine(BlinkMaterialRoutine());
    }

    IEnumerator BlinkMaterialRoutine()
    {
        var myMaterial = myRenderer.materials[0];
        var myMaterialColor = myMaterial.color;

        myMaterial.color = Color.white;
        yield return new WaitForSeconds(0.2f);

        myMaterial.color = myMaterialColor;
    }

}
