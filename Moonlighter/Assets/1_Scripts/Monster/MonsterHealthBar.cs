using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MonsterHealthBar : MonoBehaviour
{
    private Image _backgroundImage;
    private Image _instanceImage;
    private Image _baseImage;
    [SerializeField] private Transform _owner;

    private float _currentHealthRatio;
    private float _decreaseHealthTime = 1.0f;

    IEnumerator _OnHealthBarFadeCoroutine;

    private Vector3 _uiPos;

    private void Awake()
    {
        _backgroundImage = transform.GetChild(0).GetComponent<Image>();
        _instanceImage = transform.GetChild(1).GetComponent<Image>();
        _baseImage = transform.GetChild(2).GetComponent<Image>();
    }

    private void Start()
    {
        _baseImage.enabled = false;
        _instanceImage.enabled = false;
        _backgroundImage.enabled = false;
        _OnHealthBarFadeCoroutine = HealthBarChangeCoroutine();
        _uiPos = Vector3.up * 0.01f;
        _backgroundImage.fillAmount = 1f;
        _currentHealthRatio = 1f;
        _baseImage.fillAmount = _currentHealthRatio;
        FadeOutProgressBarImage();
    }

    private void Update()
    {
        transform.position = _owner.transform.position + _uiPos;
    }

    IEnumerator HealthBarChangeCoroutine()
    {
        while (true)
        {
            float t = 0f;
            float startRatio = _currentHealthRatio;
            float progressFillAmount = _instanceImage.fillAmount;
            _instanceImage.fillAmount = _currentHealthRatio;

            while (t - 0.1f < _decreaseHealthTime)
            {
                if (startRatio != _currentHealthRatio)
                {
                    t = 0f;
                    startRatio = _currentHealthRatio;
                    _instanceImage.fillAmount = _currentHealthRatio;
                    progressFillAmount = _instanceImage.fillAmount;
                }
                t += Time.deltaTime;
                _instanceImage.fillAmount = Mathf.Lerp(progressFillAmount, _currentHealthRatio, t / _decreaseHealthTime);
                yield return null;
            }
            FadeOutProgressBarImage();
            StopCoroutine(_OnHealthBarFadeCoroutine);
            yield return null;
        }
    }

    private void FadeOutProgressBarImage()
    {
        _baseImage.enabled = false;
        _instanceImage.enabled = false;
        _backgroundImage.enabled = false;
    }

    private void FadeInProgressBarImage()
    {
        _baseImage.enabled = true;
        _instanceImage.enabled = true;
        _backgroundImage.enabled = true;
    }

    private void OnEnable()
    {
        MonsterPresenter.OnChangedMonsterHPRatio -= UpdateHealthBar;
        MonsterPresenter.OnChangedMonsterHPRatio += UpdateHealthBar;
    }

    public void UpdateHealthBar(int max, int cur)
    {
        FadeInProgressBarImage();
        _currentHealthRatio = Mathf.Clamp01(cur / (float)max);
        _baseImage.fillAmount = _currentHealthRatio;
        StartCoroutine(_OnHealthBarFadeCoroutine);
    }

}