
using UnityEngine;

public class GameController : MonoBehaviour
{
    private enum GameState
    {
        Idle,
        Playing
    }
    
    [SerializeField] private SoundCube soundCubeDrum;
    [SerializeField] private SoundCube whiteSoundCube4;
    [SerializeField] private SoundCube whiteSoundCube5;
    [SerializeField] private SoundCube whiteSoundCube6;

    [SerializeField] private SoundCube blackSoundCube4;
    [SerializeField] private SoundCube blackSoundCube5;
    [SerializeField] private SoundCube blackSoundCube6;

    [SerializeField] private PlaySphere playSphere;

    [SerializeField] private SoundManager soundManager;

    private GameState gameState;

    private float gameTimer;

    // 小節
    private int musicBar;

    // 0 - 192
    private float musicProgress;

    private int beforeMusicBar;
    private float beforeMusicProgress;

    private float bpm;
    
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

        playSphere.Initialize(onTouchDownPlaySphere);
    }

    void Update()
    {
        if (gameState == GameState.Playing)
        {
            updatePlaying();
        }
    }

    private void onTouchDownSoundCube(SoundCube touchDownedSoundCube)
    {
        soundManager.Play(touchDownedSoundCube);
    }

    private void onTouchDownPlaySphere(PlaySphere playSphere)
    {
        if (gameState == GameState.Idle)
        {
            gameState = GameState.Playing;
            bpm = 150;
            gameTimer = 0;
            beforeMusicBar = 0;
            beforeMusicProgress = 0;
            soundCubeDrum.OnTouchDown();
        }
        else if (gameState == GameState.Playing)
        {
            gameState = GameState.Idle;
        }
    }

    /// <summary>
    /// 再生モードの更新
    /// </summary>
    private void updatePlaying()
    {
        musicBar = calculateMusicBar();
        musicProgress = calculateMusicProgress();

        updatePlayingMusic();
        
        // 最後に時間を更新
        gameTimer += Time.deltaTime;
        beforeMusicBar = musicBar;
        beforeMusicProgress = musicProgress;
    }

    private int calculateMusicBar()
    {
        // BPM 150というのは4分音符が60秒に150回
        // 4分音符4回で１小節なので
        // 60秒に150/4 小節数 = 37.5小節
        // 60秒でBPM/4 小節あるということ。小数以下は切り捨てて良い。
        // 1秒：BPM/240小節 = gameTimer秒 : X小節
        // X = gameTimer * BPM / 240;
        return (int)(gameTimer * bpm / 240.0f);
    }

    private float calculateMusicProgress()
    {
        // １小節内の進み度合い（1小節を1.0とした時の百分率）
        float progressInBar = (gameTimer * bpm / 240.0f) - musicBar;
        return progressInBar * 192.0f;
    }


    private void updatePlayingMusic()
    {
        // 小節線を跨いだ時
        if (beforeMusicBar < musicBar)
        {
            soundCubeDrum.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 12 && musicProgress >= 12)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(50) && beforeMusicProgress < 24 && musicProgress >= 24)
        {
            whiteSoundCube4.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 36 && musicProgress >= 36)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(80) && beforeMusicProgress < 48 && musicProgress >= 48)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(20) && beforeMusicProgress < 60 && musicProgress >= 60)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(50) && beforeMusicProgress < 72 && musicProgress >= 72)
        {
            whiteSoundCube4.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 84 && musicProgress >= 84)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(80) && beforeMusicProgress < 96 && musicProgress >= 96)
        {
            whiteSoundCube5.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 108 && musicProgress >= 108)
        {
            whiteSoundCube4.OnTouchDown();
        }
        
        if (shouldPlayRandom(50) && beforeMusicProgress < 120 && musicProgress >= 120)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(20) && beforeMusicProgress < 132 && musicProgress >= 132)
        {
            whiteSoundCube4.OnTouchDown();
        }

        if (shouldPlayRandom(80) && beforeMusicProgress < 144 && musicProgress >= 144)
        {
            whiteSoundCube6.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 156 && musicProgress >= 156)
        {
            whiteSoundCube4.OnTouchDown();
        }

        
        if (shouldPlayRandom(50) && beforeMusicProgress < 168 && musicProgress >= 168)
        {
            whiteSoundCube4.OnTouchDown();
        }
        
        if (shouldPlayRandom(20) && beforeMusicProgress < 180 && musicProgress >= 180)
        {
            whiteSoundCube4.OnTouchDown();
        }
    }

    private bool shouldPlayRandom(int ratio)
    {
        return ratio > Random.Range(0, 100);
    }
}
