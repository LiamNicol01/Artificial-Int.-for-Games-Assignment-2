using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GoToDestination : Action
{
	public SharedVector3 Destination;
	public SharedFloat DroneSpd;

	public override TaskStatus OnUpdate()
	{
		// Step towards destination
		transform.position = Vector3.MoveTowards(transform.position, Destination.Value, DroneSpd.Value * Time.deltaTime);
		// If the destination has been reached, the task was successful
		if (this.gameObject.transform.position == Destination.Value) return TaskStatus.Success;
		// Otherwise, continue running the task
		return TaskStatus.Running;
	}
}