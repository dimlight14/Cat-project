using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator.States
{
    public class AngryState : CatState
    {
        public AngryState(GameManager gameManager, StateSettings settings, Animator catAnimator) : base(gameManager, catAnimator, settings) {
        }
        public override void StartState() {
            base.StartState();
            gameManager.HeartParticles.Stop();
            gameManager.SkullParticles.Play();
            catAnimator.SetInteger(AnimationTrigger.MoodLevel, AnimationTrigger.MoodLevelAngry);
        }

    }
}
