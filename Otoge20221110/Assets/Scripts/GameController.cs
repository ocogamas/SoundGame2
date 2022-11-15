
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SoundCube soundCube;

    [SerializeField] private SoundManager soundManager;
    
    void Start()
    {
        soundCube.Initialize(onTouchDownSoundCube);
    }

    private void onTouchDownSoundCube(SoundCube touchDownedSoundCube)
    {
        soundManager.PlayRandom4();
    }
}
