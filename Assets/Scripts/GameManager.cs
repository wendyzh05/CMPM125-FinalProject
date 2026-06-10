using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform startPoint;

    public GameObject winText;
    public GameObject caughtText;

    public TMP_Text livesText;

    public static int lives = 3;

    private CharacterController controller;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();

        if (winText != null) winText.SetActive(false);
        if (caughtText != null) caughtText.SetActive(false);

        UpdateLivesText();
        RespawnPlayer(false);
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();

        if (lives <= 0)
        {
            lives = 3;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            RespawnPlayer(true);
        }
    }

    public void RespawnPlayer(bool showCaughtText)
    {
        if (showCaughtText && caughtText != null)
            caughtText.SetActive(true);

        if (controller != null) controller.enabled = false;

        player.position = startPoint.position;
        player.rotation = startPoint.rotation;

        if (controller != null) controller.enabled = true;

        if (showCaughtText)
            Invoke(nameof(HideCaughtText), 1f);
    }

    public void RespawnPlayer()
    {
        LoseLife();
    }

    void HideCaughtText()
    {
        if (caughtText != null) caughtText.SetActive(false);
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void WinGame()
    {
        if (winText != null) winText.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}
