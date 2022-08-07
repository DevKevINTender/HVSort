using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ControlersData;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static SessionCore;

public class BoxCom : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public BoxAnim boxAnim;
    [SerializeField] public FullCom fullComAnim;
    [SerializeField] private GameObject fullState;
    [SerializeField] private GameObject partState;
    [SerializeField] private List<SpriteRenderer> coloredFullSprites = new List<SpriteRenderer>();
    public List<PartCom> list = new List<PartCom>();
    public int maxPart = 4;
    public int boxId;
    public int boxRow;
    
    private bool isCompose = false;
    private BoxDel boxChoosed;
   
    public void InitComponent(BoxDel boxChoosed , int boxId, int boxRow)
    {
        this.boxChoosed = boxChoosed;
        this.boxId = boxId;
        this.boxRow = boxRow;

    }

    public bool CheckComposeState()
    {
        if (list.Count != maxPart)
        {
            isCompose = false;
        }
        else
        {
            isCompose = true;
            foreach (var item in list)
            {
                if (item.partColor != list[0].partColor) isCompose = false;
            }
        }

        if (isCompose)
        {
            ComposeBox();
        }
        else
        {
            DeComposeBox();
        }

        return isCompose;
    }
    public void ComposeBox()
    {
        fullState.SetActive(true);
        partState.SetActive(false);
        ColoredFull();
        fullComAnim.SetSkin();
        fullComAnim.SetAnimation();
        isCompose = true;
    }

    public void DeComposeBox()
    {
        fullState.SetActive(false);
        partState.SetActive(true);
        DiscoloredFull();
        isCompose = false;
    }

    public void ColoredFull()
    {
        Color32 boxColor = PartColorPacksCnt.GetCurrentLevelPack()[list[0].partColor];
        foreach (var item in coloredFullSprites)
        {
            item.color = boxColor;
        }
    }
    public void DiscoloredFull()
    {
        foreach (var item in coloredFullSprites)
        {
            item.color = Color.white;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isCompose)
        {
            boxChoosed?.Invoke(this);
        }
    }

    public bool isFreeSlot()
    {
        return (list.Count < maxPart) ? true : false;
    }

    public PartCom GetFirstPart()
    {
       PartCom lastPart = null;
       if (list.Count > 0) lastPart = list[list.Count-1];
       return lastPart;
    }

    public void AddNewPart(PartCom partCom)
    {
       list.Add(partCom);
       partCom.MoveToNewPosition(this, list.Count-1);
       partCom.transform.SetParent(partState.transform);
    }

    public void RemoveOldPart(PartCom partCom)
    {
       int index = 0;
       list.Remove(partCom);
       partCom.transform.parent = null;
    }

    public void BoxChoosen()
    {
       boxAnim.BoxUp(BoxMoveCompleted);
       
    }
    
    public void BoxBack()
    {
       boxAnim.BoxDown(BoxMoveCompleted);
    }
    
    public void BoxMoveCompleted()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].MoveToCurrentSlot(this,i);
        }
    }
}
