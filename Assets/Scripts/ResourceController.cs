using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public bool Drill = false;
    public int ResourceAmount = 0;

    public void UpdateResourceText()
    {
        // Update text on resource
		this.GetComponentInChildren<TextMeshPro>().text = "" + this.GetComponent<ResourceController>().ResourceAmount;
	}
}
