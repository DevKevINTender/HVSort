using UnityEngine;
using UnityEngine.UI;

namespace Views.WinPanelView
{
    public class WinCompleteLevelPanelView : MonoBehaviour
    {
        [SerializeField] public Text levelReward;
        
        public void InitView()
        {
            levelReward.text = LevelsCnt.GetCurrentLevel().reward.ToString();
        }
       
    }
}