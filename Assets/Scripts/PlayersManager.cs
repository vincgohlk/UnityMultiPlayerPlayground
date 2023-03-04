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
            if(IsServer)
                playersInGame.Value++;
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if(IsServer)
                playersInGame.Value--;
        };
    }
}
