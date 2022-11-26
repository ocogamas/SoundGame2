
using UnityEngine;
using Random = UnityEngine.Random;

public class Utility 
{
    public static Color GetRandomColor()
    {
        Color color = new Color(
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            1.0f);
        
        return color;
    }
}
