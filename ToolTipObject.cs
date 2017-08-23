using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipObject : MonoBehaviour {
    
    public bool AutoHides;
    Vector2 position;
    public Vector2 Position
    {
        get
        {
            position = new Vector2(this.transform.position.x, this.transform.position.y);
            return position;
        }
    }

    public virtual void Move(float x, float y)
    {
        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
    public void Move(Vector3 pos)
    {
        Move(pos.x, pos.y);
    }

    public virtual void Enable(Vector3 newPosition)
    {
        Move(newPosition.x, newPosition.y);//this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
        this.gameObject.SetActive(true);
        if (AutoHides) StartCoroutine("AutoHide");
    }

    public virtual void Disable()
    {
        if (AutoHides) StopCoroutine("AutoHide");
        this.gameObject.SetActive(false);
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(1.5f);
        Disable();
    }
}
