using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator.States
{
    [CreateAssetMenu(menuName = "Cat State Settings")]
    public class StateSettings : ScriptableObject
    {
        [Serializable]
        public struct ActionData
        {
            [TextArea]
            public string Description;
            public CatMood MoodToChangeInto;
            public float AnimationLength;
        }

        public CatMood AssociatedMood;
        public ActionData FeedAction;
        public ActionData PetAction;
        public ActionData PlayAction;
        public ActionData KickAction;
    }
}
