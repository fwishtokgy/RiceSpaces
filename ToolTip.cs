using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Image mainImage;
    bool isActive;
    bool isVanilla;
    
    public ToolTipObject ToolTipObject;
    public string description;

	// Use this for initialization
	void Start () {
        mainImage = GetComponent<Image>();
        isVanilla = (ToolTipObject == null);
        if (isVanilla)
        {
            // use default tooltip
            // and set the text to 'Description'
            ToolTipObject = MouseWatcher.Instance.DefaultToolTip;
        }
        isActive = false;
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (ToolTipObject==null && !isActive)
        {
            MouseWatcher.Instance.SetActiveTooltip(this);
            Debug.Log("ToolTip Registrated");
        }
    }
    public void SetToolTipTrue(Vector2 positionInfo)
    {
        if (isVanilla)
        {
            (ToolTipObject as DefaultToolTipObject).SetText(description);
        }
        ToolTipObject.Enable(positionInfo);
        isActive = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if(ToolTipObject == null && isActive)
        {
            MouseWatcher.Instance.RemoveActiveTooltipReg(this);
            Debug.Log("ToolTip Deregistrated");
        }
    }
    public void SetToolTipFalse()
    {
        ToolTipObject.Disable();
        isActive = false;
    }
}
