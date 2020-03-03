using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator
{
    public class MoodChangedEvent : CustomEvent
    {
        public CatMood NewMood;
    }
}
