using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceFire;

    // Start is called before the first frame update
    void Start()
    {
    }

    void PlaySoundFire()
    {
        audioSourceFire.Play();
    }

    void StopSoundFire()
    {
        audioSourceFire.Stop();
    }
}