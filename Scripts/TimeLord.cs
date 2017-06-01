using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using ricecore.Utility;

namespace ricecore
{
    public class TimeLord : MonoBehaviour
    {
        
        public bool isPaused;
        public bool inAccMode;

        DateTime virtualTime;

        int NormalTick;
        int AccTick;

        void Start()
        {
            input(TimeInfo.Unit.Day, 1, 2, 30, 0);

        }

        #region Control
        public void BlindForward()
        {

        }
        public TimeSpan DirectedForward()
        {
            TimeSpan timespan = new TimeSpan();


            return timespan;
        }

        void test(params int[] yes)
        {
            for (int i=0; i<yes.Length; i++)
            {
                Debug.Log(String.Format("buddy {0}", yes[i]));
            }
        }
        void input(TimeInfo.Unit unit, params int[] amount)
        {
            test(amount);
            if (amount.Length==0 || amount.Length>7)
            {
                Debug.LogError("Error: input amount out of range.");
                return;
            }
            if (amount.Length > ((int)unit+1))
            {
                Debug.LogError("Error: input amount out of range of specified timeinfo unit.");
                return;
            }
            // convert input time into seconds
            int pieces = amount.Length;
            int[] secsPerTimeUnit = { 1, 60, 3600, 86400, 604800, 1, 31536000};
            int amountInSeconds = 0;
            while (pieces>0)
            {
                pieces += -1;
                int buffer = secsPerTimeUnit[pieces];
                amountInSeconds += amount[pieces] * buffer;
            }
            switch (unit)
            {
                case TimeInfo.Unit.Second:
                    input(amount[0]);
                    break;
                default:
                    break;
            }
        }
        void input(int amount)
        {
            input(TimeInfo.Unit.Second, amount);
        }
        
        #endregion

        #region Acceleration

        #endregion

        #region Default

        #endregion

    }
}