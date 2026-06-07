using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelDoor : MonoBehaviour
{
    public ButtonSwitch buttonSwitch;
    public string sceneToLoad = "Level2";

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (buttonSwitch != null && buttonSwitch.isActivated)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Door is locked! Press the button first.");
            }
        }
    }
}
