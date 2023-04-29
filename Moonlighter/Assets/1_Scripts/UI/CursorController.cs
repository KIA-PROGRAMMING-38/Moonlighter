using System.Collections;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Player PlayerRef;

    public ItemSlot[][] InventorySlot;
    public ItemSlot PotionQuickSlot;
    public QuickSlot QuickSlot;

    public ItemData EmptyItemData;

    public Sprite EmptySprite;

    public UIInputHandler UIInputHandler { get; private set; }

    public ItemSlot PickedItemSlot;

    public int XPos { get; private set; }
    public int YPos { get; private set; }

    public bool IsPicked { get; private set; }

    public ItemSlot[] NonStatusSlot;

    public ItemSlot[] FirstLineSlotPos;
    public ItemSlot[] SecondLineSlotPos;
    public ItemSlot[] ThirdLineSlotPos;
    public ItemSlot[] FourthLineSlotPos;

    IEnumerator _goToQuickSlot;

    private void Awake()
    {
        InventorySlot = new ItemSlot[4][];
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
        InventoryPresenter.OnGoToQuickSlot -= RegisterOnStatusWindow;
        InventoryPresenter.OnGoToQuickSlot += RegisterOnStatusWindow;
        InventoryPresenter.OnUseQuickSlot -= UseQuickSlot;
        InventoryPresenter.OnUseQuickSlot += UseQuickSlot;

        SetDefaultPosition();
    }

    private void UseQuickSlot()
    {
        if(QuickSlot.gameObject.activeSelf)
        {
            PlayerRef.UsePotion(50);
            --QuickSlot.Count;
            --PotionQuickSlot.Count;
            QuickSlot.PotionCount.text = QuickSlot.Count.ToString();
            PotionQuickSlot.CountText.text = PotionQuickSlot.Count.ToString();
            if(QuickSlot.Count <= 0)
            {
                UnRegistPotionOnQuickSlot();
                PotionQuickSlot.ItemData = EmptyItemData;
                PotionQuickSlot.ItemImage.sprite = EmptySprite;
                PotionQuickSlot.CountText.text = string.Empty;
            }

        }
    }

    private void RegistPotionOnQuickSlot(ItemSlot item)
    {
        QuickSlot.gameObject.SetActive(true);
        QuickSlot.PotionImage.sprite = item.ItemImage.sprite;
        QuickSlot.Count = item.Count;
        QuickSlot.PotionCount.text = item.CountText.text;
    }

    private void UnRegistPotionOnQuickSlot()
    {
        QuickSlot.PotionImage.sprite = EmptySprite;
        QuickSlot.PotionCount.text = string.Empty;
        QuickSlot.gameObject.SetActive(false);
    }

    private void RegisterOnStatusWindow()
    {
        if (InventorySlot[YPos][XPos] != PotionQuickSlot && InventorySlot[YPos][XPos].ItemData != null && InventorySlot[YPos][XPos].ItemData.ItemType == EnumValue.ItemType.Potion)
        {
            _goToQuickSlot = GoToQuickSlot(InventorySlot[YPos][XPos], PotionQuickSlot, PotionQuickSlot.transform.position, 3000f);
            RegistPotionOnQuickSlot(InventorySlot[YPos][XPos]);
            StartCoroutine(_goToQuickSlot);
        }

        if (InventorySlot[YPos][XPos] == PotionQuickSlot)
        {
            bool isFindEmpty = false;
            for (int i = 0; i < NonStatusSlot.Length; ++i)
            {
                if (false == isFindEmpty && NonStatusSlot[i].ItemData == null)
                {
                    isFindEmpty = true;
                    _goToQuickSlot = GoToQuickSlot(InventorySlot[YPos][XPos], NonStatusSlot[i], NonStatusSlot[i].transform.position, 3000f);
                    UnRegistPotionOnQuickSlot();
                    StartCoroutine(_goToQuickSlot);
                }
            }
        }
    }

    IEnumerator GoToQuickSlot(ItemSlot item, ItemSlot dst, Vector3 targetPos, float speed)
    {
        float startTime = Time.unscaledTime;
        Vector3 returnPos = item.transform.position;
        Vector3 _startPos = item.transform.position;

        // 이동할 거리와 중심점을 계산
        Vector3 _midPos = new Vector3((_startPos.x + targetPos.x) / 2f, Mathf.Max(_startPos.y, targetPos.y) + 400f, 0);
        float distance = Vector3.Distance(_startPos, targetPos);

        while (Mathf.Abs(item.ItemImage.transform.position.x - targetPos.x) > 0.1f)
        {
            // 포물선 곡선 계산
            float timeFraction = (Time.unscaledTime - startTime) / (distance / speed);
            item.ItemImage.transform.position = Bezier.Second(_startPos, _midPos, targetPos, timeFraction);

            yield return null;
        }
        ItemSlot.SwapItemSlot(item, dst);
        item.ItemImage.transform.position = returnPos;
        StopCoroutine(_goToQuickSlot);
    }

    public void SetDefaultPosition()
    {
        XPos = 0;
        YPos = 0;
        PickedItemSlot.gameObject.SetActive(false);
        transform.SetParent(InventorySlot[YPos][XPos].transform);
        transform.position = transform.parent.position;
    }

    public void MoveCursor()
    {
        if(UIInputHandler.CursorInput.x != 0 && UIInputHandler.CursorInput.y > 0)
        {
            if((YPos == 0 || YPos == 2) && XPos == 6)
            {
                XPos = 5;
            }

            --YPos;

            if(YPos < 0)
            {
                YPos = 3;
            }
        }
        else if(UIInputHandler.CursorInput.x != 0 && UIInputHandler.CursorInput.y < 0)
        {
            if((YPos == 0 || YPos == 2) && XPos == 6)
            {
                XPos = 5;
            }

            ++YPos;

            if(YPos > 3)
            {
                YPos = 0;
            }

        }
        else if(UIInputHandler.CursorInput.x == 0 && UIInputHandler.CursorInput.y == 1)
        {
            if ((YPos == 0 || YPos == 2) && XPos == 6)
            {
                XPos = 5;
            }

            --YPos;

            if(YPos < 0)
            {
                YPos = 3;
            }
        }
        else if(UIInputHandler.CursorInput.x == 0 && UIInputHandler.CursorInput.y == -1)
        {
            if ((YPos == 0 || YPos == 2) && XPos == 6)
            {
                XPos = 5;
            }

            ++YPos;

            if(YPos > 3)
            {
                YPos = 0;
            }
        }
        else if(UIInputHandler.CursorInput.x == -1 && UIInputHandler.CursorInput.y == 0)
        {
            --XPos;
            if(XPos < 0)
            {
                if(YPos == 0 || YPos == 2)
                {
                    XPos = 6;
                }
                else
                {
                    XPos = 5;
                }
            }
        }
        else if(UIInputHandler.CursorInput.x == 1 && UIInputHandler.CursorInput.y == 0)
        {
            ++XPos;
            if(YPos == 0 || YPos == 2)
            {
                if(XPos > 6)
                {
                    XPos = 0;
                }
            }
            else
            {
                if(XPos > 5)
                {
                    XPos = 0;
                }
            }
        }
        transform.SetParent(InventorySlot[YPos][XPos].transform);
        transform.position = transform.parent.position;
    }
}
