using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ScriptableObjects.LevelsSO
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "SrcObj/ new LevelSO", order = 0)]
    public class LevelScrObj : ScriptableObject
    {
        public int id;
        public int coloredBoxCount;
        public int freeBoxCount;
        public List<Colum> list = new List<Colum>();
    }

    [Serializable]
    public class Colum
    {
        public List<PartCom.PartColor> list = new List<PartCom.PartColor>();
    }
}