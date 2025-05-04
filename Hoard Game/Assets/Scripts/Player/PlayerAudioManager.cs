using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioSource;
    private List<GameObject> _currentAudioSources = new List<GameObject>();

    public void PlaySound(AudioClip clip, GameObject location)
    {
        Instantiate(_audioSource, location.transform);
        _audioSource.GetComponent<AudioSource>().PlayOneShot(clip);
        _currentAudioSources.Add(_audioSource);
    }

    public void StopAllSounds()
    {
        for (int soundObject = 0; soundObject < _currentAudioSources.Count; soundObject++)
        {
            if (_currentAudioSources[soundObject] != null)
            {
                Destroy(_currentAudioSources[soundObject]);
            }

            _currentAudioSources.RemoveAt(soundObject);
        }
    }
}
