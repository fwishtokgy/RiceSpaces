using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultToolTipObject : ToolTipObject {
    public Text text;
    public void SetText(string information)
    {
        text.text = information;
    }
}
