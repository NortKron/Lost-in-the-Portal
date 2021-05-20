using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	private Sprite sprite;

    void Start()
    {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}

    void OnTriggerEnter2D(Collider2D obj) //«Наезд» на объект
	{
		if (obj.transform.tag == "Player")
		{
			// Если наехал игрок, то он сможет подобрать предмет
			//obj.GetComponent<Items>().AddItem(sprite);

			// Удаление объекта с карты
			Destroy(gameObject); 
		}
	}

}
