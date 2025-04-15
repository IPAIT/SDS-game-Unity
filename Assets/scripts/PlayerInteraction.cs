using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Animator gateAnimator;
    public LayerMask interactMask;
    public float interactDistance = 3f;

    private bool hasKey = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, interactMask))
            {
                if (hit.collider.CompareTag("Key"))
                {
                    // Подбор ключа
                    Destroy(hit.collider.gameObject);
                    hasKey = true;
                    Debug.Log("Ключ подобран");
                }
                else if (hit.collider.CompareTag("Gate") && hasKey)
                {
                    // Открытие ворот
                    gateAnimator.SetBool("isOpen", true);
                    Debug.Log("Ворота открываются");
                }
                else if (hit.collider.CompareTag("Gate") && !hasKey)
                {
                    Debug.Log("Нужен ключ, чтобы открыть ворота");
                }
            }
        }
    }
}
