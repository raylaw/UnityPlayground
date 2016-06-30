using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameInfo
{
	public string name = "";
	public string id = "";
	public string version = "";
	public GameState state;
	public string iTune = "";
	public string iTuneStore = "";
	public string googlePlay = "";
	public string googlePlayStore = "";
	public string facebookPage = "";

}

[System.Serializable]
public enum GameState{
	development, production
}

[System.Serializable]
public class ServerInfo
{
	public string dataHost = "";
	public string fileHost = "";
}


[CreateAssetMenu(fileName = "Data", menuName = "Setting", order = 1)]
public class Setting : ScriptableObject {
	public GameInfo gameInfo = new GameInfo();
	public ServerInfo prodServerInfo = new ServerInfo();
	public ServerInfo devServerInfo = new ServerInfo();
}
