using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static SessionCore;

public class BoxCom : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BoxAnim boxAnim; 
    public List<PartCom> list = new List<PartCom>();
    public int maxPart = 4;
    public int boxId;

    private BoxDel boxChoosed;
   
    public void InitComponent(BoxDel boxChoosed , int boxId)
    {
        this.boxChoosed = boxChoosed;
        this.boxId = boxId;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        boxChoosed?.Invoke(this);
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
       partCom.transform.SetParent(this.transform);
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
