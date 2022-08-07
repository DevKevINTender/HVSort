using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Animation_DOTween
{
    public class WinPanelResultAnim : MonoBehaviour
    {
        [SerializeField] private GameObject backGround;
        private Sequence mySequence;
    
        public void OpenResultPanel()
        {
            mySequence.Kill();
            backGround.transform.localScale = new Vector2(1,0);
            mySequence = DOTween.Sequence();
            mySequence.Append(backGround.transform.DOScale(new Vector2(1,1),0.5f));
        }
        public void OnDestroy()
        {
            mySequence.Kill();
        }
    }
}