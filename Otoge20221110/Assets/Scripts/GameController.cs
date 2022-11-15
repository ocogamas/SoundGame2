using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private SoundCube soundCube;
    
    void Start()
    {
        soundCube.Initialize(onTouchDownSoundCube);
    }

    private void onTouchDownSoundCube(SoundCube touchDownedSoundCube)
    {
        
    }
}
