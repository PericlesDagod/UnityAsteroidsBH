using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int Points = 0;
    public static TextMeshProUGUI textUGUI;

    public static void Add(int points)
    {
        Points += points;
        textUGUI.text = $"{Points}";
    }

    void Start()
    {
        textUGUI = GetComponent<TextMeshProUGUI>();
        textUGUI.text = $"{Points}";
    }
}
