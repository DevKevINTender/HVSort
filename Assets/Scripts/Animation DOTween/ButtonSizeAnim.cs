using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonSizeAnim : MonoBehaviour
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
}
