using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    /* Array for inventory
     * Index 0: Bomb
     * Index 1: TBD
     */

    int[] inventory = new int[1];

	// Use this for initialization
	void Start () {
        inventory[0] = 3;
	}
	
	public bool UseBomb () {
        if (inventory[0] > 0) {
            inventory[0] -= 1;
            return true;
        }
        return false;
    }

    public int GetBomb() {
        return inventory[0];
    }

    public void AddBomb() {
        inventory[0] += 1;
    }
}
