using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class SizeAttribute : PropertyAttribute
{
    public Vector3 Size { get; private set; }

    public SizeAttribute(float x, float y, float z)
    {
        Size = new Vector3(x, y, z);
    }

    public SizeAttribute(float width, float height)
    {
        Size = new Vector3(width, height, 0);
    }
}
