using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private Button continueButton;

    public void EndGame()
    {
        float finalScore = scoreSystem.EndScoreCounter();
        scoreText.text = Mathf.FloorToInt(finalScore).ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuQuit()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        scoreSystem.StartScoreCounter();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        gameOverDisplay.gameObject.SetActive(false);
    }
}
