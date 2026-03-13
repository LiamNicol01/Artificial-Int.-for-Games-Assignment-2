using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckDrill : Conditional
{
	public SharedGameObjectList Drills;
	public SharedInt Index;
	public SharedVector3 Destination;

	public override TaskStatus OnUpdate()
	{
		// If drill has 1 or more resources, success, go to it
		if (Drills.Value.Count >= Index.Value + 1)
		{
			GameObject drill = Drills.Value[Index.Value];
			// Retrieve the resources the drill has accumulated
			SharedInt drillResources = drill.GetComponent<BehaviorTree>().GetVariable("Resource Amount") as SharedInt;
			// If the drill has 1 or more resources, the task has been a success
			if (drillResources.Value > 0)
			{
				// Set the destination
				Destination.Value = drill.transform.position;
				return TaskStatus.Success;
			}
		}

		// Otherwise iterate through the list of drills and return a failure
		Index.Value++;
		if (Index.Value >= Drills.Value.Count) Index.Value = 0;
		return TaskStatus.Failure;
	}
}