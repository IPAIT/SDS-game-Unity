using UnityEngine;

public class Trigger_MoveOnce : MonoBehaviour
{
    public GameObject movingObject;       // Объект, который будет двигаться
    public GameObject objectToHide;       // Объект, который должен пропасть

    private bool canActivate = false;     // кто-то в триггере
    private bool hasActivated = false;    // чтобы E срабатывала один раз
    private bool shouldMove = false;      // запуск движения



    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated)
        {
            canActivate = true;
            Debug.Log("Нажмите E (в триггере: " + other.name + ")");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canActivate = false;

        if (!hasActivated)
            Debug.Log("Объект вышел из триггера до нажатия E: " + other.name);
    }

    private void Update()
    {
        if (canActivate && !hasActivated && Input.GetKeyDown(KeyCode.E))
        {
            shouldMove = true;
            hasActivated = true;

            Debug.Log("E нажата — объект начал движение.");
            if (objectToHide != null)
                objectToHide.SetActive(false);  // делаем объект невидимым
        }


        if (shouldMove && movingObject.transform.position.z > -40f)
        {
            movingObject.transform.position -= movingObject.transform.forward * 0.03f;
        }
    }
}