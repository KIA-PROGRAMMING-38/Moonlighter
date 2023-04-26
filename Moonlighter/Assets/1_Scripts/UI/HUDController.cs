using System.Collections;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private UIInputHandler _uiInputHandler;

    public RectTransform InventoryIcon;
    public RectTransform InventoryAndStatusWindow;

    private Vector3 _inventoryIconInPosition;
    private Vector3 _inventoryIconOutPosition;
    private Vector3 _inventoryAndStatusWindowInPosition;
    private Vector3 _inventoryAndStatusWindowOutPosition;

    private float _inventoryIconMoveDistance = 230f;
    private float _inventoryAndStatusWindowMoveDistance = 940f;
    private float _iconFadeTime = 0.4087f;
    private float _windowFadeTime = 0.1f;

    private bool _isFading;

    private IEnumerator _fadeInIcon;
    private IEnumerator _fadeOutIcon;
    private IEnumerator _fadeInWindow;
    private IEnumerator _fadeOutWindow;

    private void Awake()
    {
        _uiInputHandler = GetComponent<UIInputHandler>();

        _inventoryIconInPosition = InventoryIcon.position;
        _inventoryAndStatusWindowOutPosition = InventoryAndStatusWindow.position;
        _inventoryIconOutPosition = InventoryIcon.position + Vector3.right * _inventoryIconMoveDistance;
        _inventoryAndStatusWindowInPosition = InventoryAndStatusWindow.position 
            + Vector3.up * _inventoryAndStatusWindowMoveDistance;

        _fadeInIcon = FadeInIcon();
        _fadeOutIcon = FadeOutIcon();
        _fadeInWindow = FadeInWindow();
        _fadeOutWindow = FadeOutWindow();

    }

    private void Start()
    {
        HUDPresenter.OnInventoryWindow -= ActionInventoryKey;
        HUDPresenter.OnInventoryWindow += ActionInventoryKey;
    }

    private void ActionInventoryKey()
    {
        if(false == _isFading)
        {
            if (false == _uiInputHandler.OnInventoryWindow)
            {
                FadeOutIconFadeInWindow();
            }
            else
            {
                FadeInIconFadeOutWindow();
            }
        }

    }

    private void FadeOutIconFadeInWindow()
    {
        StopCoroutine(_fadeInIcon);
        StopCoroutine(_fadeOutWindow);
        StartCoroutine(_fadeOutIcon);
        StartCoroutine(_fadeInWindow);
    }

    private void FadeInIconFadeOutWindow()
    {
        StopCoroutine(_fadeOutIcon);
        StopCoroutine(_fadeInWindow);
        StartCoroutine(_fadeInIcon);
        StartCoroutine(_fadeOutWindow);
    }

    private IEnumerator FadeInIcon()
    {
        while(true)
        {
            float elapsedTime = 0f;
            _isFading = true;
            while (elapsedTime / _iconFadeTime < 1.0f)
            {
                elapsedTime += Time.deltaTime;
                InventoryIcon.position = Vector3.Lerp(InventoryIcon.position, _inventoryIconInPosition,
                    elapsedTime / _iconFadeTime);
                yield return null;
            }
            _isFading = false;
            StopCoroutine(_fadeInIcon);
            yield return null;
        }
    }

    private IEnumerator FadeOutIcon()
    {
        while (true)
        {
            float elapsedTime = 0f;
            _isFading = true;
            while (elapsedTime / _iconFadeTime < 1.0f)
            {
                elapsedTime += Time.deltaTime;
                InventoryIcon.position = Vector3.Lerp(InventoryIcon.position, _inventoryIconOutPosition,
                    elapsedTime / _iconFadeTime);
                yield return null;
            }
            _isFading = false;
            StopCoroutine(_fadeOutIcon);
            yield return null;
        }
    }

    private IEnumerator FadeInWindow()
    {
        while (true)
        {
            float elapsedTime = 0f;
            _isFading = true;
            while (elapsedTime / _windowFadeTime < 1.0f)
            {
                elapsedTime += Time.deltaTime;
                InventoryAndStatusWindow.position = Vector3.Lerp(InventoryAndStatusWindow.position, _inventoryAndStatusWindowInPosition, elapsedTime / _windowFadeTime);
                yield return null;
            }
            _isFading = false;
            StopCoroutine(_fadeInWindow);
            yield return null;
        }
    }

    private IEnumerator FadeOutWindow()
    {
        while (true)
        {
            float elapsedTime = 0f;
            _isFading = true;
            while (elapsedTime / _windowFadeTime < 1.0f)
            {
                elapsedTime += Time.deltaTime;
                InventoryAndStatusWindow.position = Vector3.Lerp(InventoryAndStatusWindow.position, _inventoryAndStatusWindowOutPosition, elapsedTime / _windowFadeTime);
                yield return null;
            }
            _isFading = false;
            StopCoroutine(_fadeOutWindow);
            yield return null;
        }
    }
}
