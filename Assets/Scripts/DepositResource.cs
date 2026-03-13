using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class DepositResource : Action
{
	public SharedInt ResourcesHeld;
	public SharedString ResourceType;

	public override TaskStatus OnUpdate()
	{
		StorageController  StorageCtrl = GameObject.FindGameObjectWithTag("Storage").GetComponent<StorageController>();
		if (ResourcesHeld.Value > 0)
		{
			ResourcesHeld.Value--;
			StorageCtrl.IncreaseResourceByTag(ResourceType.Value);
			StorageCtrl.UpdateResourceText();
		}
		return TaskStatus.Success;
	}
}