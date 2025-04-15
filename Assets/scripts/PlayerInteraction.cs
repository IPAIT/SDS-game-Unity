using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Animator gateAnimator;
    public LayerMask interactMask;
    public float interactDistance = 3f;

    private bool hasKey = false;
    private bool gateOpened = false;

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
                else if (hit.collider.CompareTag("Gate"))
                {
                    if (hasKey && !gateOpened)
                    {
                        // Открытие ворот
                        gateAnimator.SetBool("isOpen", true);
                        gateOpened = true;
                        Debug.Log("Ворота открываются");
                    }
                    else if (!hasKey)
                    {
                        Debug.Log("Нужен ключ, чтобы открыть ворота");
                    }
                }
            }
        }
    }
}
