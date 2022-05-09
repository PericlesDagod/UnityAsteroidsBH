using UnityEngine;

public class Teleport : MonoBehaviour
{
    float weight; float heigth;

    void Start()
    {
        weight = gameObject.transform.localScale.x/2;
        heigth = gameObject.transform.localScale.y/2;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float x = collision.transform.position.x; float y = collision.transform.position.y;

        if (x < -weight || x > weight) x = -x;
        if (y < -heigth || y > heigth) y = -y;

        collision.gameObject.transform.position = new Vector3(x, y, 0);
    }
}
