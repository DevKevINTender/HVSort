using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ControlersData.PartColorPacksCnt;

namespace ScriptableObjects.LevelsSO
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "SrcObj/ new LevelSO", order = 0)]
    public class LevelScrObj : ScriptableObject
    {
        public int id;
        public int coloredBoxCount;
        public int freeBoxCount;
        public int reward;
        public int colorPackId;
        public List<Colum> list = new List<Colum>();
    }

    [Serializable]
    public class Colum
    {
        public List<PartColor> list = new List<PartColor>();
    }
}