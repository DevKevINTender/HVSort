using System;
using DG.Tweening;
using UnityEngine;

namespace Animation_DOTween.DailyPanel
{
    public class DailyInfoItemAnim : MonoBehaviour
    {
        private Sequence mySequence;
        
        public void PulseAndJump()
        {
            mySequence.Kill();
            mySequence = DOTween.Sequence();
            mySequence
                .Append(transform.DOLocalMoveY(transform.localPosition.y + 10f, 1f))
                .Join(transform.DOScale(1.25f, 1f))
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void StopAnim()
        {
            mySequence.Kill();
        }

        public void OnDestroy()
        {
            mySequence.Kill();
        }
    }
}