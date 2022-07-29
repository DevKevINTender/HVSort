using ControlersData;
using ScriptableObjects.BackGroundSO.SkriptsSO;
using ScriptableObjects.SkinsSO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Views.BackGroundPanelView;

namespace Views
{
    public class BackGroundItemView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Transform itemPos;
        [SerializeField] private Image statusItem;
        [SerializeField] private Sprite closedItem;
        [SerializeField] private Sprite selectedItem;
        [SerializeField] private Sprite openedSprite;

        [SerializeField] private Image itemImage;
        
        private BackGroundScrObj backGroundScrObj;

        public SelectBackGroundDel SelectBackGroundDel;
        public void InitView(BackGroundScrObj backGroundScrObj, SelectBackGroundDel  SelectSkinDel)
        {
            this.backGroundScrObj = backGroundScrObj;
            this.SelectBackGroundDel = SelectSkinDel;
        
            if (BackGroundCnt.BackGroundIsOpened(backGroundScrObj.id))
            {
                itemImage.sprite = backGroundScrObj.backGroundUI;
                statusItem.sprite = openedSprite;
                if (BackGroundCnt.GetCurrentBackGround().id == backGroundScrObj.id)
                {
                    statusItem.sprite = selectedItem;
                }
            }
            else
            {
                itemImage.color = new Color32(0, 0, 0, 0);
                statusItem.sprite = closedItem;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SelectBackGroundDel?.Invoke(backGroundScrObj);
        }
    }
}