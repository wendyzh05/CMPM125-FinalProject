using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSwitch : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;

    public AudioClip buttonSound;

    public bool isActivated = false;

    private Renderer buttonRenderer;
    private AudioSource audioSource;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        buttonRenderer.material = redMaterial;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") &&
            Keyboard.current.eKey.wasPressedThisFrame &&
            !isActivated)
        {
            ActivateButton();
        }
    }

    void ActivateButton()
    {
        isActivated = true;

        buttonRenderer.material = greenMaterial;

        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }

        if (ObjectiveManager.instance != null)
        {
            ObjectiveManager.instance.ButtonFound();
        }
    }
}
