
using System;
using UnityEngine;

public class SoundCube : MonoBehaviour
{
    private Action<SoundCube> onTouchedSoundCube;
    public void Initialize(Action<SoundCube> onTouchedSoundCube)
    {
        this.onTouchedSoundCube = onTouchedSoundCube;
    }

    /// <summary>
    /// touch down from EventHandler
    /// </summary>
    public void OnTouchDown()
    {
        onTouchedSoundCube?.Invoke(this);
    }

    public void OnClick()
    {
        Debug.Log($"click");
    }
}
