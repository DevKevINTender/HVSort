using ControlersData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.WinPanelView
{
    public class WinPanelView : MonoBehaviour
    {
        [SerializeField] private DailyPanelView dailyPanelView;
        [SerializeField] private ProgressPanelView progressPanelView;
        [SerializeField] private WinCompleteLevelPanelView winCompleteLevelPanelView;
        private GameObject currentPanel;
        [SerializeField] private Text currentPanelText;
        [SerializeField] private Image backGround;
        
        public void InitView()
        {
            OpenNextPanelView().SetActive(true);
            UpdateBackGround();
        }
        public void UpdateBackGround()
        {
            backGround.sprite = BackGroundCnt.GetCurrentBackGround().backGroundSession;
        }
        public GameObject OpenNextPanelView()
        {
            currentPanel = winCompleteLevelPanelView.gameObject;
            if (ProgressCnt.GetCurrentProgress() != null && ProgressCnt.GetCurrentProgress().isCompleted)
            {
                currentPanel = progressPanelView.gameObject;
                progressPanelView.InitView();
                currentPanelText.text = "Прогресс";
                return currentPanel;
            }
            if (DailyCnt.GetTotalDailyReward() > 0)
            {
                currentPanel = dailyPanelView.gameObject;
                dailyPanelView.InitView();
                currentPanelText.text = "Ежедневки";
                return currentPanel;
            }
            winCompleteLevelPanelView.InitView();
            currentPanelText.text = "Уровень пройден";
            return currentPanel;
        }
        
        public void CloseDailyPanelView()
        {
            DailyCnt.GetDailyReward();
            currentPanel.SetActive(false);
            OpenNextPanelView().SetActive(true);
        }

        public void CloseProgressPanelView()
        {
            if (ProgressCnt.GetCurrentProgress() != null)
            {
                ProgressCnt.GetProgressReward(ProgressCnt.GetCurrentProgress().id);
            }
            currentPanel.SetActive(false);
            OpenNextPanelView().SetActive(true);
        }

        public void CloseLevelCompletePanelView()
        {
            LevelsCnt.GetLevelReward();
            SceneManager.LoadScene("Session");
        }
    }
}