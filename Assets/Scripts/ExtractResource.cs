using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TMPro;

public class ExtractResource : Action
{
	public SharedInt ResourceAmount;
	public SharedString ResourceType;

	public override TaskStatus OnUpdate()
	{
		MineResource();

		return TaskStatus.Success;
	}

	private void MineResource()
	{
		GameObject resourceNode = this.gameObject.GetComponent<BehaviorTree>().GetVariable("Resource Node").GetValue() as GameObject;
		ResourceController resourceCtrl = resourceNode.GetComponent<ResourceController>();
		// If there is resource to mine
		if (resourceCtrl.ResourceAmount > 0)
		{
			// Remove resource from stack
			resourceCtrl.ResourceAmount--;
				
			// Update text on the resource stack
			resourceCtrl.UpdateResourceText();

			// Add resource to drill
			if (resourceNode.tag == "Wood") ResourceType.Value = "Wood";
			if (resourceNode.tag == "Coal") ResourceType.Value = "Coal";
			if (resourceNode.tag == "Copper") ResourceType.Value = "Copper";
			if (resourceNode.tag == "Iron") ResourceType.Value = "Iron";
			ResourceAmount.Value++;

			// Update text on the drill
			this.gameObject.GetComponentInChildren<TextMeshPro>().text = "" + ResourceAmount;
		}
	}
}