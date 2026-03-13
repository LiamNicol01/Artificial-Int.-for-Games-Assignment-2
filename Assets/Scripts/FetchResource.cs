using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TMPro;

public class FetchResource : Action
{
	public SharedGameObjectList Drills;
	public SharedInt Index;
	public SharedVector3 Destination;
	public SharedInt ResourcesHeld;
	public SharedString ResourceType;

	public override TaskStatus OnUpdate()
	{
		GameObject drill = Drills.Value[Index.Value];
		// Retrieve the resources the drill has accumulated

		BehaviorTree drillTree = drill.GetComponent<BehaviorTree>();
		SharedInt drillResources = drillTree.GetVariable("Resource Amount") as SharedInt;
		// If resources at drill > 0
		if (drillResources.Value > 0)
		{
			// Take a resource from the drill
			drillResources.Value--;
			drillTree.SetVariable("Resource Amount", drillResources);
			// Update text on the drill
			drill.GetComponentInChildren<TextMeshPro>().text = "" + drillResources;
			// Store the resource type
			SharedString resourceType = drillTree.GetVariable("Resource Type") as SharedString;
			ResourceType.Value = resourceType.Value;
			// Add a resource to the drone
			ResourcesHeld.Value++;
		}

		// Increment index
		Index.Value++;
		// Set destination to the storage
		Destination.Value = GameObject.FindGameObjectWithTag("Storage").transform.position;
		return TaskStatus.Success;
	}
}