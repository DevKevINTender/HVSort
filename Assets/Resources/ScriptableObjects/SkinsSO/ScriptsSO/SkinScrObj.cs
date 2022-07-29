using UnityEngine;

namespace ScriptableObjects.SkinsSO
{
    [CreateAssetMenu(fileName = "SkinSO", menuName = "SrcObj/ new SkinSO", order = 0)]
    public class SkinScrObj : ScriptableObject
    {
        public int id;
        public GameObject skinSession;
        public GameObject skinUI;

        public GameObject skinHeadPart;
    }
}