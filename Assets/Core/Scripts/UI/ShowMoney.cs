using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _moneyText;

	private void Start()
	{
		_moneyText.text = ContextManager.Instance.PlayerInfo.Money.ToString();
		ContextManager.Instance.PlayerInfo.ChangeMoney += ((value) => _moneyText.text = value.ToString());
	}
}
