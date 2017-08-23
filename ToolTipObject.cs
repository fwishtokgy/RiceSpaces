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

    public void Move(float x, float y)
    {
        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
    public void Move(Vector3 pos)
    {
        this.transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);
    }

    public void Enable(Vector3 newPosition)
    {
        this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
        StartCoroutine("WaitForWait");
    }

    IEnumerator WaitForWait()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(true);
        StartCoroutine("AutoHide");
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(1.5f);
        Disable();
    }
}
