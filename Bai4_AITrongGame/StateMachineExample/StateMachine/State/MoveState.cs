using UnityEngine;

namespace AITrongGame
{
    public class MoveState : IState
    {
        private Vector3 target;
        public MoveState(Vector3 target)
        {
            this.target = target;
        }
        public void OnEnter(Shooter shooter)
        {
            shooter.Move(target);
        }

        public void OnExecute(Shooter shooter)
        {
            shooter.Moving();

            if (shooter.HasArrived())
            {
                if (shooter.Slot)
                {
                    shooter.TransitionTo(new WaitingShotState());
                    if(!GameManager.Instance.isFinishLevel) GameAudioManager.instance.PlayTriggerSound(TriggerSound.BOT_PICK);
                }
                else
                    shooter.TransitionTo(new IdleState());
                return;
            }
        }

        public void OnExit(Shooter shooter)
        {
            shooter.StopMoving();
        }
    }
}
