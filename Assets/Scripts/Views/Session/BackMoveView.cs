using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BackMoveView : MonoBehaviour
    {
        public Text backMoveCountText;
        
        public void InitView(int backMoveCount)
        {
            backMoveCountText.text = backMoveCount + "";
        }

        public void UpdateView(int newbackMoveCount)
        {
            backMoveCountText.text = newbackMoveCount + "";
        }
    }
}