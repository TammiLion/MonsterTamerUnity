using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BuyableInteractor : BaseInteractor<Buyable> {

	private Wallet wallet;

	protected override void onAwake() {
		wallet = gameObject.GetComponent<Wallet> ();
	}

	protected override void onInteract () {
		if (!currentlyInteractable.isBought (wallet)) {
			currentlyInteractable.interact (this);
		}
	}

	protected override void onExitingInteractable (Buyable interactable) {
		if (!interactable.isBought (wallet)) {
			string exitMessage = interactable.getOnTriggerExitMessage ();
			if (exitMessage.Length > 0) {
				textBubble.show (exitMessage);
			}
		}
	}

	public Wallet getWallet() {
		return wallet;
	}
}
