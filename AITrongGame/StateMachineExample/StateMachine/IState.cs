using UnityEngine;

namespace AITrongGame
{
	public interface IState
	{
		void OnEnter(Shooter shooter);

		void OnExecute(Shooter shooter);

		void OnExit(Shooter shooter);
	}

}
