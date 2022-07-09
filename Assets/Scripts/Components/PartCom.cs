using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCom : MonoBehaviour
{
    [SerializeField] private SpriteRenderer partSprite;
    [SerializeField] private PartAnim partAnim;
    public int weight;
    public PartColor partColor;
    public int id;
    public void InitComponent(PartColor partColor, int id)
    {
        this.id = id;
        this.partColor = partColor;
        SetPartColor();
    }

    private void SetPartColor()
    {
        switch (this.partColor)
        {
            case PartColor.Red:
            {
                partSprite.color = Color.red;
                break;
            }
            case PartColor.Green:
            {
                partSprite.color = Color.green;
                break;
            }
            case PartColor.Yelow:
            {
                partSprite.color = Color.yellow;
                break;
            }
            case PartColor.Blue:
            {
                partSprite.color = Color.blue;
                break;
            } 
            case PartColor.Pink:
            {
                partSprite.color = Color.magenta;
                break;
            }
            case PartColor.Grey:
            {
                partSprite.color = Color.gray;
                break;
            }
            case PartColor.Cyan:
            {
                partSprite.color = Color.cyan;
                break;
            }
            
        }
    }

    public void MoveToNewPosition(BoxCom boxCom, int id)
    {
        partAnim.Teleport(boxCom, id);
    }

    public void MoveToCurrentSlot(BoxCom boxCom, int i)
    {
        partAnim.MoveToCurrentSlot(boxCom, i);
    }

    public enum PartColor
    {
        Red,
        Green,
        Yelow,
        Blue,
        Pink,
        Grey,
        Cyan
    }


}
