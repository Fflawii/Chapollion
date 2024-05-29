using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown: MonoBehaviour
{
	public TextMeshProUGUI output;
	//[SerializeField] private TMP_Text tMP_Text;

	void HandleInputData(int val)
	{
	if (val == 0) { output.text = " I love Minecraft";}

	}
}
