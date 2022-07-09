using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PartAnim : MonoBehaviour
{
    private Sequence mySequence;
    public void Teleport(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.AppendInterval(0.1f);
        mySequence.Append(transform.DOMoveX( newBox.transform.position.x, 0));
        mySequence.Append(transform.DOMoveY( newBox.transform.position.y + 4, 0));
        mySequence.AppendInterval(0.1f);
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, id, 0), 0.35f));

    }

    public void MoveToCurrentSlot(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, id, 0), 0.35f));
    }
}
