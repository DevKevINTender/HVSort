using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image backGround;
    private Sequence mySequence;
    
    public void OpenWinPanel()
    {
        mySequence.Kill();
        mySequence = DOTween.Sequence();
        mySequence.Append(backGround.DOColor(new Color32(36,36,36,200),1f ));
    }
    public void OnDestroy()
    {
        mySequence.Kill();
    }
}
