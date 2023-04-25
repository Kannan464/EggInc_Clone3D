using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHandler : MonoBehaviour
{
    public abstract void OpenMe();
    public abstract void CloseMe();
    public abstract void BackMe();
}