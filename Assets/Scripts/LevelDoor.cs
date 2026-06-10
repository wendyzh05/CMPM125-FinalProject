using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class LevelDoor : MonoBehaviour
{
    public ButtonSwitch buttonSwitch;
    public string sceneToLoad = "Level2";

    public TextMeshProUGUI promptText;

    void Start()
    {
        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && buttonSwitch != null && buttonSwitch.isActivated)
        {
            promptText.gameObject.SetActive(true);
            promptText.text = "Press E to open door";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") &&
            Keyboard.current.eKey.wasPressedThisFrame &&
            buttonSwitch != null &&
            buttonSwitch.isActivated)
        {
            FindFirstObjectByType<ObjectivesUI>()?.SetDoorOpened();
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && promptText != null)
            promptText.gameObject.SetActive(false);
    }
}
