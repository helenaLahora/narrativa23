using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtiquetaLookAt : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject target;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position, target.transform.rotation * Vector3.up);
    }
}
