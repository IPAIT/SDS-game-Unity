using UnityEngine;

public class Trigger_MoveOnce : MonoBehaviour
{
    public GameObject movingObject;       // ������, ������� ����� ���������
    public GameObject objectToHide;       // ������, ������� ������ ��������

    private bool canActivate = false;     // ���-�� � ��������
    private bool hasActivated = false;    // ����� E ����������� ���� ���
    private bool shouldMove = false;      // ������ ��������



    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated)
        {
            canActivate = true;
            Debug.Log("������� E (� ��������: " + other.name + ")");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canActivate = false;

        if (!hasActivated)
            Debug.Log("������ ����� �� �������� �� ������� E: " + other.name);
    }

    private void Update()
    {
        if (canActivate && !hasActivated && Input.GetKeyDown(KeyCode.E))
        {
            shouldMove = true;
            hasActivated = true;

            Debug.Log("E ������ � ������ ����� ��������.");
            if (objectToHide != null)
                objectToHide.SetActive(false);  // ������ ������ ���������
        }


        if (shouldMove && movingObject.transform.position.z > -40f)
        {
            movingObject.transform.position -= movingObject.transform.forward * 0.03f;
        }
    }
}