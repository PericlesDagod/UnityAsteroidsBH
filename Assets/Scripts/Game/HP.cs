using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public Image imgHP;
    float currentHP = 1;

    // or damage if negative value
    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0) { GameOver(); return; } 

        if (currentHP > 1) currentHP = 1; 

        imgHP.fillAmount = currentHP;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Shield = gameObject.GetComponent<Shield>();
        if (Shield == null || !Shield.Active) Damage(0.28f);

    }

}
