using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour
{
    public Image PlayerHealthBar;
    public Text PlayerHealthText;

    private StringBuilder _healthTextBuilder;
    private float _currentHealthRatio = 1.0f;
    private float _decreaseHealthTime;
    private IEnumerator _healthChangeCoroutine;

    private void Awake()
    {
        _healthTextBuilder = new StringBuilder();
        _decreaseHealthTime = 1.0f;
        PlayerHealthBar.fillAmount = 1f;
        _healthChangeCoroutine = HealthChangeCoroutine();
    }

    private void OnEnable()
    {
        PlayerPresenter.OnChangedPlayerHPRatio -= UpdateHealthBar;
        PlayerPresenter.OnChangedPlayerHPRatio += UpdateHealthBar;
    }

    private void OnDisable()
    {
        PlayerPresenter.OnChangedPlayerHPRatio -= UpdateHealthBar;
    }

    private void UpdateHealthText(int maxHp, int curHp)
    {
        _healthTextBuilder.Clear();
        _healthTextBuilder.Append($"{maxHp}/{curHp}");
        PlayerHealthText.text = _healthTextBuilder.ToString();
    }

    public void UpdateHealthBar(int maxHp, int curHp)
    {
        _currentHealthRatio = Mathf.Clamp01(curHp / (float)maxHp);
        StartCoroutine(_healthChangeCoroutine);
        UpdateHealthText(curHp, maxHp);
    }

    IEnumerator HealthChangeCoroutine()
    {
        while (true)
        {
            float t = 0f;
            float startRatio = _currentHealthRatio;
            float progressFillAmount = PlayerHealthBar.fillAmount;
            PlayerHealthBar.fillAmount = _currentHealthRatio;

            while (t - 0.1f < _decreaseHealthTime)
            {
                if (startRatio != _currentHealthRatio)
                {
                    t = 0f;
                    startRatio = _currentHealthRatio;
                    PlayerHealthBar.fillAmount = _currentHealthRatio;
                    progressFillAmount = PlayerHealthBar.fillAmount;
                }
                t += Time.deltaTime;
                PlayerHealthBar.fillAmount = Mathf.Lerp(progressFillAmount, _currentHealthRatio, t / _decreaseHealthTime);
                yield return null;
            }
            StopCoroutine(_healthChangeCoroutine);
            yield return null;
        }
    }

}
