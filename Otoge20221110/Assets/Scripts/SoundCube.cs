
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

        material.color = getRandomColor();
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
        material.color = getRandomColor();

        rotateVector = new Vector3(Random.Range(0, 0.04f), Random.Range(0, 0.04f), Random.Range(0, 0.04f));
    }

    private Color getRandomColor()
    {
        Color color = new Color(
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            1.0f);
        
        return color;
    }
}
