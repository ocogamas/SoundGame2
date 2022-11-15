
using UnityEngine;

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

    public void PlayRandom4()
    {
        int randomValue = Random.Range(0, sounds4.Length);
        sounds4[randomValue].Play();
    }
}
