using UnityEngine;
using UnityEngine.InputSystem;

public class Colorchange : MonoBehaviour
{
    public float speed = 5f; // Скорость передвижения
    private void Update()
    {
        // Передвижение, если клавиша нажата и удерживается
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * -speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * -speed);
        }
    }
}