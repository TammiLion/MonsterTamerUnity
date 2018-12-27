using System.Collections;
using UnityEngine;

public class Wallet: MonoBehaviour {

	[SerializeField]
	private int moneys = 0;

	[SerializeField]
	private int capacity = 100;

	Wallet() {
	}

	Wallet(int moneys) {
		this.moneys = moneys;
	}

	public int getAmountAvailable() {
		return moneys;
	}

	public bool addToWallet(Wallet wallet, int amount) {
		if (buy (amount)) {
			wallet.add (amount);
			return true;
		} else {
			return false;
		}
	}

	//returns true when buying was succesful, returns false when we didn't have enough to buy
	public bool buy(int amount) {
		if (moneys >= amount) {
			moneys -= amount;
			return true;
		} else {
			return false;
		}
	}

	//returns the amount of money that didn't fit the wallet
	public int add(int amount) {
		if (moneys + amount > capacity) {
			moneys = capacity;
			return (moneys + amount) - capacity;
		} else {
			moneys += amount;
			return 0;
		}
	}
}
