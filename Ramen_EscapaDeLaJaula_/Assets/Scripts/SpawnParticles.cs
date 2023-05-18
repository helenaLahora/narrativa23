using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private GameObject PSPrefab;
    private GameObject PSBackup;
    public void SpawnPS()
    {
       PSBackup = Instantiate(PSPrefab,transform.position, Quaternion.identity);
    }
    public void DestroyPS()
    {
        if(PSBackup != null)  
        Destroy(PSBackup);
    }
}
