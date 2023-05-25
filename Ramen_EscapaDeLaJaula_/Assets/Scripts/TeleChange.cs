using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleChange : MonoBehaviour
{
    [SerializeField] private Texture2D noSiginal;
    [SerializeField] private Texture2D formula1;
    [SerializeField] private Material material;
    [SerializeField] private float intervalo = 40f;
    [HideInInspector] public bool matChanged = false;

    public IEnumerator ChangeTV()
    {
        while (true)
        {
            if (!matChanged)
            {
                yield return new WaitForSeconds(intervalo);
                material.SetTexture("_BaseMap", formula1);
                matChanged = true;
            }

        }

    }
    public void ResetMat()
    {
        material.SetTexture("_BaseMap", noSiginal);
        matChanged = false;
    }
}
