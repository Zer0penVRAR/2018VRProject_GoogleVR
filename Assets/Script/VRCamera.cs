using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCamera : MonoBehaviour {

    #region Variables

    public Text TimeText;

    public float BreakTime = 3f;

    private float eventTime = 0;
    private bool eventOn = false;

    private GameObject EventObj;

    #endregion

    #region Components

    private Transform tr;
    private Ray ray;
    private RaycastHit hit;

    #endregion

    #region LifeCycle Methods

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        ray = new Ray(tr.position, tr.forward * 100f);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.CompareTag("BreakAble"))
            {
                //부서지게
                eventOn = true;
                EventObj = hit.collider.gameObject;
            }
            else if(hit.collider.CompareTag("VRButton"))
            {
                eventOn = true;
                EventObj = hit.collider.gameObject;
            }
            else
            {
                eventOn = false;
                EventObj = null;
                eventTime = 0;
            }
        }
        else
        {
            eventOn = false;
            EventObj = null;
            eventTime = 0;
        }

        if(eventOn)
        {
            eventTime += Time.deltaTime;

            if(eventTime > BreakTime)
            {
                if (EventObj.CompareTag("BreakAble"))
                {
                    Destroy(EventObj);
                } else if(EventObj.CompareTag("VRButton"))
                {
                    EventObj.GetComponent<VRButton>().ButtonClicked();
                    EventObj = null;
                }
                eventOn = false;
                eventTime = 0;
            }
        }

        TimeText.text = ((int)eventTime).ToString();
    }

    #endregion

    #region Other Methods



    #endregion
}