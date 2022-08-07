using UnityEngine;

public class AudioPlayer : SingletonMonoBehaviour<AudioPlayer>
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null)
            return;

        _audioSource.PlayOneShot(audioClip);
    }
}