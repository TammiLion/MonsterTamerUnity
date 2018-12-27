using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

class Buyable : BaseInteractable<BuyableInteractor> {

	[SerializeField]
	private int cost;
	private Wallet boughtBy;

	private GameObject buySprite;

	protected override void onAwake ()
	{
		buySprite = transform.Find ("BuySprite").gameObject;
	}

	public override void playerEntered (Collider2D player) {
		BuyableInteractor buyer = player.GetComponent<BuyableInteractor> ();
		if (boughtBy != buyer.getWallet()) {
			textBubble.show ("This costs: " + cost);
			buySprite.SetActive (true);
		}
	}

	public override void playerExited (Collider2D player) {
		buySprite.SetActive (false);
	}

	public override void interact(BuyableInteractor interactor) {
		buy (interactor.getWallet());
	}

	private void buy(Wallet wallet) {
		if (wallet.buy(cost)) {
			boughtBy = wallet;
			SpriteRenderer spriteRenderer = buySprite.GetComponent<SpriteRenderer> ();
			spriteRenderer.color = Color.yellow;
		} else {
			textBubble.show ("I ain't givin you broke ass Player nuthing");
		}
	}

	public int getCost() {
		return cost;
	}

	public bool isBought(Wallet wallet) {
		return boughtBy == wallet;
	}

	public override string getOnTriggerExitMessage() {
		return "We ain't buying this shit: " + gameObject.name;
	}
}
