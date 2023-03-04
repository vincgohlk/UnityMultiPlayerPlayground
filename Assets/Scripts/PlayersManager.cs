using DilmerGames.Core.Singletons;
using Unity.Netcode;

public class PlayersManager : NetworkSingleton<PlayersManager>
{
    private NetworkVariable<int> playersInGame = new NetworkVariable<int>(); //Check the the options for NetworkVariable Methods

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Logger.Instance.LogInfo($"{id} just connected...");
            if(IsServer)
                playersInGame.Value++;
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            Logger.Instance.LogInfo($"{id} just disconnected...");
            if (IsServer)
                playersInGame.Value--;
        };
    }
}
