using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private int health;

	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage (int amount)
	{
		// Decrement the player's health by amount.
		health -= amount;
		healthBar.SendMessage ("ReduceHealth", amount);
	}

	public int getHealth(){
		return health;
	}
}
