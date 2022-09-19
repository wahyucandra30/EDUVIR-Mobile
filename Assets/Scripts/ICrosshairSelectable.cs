using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrosshairSelectable
{
    
    public abstract void Hover();
    public abstract void Unhover();
    public abstract void Select();
}
