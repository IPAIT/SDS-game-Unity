using UnityEngine;

public class Trigger_vorota : MonoBehaviour
{
    public GameObject Vorota;  // объект ворот
    public GameObject Pregrada;  // объект-преграда
    public Animator anim;  // ссылка на аниматор ворот

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cart"))
        {
            // Запускаем анимацию, когда любой объект входит в триггер
            Debug.Log("Объект вошел в ворота.");

            // Преграда исчезает
            //Pregrada.SetActive(false);
            Destroy(Pregrada);

            anim.SetTrigger("PlayTR");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
