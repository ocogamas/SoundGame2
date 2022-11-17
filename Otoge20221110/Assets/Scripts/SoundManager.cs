
using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    [SerializeField] 
    private AudioSource[] sounds4;

    [SerializeField] 
    private AudioSource[] sounds5;

    [SerializeField] 
    private AudioSource[] sounds6;

    [SerializeField] 
    private AudioSource[] soundsDrum;

    private List<AudioSource> whiteSounds4;
    private List<AudioSource> whiteSounds5;
    private List<AudioSource> whiteSounds6;
    private List<AudioSource> blackSounds4;
    private List<AudioSource> blackSounds5;
    private List<AudioSource> blackSounds6;
    
    public void Initialize()
    {
        whiteSounds4 = new List<AudioSource>{sounds4[0], sounds4[2], sounds4[4], sounds4[5], sounds4[7], sounds4[9], sounds4[11]};
        whiteSounds5 = new List<AudioSource>{sounds5[0], sounds5[2], sounds5[4], sounds5[5], sounds5[7], sounds5[9], sounds5[11]};
        whiteSounds6 = new List<AudioSource>{sounds6[0], sounds6[2], sounds6[4], sounds6[5], sounds6[7], sounds6[9], sounds6[11]};
        blackSounds4 = new List<AudioSource>{sounds4[1], sounds4[3], sounds4[6], sounds4[8], sounds4[10]};
        blackSounds5 = new List<AudioSource>{sounds5[1], sounds5[3], sounds5[6], sounds5[8], sounds5[10]};
        blackSounds6 = new List<AudioSource>{sounds6[1], sounds6[3], sounds6[6], sounds6[8], sounds6[10]};
    }
    
    public void Play(SoundCube soundCube)
    {
        switch (soundCube.GetSoundType)
        {
            case SoundCube.SoundType.Drums:
                playRandomDrum();
                break;
            case SoundCube.SoundType.Four:
                playRandom4(soundCube.GetKeyType);
                break;
            case SoundCube.SoundType.Five:
                playRandom5(soundCube.GetKeyType);
                break;
            case SoundCube.SoundType.Six:
                playRandom6(soundCube.GetKeyType);
                break;
        }
    }

    private void playRandomDrum()
    {
        int randomValue = Random.Range(0, soundsDrum.Length);
        soundsDrum[randomValue].Play();
    }
    
    private void playRandom4(SoundCube.KeyType keyType)
    {
        int randomValue;
        switch (keyType)
        {
            case SoundCube.KeyType.All:
                randomValue = Random.Range(0, sounds4.Length);
                sounds4[randomValue].Play();
                break;
            
            case SoundCube.KeyType.Black:
                randomValue = Random.Range(0, blackSounds4.Count);
                blackSounds4[randomValue].Play();
                break;
            
            case SoundCube.KeyType.White:
                randomValue = Random.Range(0, whiteSounds4.Count); 
                whiteSounds4[randomValue].Play();
                break;
        }
    }
    
    private void playRandom5(SoundCube.KeyType keyType)
    {
        int randomValue;
        switch (keyType)
        {
            case SoundCube.KeyType.All:
                randomValue = Random.Range(0, sounds5.Length);
                sounds5[randomValue].Play();
                break;
            
            case SoundCube.KeyType.Black:
                randomValue = Random.Range(0, blackSounds5.Count);
                blackSounds5[randomValue].Play();
                break;
            
            case SoundCube.KeyType.White:
                randomValue = Random.Range(0, whiteSounds5.Count); 
                whiteSounds5[randomValue].Play();
                break;
        }
    }
    
    private void playRandom6(SoundCube.KeyType keyType)
    {
        int randomValue;
        switch (keyType)
        {
            case SoundCube.KeyType.All:
                randomValue = Random.Range(0, sounds6.Length);
                sounds6[randomValue].Play();
                break;
            
            case SoundCube.KeyType.Black:
                randomValue = Random.Range(0, blackSounds6.Count);
                blackSounds6[randomValue].Play();
                break;
            
            case SoundCube.KeyType.White:
                randomValue = Random.Range(0, whiteSounds6.Count); 
                whiteSounds6[randomValue].Play();
                break;
        }
    }
}
