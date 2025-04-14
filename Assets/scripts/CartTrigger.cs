using UnityEngine;

public class CartTrigger : MonoBehaviour
{
    public GameObject cart;               // Ссылка на объект тележки
    public Transform[] wheels;            // Массив колес тележки (Transform)
    public GameObject objectToHide;       // Указанный объект, который должен исчезать
    public float moveSpeed = 3f;          // Скорость движения тележки
    public float rotationSpeed = 360f;    // Скорость вращения колес
    public float targetZ = -40f;          // Заданная координата по оси Z для остановки тележки

    private bool shouldMove = false;      // Флаг для начала движения
    private bool objectInTrigger = false; // Флаг для отслеживания, находится ли объект в триггере

    private void Update()
    {
        // Если объект в триггере и нажал клавишу E
        if (objectInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            shouldMove = true;
            Debug.Log("Тележка начинает движение.");

            // Скрываем указанный объект
            if (objectToHide != null)
            {

                objectToHide.SetActive(false);  // Скрываем объект
                
                Debug.Log("Указанный объект пропал.");
            }
        }

        // Если тележка должна двигаться, продолжаем ее движение и вращение колес
        if (shouldMove)
        {
            MoveCart();
            RotateWheels();
        }
    }

    // Метод для перемещения тележки
    private void MoveCart()
    {
        // Проверяем, достигла ли тележка целевой координаты
        if (cart.transform.position.z > targetZ)
        {
            // Если не достигнута, продолжаем движение вперед
            cart.transform.Translate(-Vector3.back * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Если достигнута цель, останавливаем движение
            shouldMove = false;
            Debug.Log("Тележка достигла цели.");
        }
    }

    // Метод для вращения колес
    private void RotateWheels()
    {
        // Вращаем каждое колесо по оси Z (Vector3.forward)
        foreach (Transform wheel in wheels)
        {
            // Вращаем колесо по оси Z
            wheel.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    // Метод для обработки входа объекта в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Когда объект входит в триггер, включаем флаг
        objectInTrigger = true;
        Debug.Log("Объект вошел в триггер.");
    }

    // Метод для обработки выхода объекта из триггера
    private void OnTriggerExit(Collider other)
    {
        // Когда объект выходит из триггера, выключаем флаг
        objectInTrigger = false;
        Debug.Log("Объект покинул триггер.");
    }
}