using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
public class Item : MonoBehaviour
{
	// Test comment
	public int ItemID = 0;

	public int Amount = 1;

	public string ItemName = "name";

	public string ItemDecription = "description";

	public Sprite icon;

	public Sprite inventoryImage;

	public int ActiveEffect = 0;

	public int PassiveEffect = 0;
}
