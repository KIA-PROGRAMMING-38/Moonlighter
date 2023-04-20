using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraEffect : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    #region  CameraShake
    [Header("--- Camera Shake ---")]

    private IEnumerator _cameraShakeCoroutine;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    [SerializeField]
    private float _cameraShakeDuration;
    [SerializeField]
    private float _cameraShakeIntensity;
    #endregion

    private void Awake()
    {
        _cinemachineBasicMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cameraShakeCoroutine = ShakeScreenEffectCoroutine();
    }

    #region Screen Shake Method

    public void PlayScreenShake(float duration, float intensity)
    {
        _cameraShakeDuration = duration;
        _cameraShakeIntensity = intensity;
        StartCoroutine(_cameraShakeCoroutine);
    }

    public void PlayScreenShake()
    {
        _cameraShakeDuration = 0.1f;
        _cameraShakeIntensity = 2f;
        StartCoroutine(_cameraShakeCoroutine);
    }


    IEnumerator ShakeScreenEffectCoroutine()
    {
        while (true)
        {
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _cameraShakeIntensity;
            yield return TimeStore.GetWaitForSeconds(_cameraShakeDuration);
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            StopCoroutine(_cameraShakeCoroutine);
            yield return null;
        }
    }
    #endregion

}
