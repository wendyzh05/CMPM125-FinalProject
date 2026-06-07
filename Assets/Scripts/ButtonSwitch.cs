using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSwitch : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;

    public bool isActivated = false;

    private Renderer buttonRenderer;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        buttonRenderer.material = redMaterial;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Keyboard.current.eKey.wasPressedThisFrame)
        {
            isActivated = true;
            buttonRenderer.material = greenMaterial;
        }
    }
}
