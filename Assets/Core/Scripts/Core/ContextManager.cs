using UnityEngine;

public class ContextManager : MonoBehaviour
{
	public static ContextManager Instance { get; private set; }

	public PlayerInfo PlayerInfo;

	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(this);
		PlayerInfo = new PlayerInfo(120);
	}
}
