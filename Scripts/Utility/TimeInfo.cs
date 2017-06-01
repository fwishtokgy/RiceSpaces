using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ricecore.Utility
{
    public class TimeInfo : MonoBehaviour
    {
        
        public enum Unit
        {
            Second = 0,
            Minute = 1,
            Hour = 2,
            Day = 3,
            Week = 4,
            Month = 5,
            Year = 6
        };

        public enum Month
        {
            December = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11
        }

        public enum DaysPerMonth
        {
            December = 31,
            January = 31,
            February = 28,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30
        }

        public enum Weekday
        {
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        }

        public enum Season
        {
            Winter = 0,
            Spring = 1,
            Summer = 2,
            Fall = 3
        }
    }
}