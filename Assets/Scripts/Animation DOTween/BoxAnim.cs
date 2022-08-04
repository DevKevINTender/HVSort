using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static SessionCore;

public class BoxAnim : MonoBehaviour
{
    private Vector2 startPos;
    private Sequence mySequence;
    public void Start()
    {
        startPos = transform.position;
    }

    public void BoxUp(BoxMoveCompleted completed)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(transform.position.y + 0.25f, 0.1f));
        mySequence.OnComplete(() => completed?.Invoke());
    }
    public void BoxDown(BoxMoveCompleted completed)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(transform.position.y - 0.25f, 0.1f));
        mySequence.OnComplete(() => completed?.Invoke());
    }
}
