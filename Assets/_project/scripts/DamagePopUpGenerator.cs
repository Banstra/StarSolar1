using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopUpGenerator : MonoBehaviour
{
    public bool outside;

    public statsPlayer playerAtm;
    public statsPlayer enemyAtm;
    private void OnTriggerEnter(Collider other)
    {
        outside = false;
    }
    private void OnTriggerExit(Collider other)
    {
        outside=true;
    }
    private void DamageRecived()
    {
        enemyAtm.DealDamage(playerAtm.gameObject);
    }
}
