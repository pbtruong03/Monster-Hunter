using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportPosition", menuName = "Data/TeleportPosition")]
public class _DataTeleportPosition : ScriptableObject
{
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    public float X
    {
        get { return x; }
        set { x = value; }
    }

    public float Y
    {
        get { return y; }
        set { y = value; }
    }

    public float Z
    {
        get { return z; }
        set { z = value; }
    }
}
