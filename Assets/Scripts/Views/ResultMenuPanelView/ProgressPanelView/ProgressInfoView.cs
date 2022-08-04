using ControlersData;
using ScriptableObjects.ProgressSO.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

namespace Views.ResultMenuPanelView.ProgressPanelView
{
    public class ProgressInfoView : MonoBehaviour
    {
        [SerializeField] private Text needLevelText;
        [SerializeField] private Image progressStatusImage;
        public void InitView()
        {
            ProgressScrObj currentProgressScrObj = ProgressCnt.GetCurrentProgress();
            if (currentProgressScrObj != null)
            {
                needLevelText.text = currentProgressScrObj.needLevel + " Ур.";
                if (currentProgressScrObj.isCompleted)
                {
                    progressStatusImage.color = new Color32(250,188,3,255);
                }
            }
            else
            {
                needLevelText.text = "Макс.";
            }
           
        }
        public void UpdateView()
        {
            InitView();
        }
        public void Start()
        {
            ProgressCnt.ChangeProgressStatusEvent += UpdateView;
        }

        public void OnDestroy()
        {
            ProgressCnt.ChangeProgressStatusEvent -= UpdateView;
        }
    }
}