using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator.States
{
    public class HappyState : CatState
    {

        public HappyState(GameManager gameManager, StateSettings settings, Animator catAnimator) : base(gameManager, catAnimator, settings) {
        }
        public override void StartState() {
            base.StartState();
            gameManager.HeartParticles.Play();
            gameManager.SkullParticles.Stop();
            catAnimator.SetInteger(AnimationTrigger.MoodLevel, AnimationTrigger.MoodLevelHappy);
        }

        public override void GetKicked() {
            base.GetKicked();
            gameManager.HeartParticles.Stop();
        }
    }
}
