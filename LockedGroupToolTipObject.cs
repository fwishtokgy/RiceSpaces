using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGroupToolTipObject : ToolTipObject {

    public bool strictPositioning;
    // tto determined fade in fade out times?

    public bool LockX;
    public bool LockY;

    public Transform targetTransform;

	public override void Move(float x, float y)
    {
        //base.Move(LockX?x: targetTransform.position.x,LockY?y: targetTransform.position.y);
        targetTransform.position = new Vector3(LockX ? targetTransform.position.x : x, LockY ? targetTransform.position.y : y, targetTransform.position.z);
    }
    public override void Enable(Vector3 newPosition)
    {
        //MouseWatcher.Instance.CurrentObjectDescription;
        base.Enable(strictPositioning?MouseWatcher.Instance.currentHoverObject.position:newPosition);
    }

}
