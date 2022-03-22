using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transmission", menuName = "GD2/Scriptable", order = 2)]
public class Transmission : ScriptableObject
{
    public delegate void targetIdDelegate(Vector3 p_pos);

    public event targetIdDelegate onTriggered;

    public void Raise(Vector3 p_pos)
    {
        onTriggered?.Invoke(p_pos);
    }
}