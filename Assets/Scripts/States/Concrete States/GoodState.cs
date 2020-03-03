using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator.States
{
    public class GoodState : CatState
    {
        public GoodState(GameManager gameManager, Animator catAnimator, StateSettings settings) : base(gameManager, catAnimator, settings) {
        }
        public override void StartState() {
            base.StartState();
            gameManager.HeartParticles.Stop();
            gameManager.SkullParticles.Stop();
            catAnimator.SetInteger(AnimationTrigger.MoodLevel, AnimationTrigger.MoodLevelOk);
        }
    }
}
