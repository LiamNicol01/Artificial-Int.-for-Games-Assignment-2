using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class AddDrillToList : Action
{
	public SharedGameObjectList Drills;

	public override void OnStart()
	{
		Drills.Value.Add(this.gameObject);
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}