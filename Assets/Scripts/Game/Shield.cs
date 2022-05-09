using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Image ImgMP;
    public SpriteRenderer ShieldSR;
    public float Consumption = 0.4f;
    public float RecoverRate = 0.01f;
    float CurrentMP = 1;
    public bool Active = false;

    private void SetActive(bool value)
    {
        Active = value; ShieldSR.enabled = value;

        // Disable/Enable Auto Shoot
        var AutoShoot = gameObject.GetComponent<AutoShoot>();
        if (AutoShoot != null)
        {
            AutoShoot.enabled = !value;
        }
    }

    void Update()
    {
        if (Active)
        {
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) SetActive(false);
            else
            {
                CurrentMP -= Consumption * Time.deltaTime;

                if (CurrentMP <= 0) SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SetActive(true);
            else
            {
                CurrentMP += RecoverRate * Time.deltaTime;

                if (CurrentMP > 1) CurrentMP = 1f;
            }
        }

        ImgMP.fillAmount = CurrentMP;
    }
}
