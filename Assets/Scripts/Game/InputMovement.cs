using UnityEngine;


public class InputMovement : MonoBehaviour
{
    Rigidbody2D RB;
    bool foward = false; bool left = false; bool right = false;
    public float RotationSPD = 256f;
    public float Acc = 256; // Acceleration

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInputs();
        Move();
    }

    void CheckInputs()
    {
        // Foward
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) foward = true;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) foward = false;

        // Left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) left = true;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) left = false;

        // Right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) right = true;
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) right = false;
    }

    private void Move()
    {
        if (foward) RB.AddForce(transform.right * Acc * Time.deltaTime);
        if (left) transform.Rotate(0, 0, RotationSPD * Time.deltaTime);
        if (right) transform.Rotate(0, 0, -RotationSPD * Time.deltaTime);
    }
}
