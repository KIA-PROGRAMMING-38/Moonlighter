using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Boss BossRef;

    private MonsterPresenter _monsterPresenter;

    public Image BossHealthBarOutLine;

    public Image BossHealthBarImage;

    private float _currentHealthRatio;
    private float _decreaseHealthTime = 0.5f;

    private void Start()
    {
        _monsterPresenter = BossRef.GetComponent<Monster>().MonsterPresenter;
        _monsterPresenter.OnChangedMonsterHPRatio -= UpdateHealthBar;
        _monsterPresenter.OnChangedMonsterHPRatio += UpdateHealthBar;
    }

    private void OnEnable()
    {
        BossHealthBarImage.fillAmount = 1f;
        _currentHealthRatio = 1f;
    }

    IEnumerator HealthBarChangeCoroutine()
    {
        while (true)
        {
            float t = 0f;
            float startRatio = _currentHealthRatio;
            float progressFillAmount = BossHealthBarImage.fillAmount;
            BossHealthBarImage.fillAmount = _currentHealthRatio;

            while (t < _decreaseHealthTime)
            {
                if (startRatio != _currentHealthRatio)
                {
                    t = 0f;
                    startRatio = _currentHealthRatio;
                    BossHealthBarImage.fillAmount = _currentHealthRatio;
                    progressFillAmount = BossHealthBarImage.fillAmount;
                }

                t += Time.deltaTime;
                BossHealthBarImage.fillAmount = Mathf.Lerp(progressFillAmount, _currentHealthRatio, t / _decreaseHealthTime);
                yield return null;
            }
            
            yield return null;
        }
    }

    public void UpdateHealthBar(int max, int cur)
    {
        _currentHealthRatio = Mathf.Clamp01(cur / (float)max);
        BossHealthBarImage.fillAmount = _currentHealthRatio;
    }
}
