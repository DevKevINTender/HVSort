using UnityEngine;

namespace ControlersData
{
    public class CoinsCnt
    {
        public delegate void AccountHandler();
        public static event AccountHandler ChangeCoinsEvent;
        
        public static bool EnothCoins(int count)
        {
           return PlayerPrefs.GetInt("Coins", 0) >= count ? true : false;
        }

        public static void SubtractCoins(int count)
        {
            int currentCoins = PlayerPrefs.GetInt("Coins", 0);
            currentCoins -= count;
            PlayerPrefs.SetInt("Coins", currentCoins);
            ChangeCoinsEvent?.Invoke();
        }

        public static void AddCoins(int count)
        {
            int currentCoins = PlayerPrefs.GetInt("Coins", 0);
            currentCoins += count;
            PlayerPrefs.SetInt("Coins", currentCoins);
            ChangeCoinsEvent?.Invoke();
        }

        public static int GetCoinsCount()
        {
            return PlayerPrefs.GetInt("Coins", 0);
        }
    }
}