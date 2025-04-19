using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTrigget : MonoBehaviour
{
    public GameObject tablet;
    public GameObject tip;
    public GameObject tip1;
    public GameObject tipClose;
    public GameObject Ax;
    public bool tBool;
    public bool eBool;
    public planks p;

    public void Start()
    {
        tablet.SetActive(false);
        tip.SetActive(false);
        tip1.SetActive(false);
        tipClose.SetActive(false);
        tBool = false;
        eBool = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        tip.SetActive(true);
        eBool = true;
    }
    void OnTriggerExit(Collider collision)
    {
        tip.SetActive(false);
        tip1.SetActive(false);
        tipClose.SetActive(false);
        eBool = false;
        tablet.SetActive(false);
        tBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && eBool == true)
        {
            if (tBool == false)
            {
                if (p.Axe)
                {
                    tablet.SetActive(true);
                    tBool = true;
                    tip.SetActive(false);
                    tipClose.SetActive(true);
                }
                else
                {
                    tablet.SetActive(true);
                    tBool = true;
                    tip.SetActive(false);
                    tip1.SetActive(true);
                }
                
            }
            else
            {
                tip.SetActive(true);
                tip1.SetActive(false);
                tipClose.SetActive(false);
                tablet.SetActive(false);
                tBool = false;
                p.Axe = true;
                Destroy(Ax);
            }

        }

    }
}
