using System;
using UnityEngine;

public class PlaySphere : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Animator tapAnimator;

    private Action<PlaySphere> onTouched;

    public void Initialize(Action<PlaySphere> onTouched)
    {
        this.onTouched = onTouched;

        material.color = Utility.GetRandomColor();
    }
    
    /// <summary>
    /// touch down from EventHandler
    /// </summary>
    public void OnTouchDown()
    {
        onTouched?.Invoke(this);
        material.color = Utility.GetRandomColor();
        tapAnimator.Play("Tap");
    }
}
