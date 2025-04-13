using UnityEngine;

public class IsometryKamera : MonoBehaviour
{
    public Transform target;  // Объект, за которым следит камера
    public float distance = 10f;  // Расстояние от цели
    public float height = 10f;  // Высота над целью
    public float rotationAngle = 45f;  // Угол поворота

    void LateUpdate()
    {
        if (target == null) return;

        // Вычисляем позицию камеры в изометрическом стиле
        Vector3 offset = Quaternion.Euler(0, rotationAngle, 0) * new Vector3(0, 0, -distance);
        Vector3 desiredPosition = target.position + offset + Vector3.up * height;

        // Перемещаем камеру в нужную точку
        transform.position = desiredPosition;

        // Поворачиваем камеру, чтобы она смотрела на цель
        transform.LookAt(target.position);
    }
}
