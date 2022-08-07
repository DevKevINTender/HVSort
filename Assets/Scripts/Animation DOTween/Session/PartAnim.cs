using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PartAnim : MonoBehaviour
{
    [SerializeField] private float step;
    
    private Sequence mySequence;

    public void Teleport(BoxCom newBox, int id)
    {
        int rand = Random.Range(0, 100);
        if (rand < 80)
        {
            TeleportUp(newBox, id);
        }

        if (rand >= 80 && rand < 95)
        {
            TeleportScale(newBox, id);
        }

        if (rand >= 95)
        {
            TeleportCross(newBox, id);
        }
    }
    public void TeleportUp(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX( newBox.transform.position.x, 0));
        mySequence.Append(transform.DOMoveY( newBox.transform.position.y + step * 4, 0));
        mySequence.AppendInterval(0.1f);
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, step * id, 0), 0.35f));
    }
    public void TeleportScale(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale( 0, 0.15f));
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, step * id, 0), 0.15f));
        mySequence.Append(transform.DOScale( 1, 0.15f));
    }
    public void TeleportCross(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, step * id, 0), 0.45f));
    }
    public void MoveToCurrentSlot(BoxCom newBox, int id)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(newBox.transform.position + new Vector3(0, step * id, 0),  0.1f));
    }

    public void RestartLevel(BoxCom newBox)
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.AppendInterval(0.1f);
        mySequence.Append(transform.DOMoveY( newBox.transform.position.y + step * 4, 0.35f));
    }
    
    public void OnDestroy()
    {
        mySequence.Kill();
    }
}
