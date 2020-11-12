using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ImportImage : MonoBehaviour 
{
	
	
	void Start()
	{
		
	}	

	void Update()
	{
		RaycastHit hit;
		//при нажатии на картину выполняется функция замены ее текстуры 
		if (Input.GetMouseButtonDown(0))
		{
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
			if (hit.transform.gameObject.CompareTag("Image"))
			{
				hit.transform.gameObject.GetComponent<ImgCoroutine>().SC();
            }
        }
		}
	}
}
	