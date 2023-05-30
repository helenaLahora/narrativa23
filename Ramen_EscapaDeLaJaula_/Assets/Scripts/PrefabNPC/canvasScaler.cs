using UnityEngine;

public class canvasScaler : MonoBehaviour
{
    public SphereCollider targetCollider;
    public float scaleFactor = 2f;

    private bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        SphereCollider sphereCollider = other.GetComponent<SphereCollider>();
        if (sphereCollider != null && sphereCollider == targetCollider && !hasEntered)
        {
            hasEntered = true;
            ResizeCanvas();
        }
    }

    private void ResizeCanvas()
    {
        Canvas canvas = GetComponent<Canvas>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta *= scaleFactor;
        }
    }
}