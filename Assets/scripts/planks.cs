using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planks : MonoBehaviour
{
    public bool Axe;
    public GameObject tip;
    public GameObject tipNo;
    public GameObject ppp;
    public bool eBool;

    void Start()
    {
        Axe = false;
        eBool = false;
        tip.SetActive(false);
        tipNo.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        tip.SetActive(true);
        eBool = true;
    }
    void OnTriggerExit(Collider collision)
    {
        tip.SetActive(false);
        tipNo.SetActive(false);
        eBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && eBool == true)
        {
            if (Axe == false)
            {
                tip.SetActive(false);
                tipNo.SetActive(true);
            }
            else
            {
                    tip.SetActive(false);
                    Destroy(ppp);
                
            }

        }

    }
}

