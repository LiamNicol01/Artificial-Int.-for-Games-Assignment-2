using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StorageController : MonoBehaviour
{
	[SerializeField] private TextMeshPro _woodText;
	[SerializeField] private TextMeshPro _coalText;
	[SerializeField] private TextMeshPro _copperText;
	[SerializeField] private TextMeshPro _ironText;

	public int Wood;
	public int Coal;
	public int Copper;
	public int Iron;

	public void IncreaseResourceByTag(string tag)
	{
		if (tag == "Wood") Wood++;
		if (tag == "Coal") Coal++;
		if (tag == "Copper") Copper++;
		if (tag == "Iron") Iron++;
	}

	public void UpdateResourceText()
    {
		_woodText.text = "" + Wood;
		_coalText.text = "" + Coal;
		_copperText.text = "" + Copper;
		_ironText.text = "" + Iron;
    }
}
