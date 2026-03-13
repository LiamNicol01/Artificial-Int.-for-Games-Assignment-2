using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class TimerLogic : Action
{
	public SharedFloat Timer;
	public SharedFloat TimeGoal;

	public override TaskStatus OnUpdate()
	{
		Timer.SetValue(Timer.Value + Time.deltaTime);
		if (Timer.Value >= TimeGoal.Value)
		{
			return TaskStatus.Success;
		}

		return TaskStatus.Failure;
	}
}