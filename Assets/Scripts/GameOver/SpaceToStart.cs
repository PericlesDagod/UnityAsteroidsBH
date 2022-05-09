using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToStart : MonoBehaviour
{
    public TextMeshProUGUI textUGUI;

    void Start()
    {
        textUGUI.text = $"Last Score : {Score.Points}";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartGame();
    }

    void StartGame()
    {
        Score.Points = 0;
        SceneManager.LoadScene("Game");
    }
}
