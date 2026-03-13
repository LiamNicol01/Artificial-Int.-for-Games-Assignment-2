using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private GameObject _drillPrefab;
	[SerializeField] private GameObject _powerPlantPrefab;
	[SerializeField] private GameObject _dronePrefab;

    private float m_countdown = 0.0f;

    private void OnMouseOver()
	{
        // If mousing over a resource && it doesn't have a Drill
		if (tag == "Coal" || tag == "Copper" || tag == "Iron" || tag == "Wood")
        {
			// If the left mouse button is down
			if (Input.GetKey(KeyCode.Mouse0))
			{
				if (this.GetComponent<ResourceController>().Drill == false) MineResource();
			}
			else
			{
				m_countdown = 0.0f;
			}

            // If the right mouse button is clicked
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				if (this.GetComponent<ResourceController>().Drill == false) CreateDrill();
			}
		}

        // If mousing over a drill
        if (tag == "Drill")
        {
            // If the right mouse button is clicked
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                CreatePowerPlant();
            }
        }

        // If mousing over the Storage
        if (tag == "Storage")
        {
            // If the right mouse button is clicked
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
                CreateDeliveryDrone();
			}
		}
    }

    private void MineResource()
    {
        // If there is resource to mine
        if (this.GetComponent<ResourceController>().ResourceAmount > 0)
        {
			// Mining Countdown
			m_countdown += Time.deltaTime;
			// Logging the current countdown timer
			Debug.Log("Mining Countdown: " + m_countdown);

			if (m_countdown >= 5.0f)
			{
				// Reset timer
				m_countdown = 0.0f;

                ResourceController ResourceCtrl = this.GetComponent<ResourceController>();
                // Remove resource from stack
                ResourceCtrl.ResourceAmount--;
                // Update text on the resource stack
                ResourceCtrl.UpdateResourceText();

				StorageController StorageCtrl = GameObject.FindWithTag("Storage").GetComponent<StorageController>();
				// Add resource to storage
				StorageCtrl.IncreaseResourceByTag(this.tag);
                // Update text on the storage building
				StorageCtrl.UpdateResourceText();
			}
		}
    }

    private void CreateDrill()
    {
	    StorageController storageCtrl = GameObject.FindWithTag("Storage").GetComponent<StorageController>();
    	// If has enough resources
    	if (storageCtrl.Iron >= 2 && storageCtrl.Wood >= 2)
        {
            // Remove resources from storage
            storageCtrl.Iron -= 2;
            storageCtrl.Wood -= 2;
            // Update text
            storageCtrl.UpdateResourceText();

			// Create Drill
			// Store a transform value
			Transform spawn = transform;
			// Adjust drill location to be slightly above resource, also changes resource position
			spawn.position += new Vector3(0, 0.75f, 0);
			// Instantiate drill
			GameObject drill = Instantiate(_drillPrefab, spawn.position, Quaternion.identity, null);
			// Set the resource drill value to true
			this.GetComponent<ResourceController>().Drill = true;
			// Adjust resource location back to original position
			transform.position -= new Vector3(0, 0.75f, 0);
			// Set the resource node of the drill
            drill.GetComponent<BehaviorTree>().GetVariable("Resource Node").SetValue(this.gameObject);
		}
        else
        {
            Debug.Log("Insufficient resources. Requires iron 2, wood 2.");
        }
    }

    private void CreatePowerPlant()
    {
        SharedBool PowerPlant = this.GetComponent<BehaviorTree>().GetVariable("Power Plant") as SharedBool;
		// If doesn't have Power Plant
        if (PowerPlant.Value == false)
        {
			StorageController storageCtrl = GameObject.FindWithTag("Storage").GetComponent<StorageController>();
			// If has resources
			if (storageCtrl.Copper >= 10 && storageCtrl.Iron >= 10 && storageCtrl.Coal >= 15)
            {
				// Remove resources from storage
				storageCtrl.Copper -= 10;
				storageCtrl.Iron -= 10;
				storageCtrl.Coal -= 15;
				// Update text
				storageCtrl.UpdateResourceText();

				// Create Power Plant
                // Store a transform value
				Transform spawn = transform;
                // Adjust power plant location to be slightly above drill, also changes resource drill
				spawn.position += new Vector3(0, 0.75f, 0);
                // Instantiate Power Plant
				GameObject powerPlant = Instantiate(_powerPlantPrefab, spawn.position, Quaternion.identity, null);
                // Set the drill power plant value to true
				PowerPlant.SetValue(true);
                // Set the countdown goal of the drill to 2 seconds
                SharedFloat CountdownGoal = this.GetComponent<BehaviorTree>().GetVariable("Countdown Goal") as SharedFloat;
				// Set the countdown goal of the drill (how long it takes for the drill to mine a resource)
                CountdownGoal.SetValue(2.0f);
                // Adjust resource location back to original position
				transform.position -= new Vector3(0, 0.75f, 0);
			}
			else
            {
				// Display message
				Debug.Log("Insufficient resources. Requires copper 10, iron 10, coal 15.");
			}
        }
        else
        {
            Debug.Log("This Drill already has a Power Plant.");
        }
	}

	private void CreateDeliveryDrone()
    {
		StorageController storageCtrl = GameObject.FindWithTag("Storage").GetComponent<StorageController>();
		// If has enough resources
		if (storageCtrl.Copper >= 2 && storageCtrl.Iron >= 2 && storageCtrl.Wood >= 15)
		{
			// Remove resources from storage
			storageCtrl.Copper -= 2;
			storageCtrl.Iron -= 2;
			storageCtrl.Wood -= 15;
			// Update text
			storageCtrl.UpdateResourceText();

			// Create Delivery Drone
			// Instantiate Delivery Drone
			GameObject drill = Instantiate(_dronePrefab, transform.position, Quaternion.identity, null);
		}
		else
		{
			Debug.Log("Insufficient resources. Requires copper 2, iron 2, wood 15.");
		}
	}
}
