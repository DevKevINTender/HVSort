using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views;
using static SessionCore;

public class BackMoveCnt : MonoBehaviour
{
    public List<Move> moveList = new List<Move>();
    public BackMoveView backMoveView;
    private int backMoveCount;
    private BoxMoveCompleted boxMoveCompleted;
    public void InitContoler(BoxMoveCompleted boxMoveCompleted)
    {
        this.boxMoveCompleted = boxMoveCompleted;
        backMoveCount = PlayerPrefs.GetInt("BackMoveCount");

        backMoveView.InitView(backMoveCount);
    }

    public void AddToBackMoveCount()
    {
        backMoveCount++;
        PlayerPrefs.SetInt("BackMoveCount", backMoveCount);
        backMoveView.UpdateView(backMoveCount);
    }
    
    public void AddToBackMoveCount(int count)
    {
        backMoveCount += count;
        PlayerPrefs.SetInt("BackMoveCount", backMoveCount);
        backMoveView.UpdateView(backMoveCount);
    }

    public bool SubtractFromBackMoveCount()
    {
        if (backMoveCount > 0)
        {
            backMoveCount--;
            PlayerPrefs.SetInt("BackMoveCount", backMoveCount);
            backMoveView.UpdateView(backMoveCount);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
    public void AddMove(BoxCom fromBox, BoxCom toBox, PartCom movePart)
    {
        moveList.Add(new Move(fromBox,toBox,movePart));
    }

    public void UseBackMove()
    {
        if (moveList.Count > 0 && SubtractFromBackMoveCount())
        {
            Move lastMove = moveList.Last();
            lastMove.toBox.RemoveOldPart(lastMove.movedPart);
            lastMove.fromBox.AddNewPart(lastMove.movedPart);
            moveList.RemoveAt(moveList.Count-1);
            boxMoveCompleted?.Invoke();
        }
    }
}

public class Move
{
    public BoxCom fromBox;
    public BoxCom toBox;
    public PartCom movedPart;

    public Move(BoxCom fromBox, BoxCom toBox, PartCom movePart)
    {
        this.fromBox = fromBox;
        this.toBox = toBox;
        this.movedPart = movePart;
    }
}
