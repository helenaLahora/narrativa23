using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleChange : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 startingPosition;
    [SerializeField] private Material noSignal;
    [SerializeField] private Material formula1;
    private Renderer tvRenderer;
    [Header("Los intervalos se miden en segundos")]
    [SerializeField] private float intervalo = 40f;
    [SerializeField] private float intervaloMuerte = 30f;
    [SerializeField] private float intervaloGrande = 180;
    [HideInInspector] public bool matChanged = false;
    private Coroutine cambiandoTV;
    private void Awake()
    {
        startingPosition = player.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        tvRenderer = GetComponent<Renderer>();
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SafeTime());
        }
    }
    private IEnumerator SafeTime()
    {
        yield return new WaitForSeconds(intervaloGrande);
        cambiandoTV = StartCoroutine(ChangeTV());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && cambiandoTV != null)
        {
            StopCoroutine(ChangeTV());
        }
    }
    private IEnumerator ChangeTV()
    {       
            if (!matChanged)
            {
                yield return new WaitForSeconds(intervalo);
                tvRenderer.material = formula1;
                matChanged = true;
            }      
    }
    public void ResetMat()
    {
        tvRenderer.material = noSignal;
        matChanged = false;
    }
    private IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(intervaloMuerte);
        if (tvRenderer.material == formula1)
        {
            player.position = startingPosition;
        }
    }
}
