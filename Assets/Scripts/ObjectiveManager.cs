using UnityEngine;
using TMPro;

public class ObjectivesUI : MonoBehaviour
{
    public TextMeshProUGUI objectivesText;

    public int coinsCollected = 0;
    public int coinsNeeded = 5;

    public bool buttonPressed = false;
    public bool doorOpened = false;

    void Start()
    {
        UpdateObjectives();
    }

    public void CoinCollected()
    {
        coinsCollected++;
        UpdateObjectives();
    }

    public void SetButtonPressed()
    {
        buttonPressed = true;
        UpdateObjectives();
    }

    public void SetDoorOpened()
    {
        doorOpened = true;
        UpdateObjectives();
    }

    void UpdateObjectives()
    {
        if (objectivesText == null)
        {
            Debug.LogWarning("Objectives Text is missing!");
            return;
        }

        objectivesText.text =
            (coinsCollected >= coinsNeeded ? "[X]" : "[ ]") +
            " Collect 5 coins (" + coinsCollected + "/" + coinsNeeded + ")\n" +

            (buttonPressed ? "[X]" : "[ ]") +
            " Press the button\n" +

            (doorOpened ? "[X]" : "[ ]") +
            " Open the door";
    }
}
