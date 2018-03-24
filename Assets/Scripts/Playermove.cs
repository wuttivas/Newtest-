using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : TacticsMove {

	// Use this for initialization
	void Start ()
    {
        Init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindSelectableTiles();
        checkedMouse();
	}
    else
    {
    //todo: Move();
    }
}

void checkMouse()
{
    if (Input.GetMouseButtonUp(0))
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if hit.collider.GetComponent<Tile>();

            if (this.selectable)
            {
                //todo: move target
                T.target = true;
                moving = true;
            }


        }
    }
}
