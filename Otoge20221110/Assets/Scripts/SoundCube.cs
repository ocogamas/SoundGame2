
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundCube : MonoBehaviour
{
    public enum SoundType
    {
        Four,
        Five,
        Six,
        Drums,
    }

    public enum KeyType
    {
        All,
        White,
        Black,
    }

    [SerializeField] private Material material;
    [SerializeField] private Animator tapAnimator;

    private Action<SoundCube> onTouchedSoundCube;
    private SoundType soundType;
    private KeyType keyType;

    
    private Vector3 rotateVector = new Vector3(0.001f, 0.008f, 0.04f);

    public SoundType GetSoundType => soundType;
    public KeyType GetKeyType => keyType;
    
    public void Initialize(Action<SoundCube> onTouchedSoundCube, SoundType soundType, KeyType keyType)
    {
        this.onTouchedSoundCube = onTouchedSoundCube;
        this.soundType = soundType;
        this.keyType = keyType;

        material.color = Utility.GetRandomColor();
    }

    public void Update()
    {
        transform.Rotate(rotateVector);
    }

    /// <summary>
    /// touch down from EventHandler
    /// </summary>
    public void OnTouchDown()
    {
        onTouchedSoundCube?.Invoke(this);
        material.color = Utility.GetRandomColor();

        rotateVector = new Vector3(Random.Range(0, 0.04f), Random.Range(0, 0.04f), Random.Range(0, 0.04f));

        tapAnimator.Play("Tap");
    }


}
