using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    public GameObject tip;

    public void Start()
    {
        tip.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        tip.SetActive(true);


    }
    private void OnTriggerExit(Collider collision)
    {
        
        tip.SetActive(false);

    }
}
