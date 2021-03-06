﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseWatcher : SingletonMonobehaviour<MouseWatcher>
{
    bool isToolTipWatchActive;
    bool isToolTipActivationValid;
    ToolTip activeTooltip;
    public Transform currentHoverObject
    {
        get
        {
            if (activeTooltip == null) return null;
            return activeTooltip.transform;
        }
    }

    float toolTipWatchCtr;

    /// <summary>
    /// Flag used to check if there is
    /// a toolTip waiting for activation;
    /// </summary>
    bool toolTipWatchActive;

    bool toolTipCurrentlyVisible;
    public string CurrentObjectDescription
    {
        get
        {
            if (toolTipCurrentlyVisible)
            {
                return activeTooltip.description;
            }
            else
            {
                return "";
            }
        }
    }

    private Vector2 lastPosition;
    private float timeToStatic = .5f;
    private float secondsIdle = 0f;
    private float secondsToIdle = 0f;
    private bool isStatic;

    private const float MINBUFFER = 2f;

    private Ray ray;
    private RaycastHit rayCastHit;

    DefaultToolTipObject defaultToolTip;
    public ToolTipObject DefaultToolTip
    {
        get
        {
            if (defaultToolTip==null)
            {
                defaultToolTip = FindObjectOfType<DefaultToolTipObject>();
                if (defaultToolTip == null)
                {
                    GameObject obj = Instantiate(Resources.Load("DefaultToolTip")) as GameObject;
                    defaultToolTip = obj.GetComponent<DefaultToolTipObject>();
                } else
                {
                    defaultToolTip.gameObject.SetActive(false);
                }
            }
            return defaultToolTip as ToolTipObject;
        }
    }

    Vector2 lastMousePosition;
	// Use this for initialization
	void Start () {
        isToolTipWatchActive = false;
        lastPosition = Input.mousePosition;
	}


    // Update is called once per frame
    void Update() {
        if ((lastPosition.x - Input.mousePosition.x < MINBUFFER && lastPosition.x - Input.mousePosition.x > -MINBUFFER) &&
            (lastPosition.y - Input.mousePosition.y < MINBUFFER && lastPosition.y - Input.mousePosition.y > -MINBUFFER))
        {
            if (!isStatic)
            {
                if(secondsToIdle < timeToStatic)
                {
                    secondsToIdle += Time.deltaTime;
                }
                else
                {
                    isStatic = true;
                    secondsToIdle = 0f;
                    if (toolTipWatchActive == true)
                    {
                        ActivateToolTip();
                    }
                }
            }
        }
        /*
        else // Mouse has moved or is moving
        {
            if (isStatic)
            {
                isStatic = !isStatic;
                if (toolTipCurrentlyVisible)
                {
                    DeactivateToolTip();
                }
            }
        }
        */
        lastPosition = Input.mousePosition;
    }

    public void SetActiveTooltip(ToolTip obj)
    {
        if (obj != activeTooltip)
        {
            activeTooltip = obj;
            toolTipWatchActive = true;
            secondsToIdle = 0f;
        }
    }
    public void RemoveActiveTooltipReg(ToolTip obj)
    {
        if (activeTooltip == obj)
        {
            DeactivateToolTip();
            isStatic = !isStatic;
            activeTooltip = null;
            toolTipWatchActive = false;
        }
    }
    
    private void ActivateToolTip()
    {
        activeTooltip.SetToolTipTrue(Input.mousePosition);
        defaultToolTip.SetText(activeTooltip.description);
        toolTipCurrentlyVisible = true;
    }
    private void DeactivateToolTip()
    {
        defaultToolTip.SetText("");
        activeTooltip.SetToolTipFalse();
        toolTipCurrentlyVisible = false;
    }
}
