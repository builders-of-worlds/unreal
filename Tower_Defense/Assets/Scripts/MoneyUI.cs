using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

	public Text moneyText;

	// kiiratás frissítése
	void Update () {
		moneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
