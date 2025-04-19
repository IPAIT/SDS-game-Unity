using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [Header("����� ���������")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lol"))
        {
            Debug.Log("���");
            TipsManager.displayTipEvent?.Invoke(message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("lol"))
        {
            Debug.Log("���");
            TipsManager.disabeTipEvent?.Invoke();
        }
    } 
}
