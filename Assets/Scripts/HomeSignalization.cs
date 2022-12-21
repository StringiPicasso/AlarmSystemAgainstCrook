using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HomeSignalization : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _duration;

    private Coroutine _activeCoroutine;

    private float _musicVolume;
    private float _timeVolume;
    private float _targetOff = 0;
    private float _targetOn = 1f;

    public void Start()
    {
        _source.volume = 0;
    }

    public void TurnOnAlarm()
    {
        _source.Play();
        Restart(_targetOn);
    }

    public void TurnOffAlarm()
    {
        Restart(_targetOff);

        if (_source.volume == 0)
        {
            _source.Stop();
        }
    }

    private void Restart(float target)
    {
        _timeVolume = 0;

        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeVolume(target));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_source.volume != target)
        {
            _musicVolume = (_timeVolume + Time.deltaTime) / _duration;
            _source.volume = Mathf.MoveTowards(_source.volume, target, _musicVolume);
            yield return null;
        }
    }
}
