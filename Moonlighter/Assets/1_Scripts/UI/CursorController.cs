using System;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public RectTransform[][] InventorySlot;

    public UIInputHandler UIInputHandler { get; private set; }

    private int _xPos;
    private int _yPos;

    [SerializeField]
    public RectTransform[] FirstLineSlotPos;
    public RectTransform[] SecondLineSlotPos;
    public RectTransform[] ThirdLineSlotPos;
    public RectTransform[] FourthLineSlotPos;

    public GridLayoutGroup PlayerBelonging;
    public GridLayoutGroup InBag;

    private void Awake()
    {
        InventorySlot = new RectTransform[4][];
        InventorySlot[0] = FirstLineSlotPos;
        InventorySlot[1] = SecondLineSlotPos;
        InventorySlot[2] = ThirdLineSlotPos;
        InventorySlot[3] = FourthLineSlotPos;

        UIInputHandler = transform.root.GetComponent<UIInputHandler>();

    }

    private void OnEnable()
    {
        InventoryPresenter.OnMoveCursor -= MoveCursor;
        InventoryPresenter.OnMoveCursor += MoveCursor;
        SetDefaultPosition();
    }

    public void SetDefaultPosition()
    {
        _xPos = 0;
        _yPos = 0;
        transform.SetParent(InventorySlot[_yPos][_xPos]);
        transform.position = transform.parent.position;
    }

    public void MoveCursor()
    {
        if(UIInputHandler.CursorInput.x != 0 && UIInputHandler.CursorInput.y > 0)
        {
            if((_yPos == 0 || _yPos == 2) && _xPos == 6)
            {
                _xPos = 5;
            }

            --_yPos;

            if(_yPos < 0)
            {
                _yPos = 3;
            }
        }
        else if(UIInputHandler.CursorInput.x != 0 && UIInputHandler.CursorInput.y < 0)
        {
            if((_yPos == 0 || _yPos == 2) && _xPos == 6)
            {
                _xPos = 5;
            }

            ++_yPos;

            if(_yPos > 3)
            {
                _yPos = 0;
            }

        }
        else if(UIInputHandler.CursorInput.x == 0 && UIInputHandler.CursorInput.y == 1)
        {
            if ((_yPos == 0 || _yPos == 2) && _xPos == 6)
            {
                _xPos = 5;
            }

            --_yPos;

            if(_yPos < 0)
            {
                _yPos = 3;
            }
        }
        else if(UIInputHandler.CursorInput.x == 0 && UIInputHandler.CursorInput.y == -1)
        {
            if ((_yPos == 0 || _yPos == 2) && _xPos == 6)
            {
                _xPos = 5;
            }

            ++_yPos;

            if(_yPos > 3)
            {
                _yPos = 0;
            }
        }
        else if(UIInputHandler.CursorInput.x == -1 && UIInputHandler.CursorInput.y == 0)
        {
            --_xPos;
            if(_xPos < 0)
            {
                if(_yPos == 0 || _yPos == 2)
                {
                    _xPos = 6;
                }
                else
                {
                    _xPos = 5;
                }
            }
        }
        else if(UIInputHandler.CursorInput.x == 1 && UIInputHandler.CursorInput.y == 0)
        {
            ++_xPos;
            if(_yPos == 0 || _yPos == 2)
            {
                if(_xPos > 6)
                {
                    _xPos = 0;
                }
            }
            else
            {
                if(_xPos > 5)
                {
                    _xPos = 0;
                }
            }
        }
        transform.SetParent(InventorySlot[_yPos][_xPos]);
        transform.position = transform.parent.position;
    }
}
