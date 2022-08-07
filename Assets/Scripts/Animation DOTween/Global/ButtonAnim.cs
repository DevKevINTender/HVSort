using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    private Sequence mySequence;
    
    public void Increase()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 0.25f ));
    }
    public void Decrease()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(Vector3.one, 0.5f ));
    }

    public void MoveLeftAndBack()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalMoveX(transform.localPosition.x - 50, 0.25f ));
        mySequence.Append(transform.DOLocalMoveX(transform.localPosition.x, 0.25f ));
    }
    
    public void MoveRightAndBack()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalMoveX(transform.localPosition.x + 50, 0.25f ));
        mySequence.Append(transform.DOLocalMoveX(transform.localPosition.x, 0.25f ));
    }

    public void Pulse()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.25f));
        mySequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
    }
    public void Push()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.25f));
        mySequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
    }
    
    public void OnDestroy()
    {
        mySequence.Kill();
    }
}
