using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeskObject 
{
    public abstract void Scale(Vector3 targetScale,float timeScale);
    public abstract void Rotate();

}
