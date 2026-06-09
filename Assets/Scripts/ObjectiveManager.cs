using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    public TMP_Text objectiveText;

    public bool buttonFound = false;
    public bool escaped = false;

    public int coinsCollected = 0;
    public int coinsRequired = 5;

    public bool levelUsesCoins = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateObjectives();
    }

    public void ButtonFound()
    {
        buttonFound = true;
        UpdateObjectives();
    }

    public void CoinCollected()
    {
        coinsCollected++;
        UpdateObjectives();
    }

    public void Escaped()
    {
        escaped = true;
        UpdateObjectives();
    }

    public void UpdateObjectives()
    {
        string objectives = "OBJECTIVES\n";

        objectives += buttonFound
            ? "✓ Find the button\n"
            : "☐ Find the button\n";

        if (levelUsesCoins)
        {
            if (coinsCollected >= coinsRequired)
                objectives += $"✓ Collect Coins ({coinsRequired}/{coinsRequired})\n";
            else
                objectives += $"☐ Collect Coins ({coinsCollected}/{coinsRequired})\n";
        }

        objectives += escaped
            ? "✓ Escape through the door"
            : "☐ Escape through the door";

        objectiveText.text = objectives;
    }
}
