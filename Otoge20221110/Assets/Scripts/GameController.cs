
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SoundCube soundCubeDrum;
    [SerializeField] private SoundCube whiteSoundCube4;
    [SerializeField] private SoundCube whiteSoundCube5;
    [SerializeField] private SoundCube whiteSoundCube6;

    [SerializeField] private SoundCube blackSoundCube4;
    [SerializeField] private SoundCube blackSoundCube5;
    [SerializeField] private SoundCube blackSoundCube6;

    [SerializeField] private SoundManager soundManager;
    
    void Start()
    {
        soundManager.Initialize();
        soundCubeDrum.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Drums, SoundCube.KeyType.All);
        whiteSoundCube4.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Four, SoundCube.KeyType.White);
        whiteSoundCube5.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Five, SoundCube.KeyType.White);
        whiteSoundCube6.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Six, SoundCube.KeyType.White);
        blackSoundCube4.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Four, SoundCube.KeyType.Black);
        blackSoundCube5.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Five, SoundCube.KeyType.Black);
        blackSoundCube6.Initialize(onTouchDownSoundCube, SoundCube.SoundType.Six, SoundCube.KeyType.Black);
    }

    private void onTouchDownSoundCube(SoundCube touchDownedSoundCube)
    {
        soundManager.Play(touchDownedSoundCube);
    }
}
