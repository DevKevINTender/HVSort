using System;
using DG.Tweening;
using UnityEngine;

namespace Animation_DOTween
{
    public class PulsAnim : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float interval = 0.5f;
        private Sequence mySequence;

        private void Start()
        {
            mySequence.Kill();
            mySequence = DOTween.Sequence();
            mySequence
                .AppendInterval(interval)
                .Append(transform.DOScale(new Vector3(1.1f,1.1f,1.1f), duration ))
                .SetLoops(-1, LoopType.Yoyo);
            ;
        }
        public void OnDestroy()
        {
            mySequence.Kill();
        }
    }
}