using UnityEngine;

public class CartTrigger : MonoBehaviour
{
    public GameObject cart;               // ������ �� ������ �������
    public Transform[] wheels;            // ������ ����� ������� (Transform)
    public GameObject objectToHide;       // ��������� ������, ������� ������ ��������
    public float moveSpeed = 3f;          // �������� �������� �������
    public float rotationSpeed = 360f;    // �������� �������� �����
    public float targetZ = -40f;          // �������� ���������� �� ��� Z ��� ��������� �������

    private bool shouldMove = false;      // ���� ��� ������ ��������
    private bool objectInTrigger = false; // ���� ��� ������������, ��������� �� ������ � ��������

    private void Update()
    {
        // ���� ������ � �������� � ����� ������� E
        if (objectInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            shouldMove = true;
            Debug.Log("������� �������� ��������.");

            // �������� ��������� ������
            if (objectToHide != null)
            {

                objectToHide.SetActive(false);  // �������� ������
                
                Debug.Log("��������� ������ ������.");
            }
        }

        // ���� ������� ������ ���������, ���������� �� �������� � �������� �����
        if (shouldMove)
        {
            MoveCart();
            RotateWheels();
        }
    }

    // ����� ��� ����������� �������
    private void MoveCart()
    {
        // ���������, �������� �� ������� ������� ����������
        if (cart.transform.position.z > targetZ)
        {
            // ���� �� ����������, ���������� �������� ������
            cart.transform.Translate(-Vector3.back * moveSpeed * Time.deltaTime);
        }
        else
        {
            // ���� ���������� ����, ������������� ��������
            shouldMove = false;
            Debug.Log("������� �������� ����.");
        }
    }

    // ����� ��� �������� �����
    private void RotateWheels()
    {
        // ������� ������ ������ �� ��� Z (Vector3.forward)
        foreach (Transform wheel in wheels)
        {
            // ������� ������ �� ��� Z
            wheel.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    // ����� ��� ��������� ����� ������� � �������
    private void OnTriggerEnter(Collider other)
    {
        // ����� ������ ������ � �������, �������� ����
        objectInTrigger = true;
        Debug.Log("������ ����� � �������.");
    }

    // ����� ��� ��������� ������ ������� �� ��������
    private void OnTriggerExit(Collider other)
    {
        // ����� ������ ������� �� ��������, ��������� ����
        objectInTrigger = false;
        Debug.Log("������ ������� �������.");
    }
}