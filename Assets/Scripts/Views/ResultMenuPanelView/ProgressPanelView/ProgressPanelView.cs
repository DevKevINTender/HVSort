using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.ProgressSO.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPanelView : MonoBehaviour
{
    [SerializeField] private Image buttonStatus;
    [SerializeField] private Image imageStatus;

    [SerializeField] private Sprite hasRewardImage;
    [SerializeField] private Sprite hasntRewardImage;

    [SerializeField] private Sprite hasRewardButton;
    [SerializeField] private Sprite hasntRewardButton;

    public Text nextLevelText;
    public Text nextLevelReward;

    private ProgressScrObj currentProgressScrObj;
    
    public void InitView()
    {
        currentProgressScrObj = ProgressCnt.GetCurrentProgress();
        if (currentProgressScrObj != null)
        {
            nextLevelText.text = currentProgressScrObj.needLevel + " Ур.";
            nextLevelReward.text = currentProgressScrObj.reward +"";

            if (currentProgressScrObj.isCompleted)
            {
                imageStatus.sprite = hasRewardImage;
                buttonStatus.sprite = hasRewardButton;
            }
            else
            {
                imageStatus.sprite = hasntRewardImage;
                buttonStatus.sprite = hasntRewardButton;
            }
        }
        else
        {
            imageStatus.sprite = hasRewardImage;
            buttonStatus.gameObject.SetActive(false);
            nextLevelText.text = "Макс.";
        }
    }
    public void UpdateView()
    {
        InitView();
    }

    public void GetRewrd()
    {
        ProgressCnt.GetProgressReward(currentProgressScrObj.id);
        UpdateView();
    }
}
