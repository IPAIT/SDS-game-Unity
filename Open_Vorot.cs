using UnityEngine;

public class Trigger_vorota : MonoBehaviour
{
    public GameObject Vorota;  // ������ �����
    public GameObject Pregrada;  // ������-��������
    public Animator anim;  // ������ �� �������� �����

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cart"))
        {
            // ��������� ��������, ����� ����� ������ ������ � �������
            Debug.Log("������ ����� � ������.");

            // �������� ��������
            //Pregrada.SetActive(false);
            Destroy(Pregrada);

            anim.SetTrigger("PlayTR");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
