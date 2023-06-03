using UnityEngine;
using UnityEngine.UIElements;

public class TintChangeOnKeyPress : MonoBehaviour
{
    public UIDocument uiDocument;
    public KeyedImage[] keyedImages;

    private void Start()
    {
        foreach (var keyedImage in keyedImages)
        {
            var element = uiDocument.rootVisualElement.Q<VisualElement>(keyedImage.elementId);
            keyedImage.Initialize(element);
        }
    }

    private void Update()
    {
        foreach (var keyedImage in keyedImages)
        {
            if (Input.GetKeyDown(keyedImage.triggerKey))
            {
                keyedImage.SetTintColor();
            }
            else if (Input.GetKeyUp(keyedImage.triggerKey))
            {
                keyedImage.ResetTintColor();
            }
        }
    }
}

[System.Serializable]
public class KeyedImage
{
    public string elementId;
    public KeyCode triggerKey;
    public Color tintOnKeyPressColor;

    private VisualElement element;
    private StyleColor originalTintColor;

    public void Initialize(VisualElement targetElement)
    {
        element = targetElement;
        originalTintColor = element.style.unityBackgroundImageTintColor;
    }

    public void SetTintColor()
    {
        element.style.unityBackgroundImageTintColor = tintOnKeyPressColor;
    }

    public void ResetTintColor()
    {
        element.style.unityBackgroundImageTintColor = originalTintColor;
    }
}
