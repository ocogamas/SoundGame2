
using System;
using UnityEngine;

public class SoundCube : MonoBehaviour
{
    private System<SoundCube> onTouchedSoundCube;
    public void Initialize(Action<SoundCube> onTouchedSoundCube)
    {
        
    }

    /// <summary>
    /// touch down from EventHandler
    /// </summary>
    public void OnTouchDown()
    {
        Debug.Log($"touch down");
    }

    public void OnClick()
    {
        Debug.Log($"click");
    }
}
