using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonSwitch : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public AudioClip buttonSound;
    public Light buttonLight;

    public TextMeshProUGUI promptText;

    public bool isActivated = false;

    private Renderer buttonRenderer;
    private AudioSource audioSource;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        buttonRenderer.material = redMaterial;

        if (buttonLight != null)
            buttonLight.color = Color.red;

        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            promptText.gameObject.SetActive(true);
            promptText.text = "Press E to activate button";
        }
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

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void ActivateButton()
    {
        isActivated = true;

        buttonRenderer.material = greenMaterial;

        if (buttonLight != null)
            buttonLight.color = Color.green;

        if (buttonSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonSound);

        if (promptText != null)
            promptText.gameObject.SetActive(false);

        FindFirstObjectByType<ObjectivesUI>()?.SetButtonPressed();
    }
}
