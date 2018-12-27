using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mother : Buyable {

	private Wallet wallet;

	protected override void onAwake() {
		wallet = gameObject.GetComponent<Wallet> ();
	}

	public override void playerEntered(Collider2D player) {
		string text = "Hey, sweetheart.";
		if (wallet.getAmountAvailable () > 0) {
			text += "I have some pocket money for you.";
		}
		textBubble.show (text);
	}

	public override void playerExited(Collider2D player) {
		textBubble.show ("I'll be rooting for you");
	}

	public override void interact(BuyableInteractor interactor) {
		wallet.addToWallet (interactor.getWallet (), wallet.getAmountAvailable ());
		textBubble.show ("There you go <3");
	}

	public override string getOnTriggerExitMessage() {
		return "Bye mom!";
	}
}
