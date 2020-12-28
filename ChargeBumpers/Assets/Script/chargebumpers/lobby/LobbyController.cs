using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button btRedTeam;
    [SerializeField] private Button btBlueTeam;
    [SerializeField] private Text waitLabel;

    private const string ROOM_ID = "cbroom";
    private const byte MAX_PLAYERS = 6;

    private void Awake()
    {
        UpdateButtons(false);

    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    public override void OnConnectedToMaster()
    {
        UpdateButtons(true);
        Debug.Log("Connected : " + PhotonNetwork.CloudRegion + " server");
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    private void UpdateButtons(bool isEnable)
    {
        btRedTeam.gameObject.SetActive(isEnable);
        btBlueTeam.gameObject.SetActive(isEnable);
        waitLabel.gameObject.SetActive(!isEnable);

        if (isEnable)
        {
            btRedTeam.onClick.RemoveAllListeners();
            btBlueTeam.onClick.RemoveAllListeners();

            btBlueTeam.onClick.AddListener(JoinRoom);
            btRedTeam.onClick.AddListener(JoinRoom);
        }
    }

    private void JoinRoom()
    {
        PhotonNetwork.JoinRoom(ROOM_ID);
        Debug.Log("Searching room...");
    }

    public override void OnJoinedRoom()
    {
        string str = "Join Completed... wait players...";
        Debug.Log(str);
        UpdateButtons(false);
        waitLabel.text = str;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        string str = "Join Failed " + returnCode + " | " + message;
        Debug.Log(str);
        UpdateButtons(false);
        waitLabel.text = str;
        CheckRoom();
    }

    private void CheckRoom()
    {
        Debug.Log("Creating room  : " + ROOM_ID);

        RoomOptions roomOptions = new RoomOptions
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = MAX_PLAYERS
        };

        PhotonNetwork.CreateRoom(ROOM_ID, roomOptions);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
       if(PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount + " |  " + MAX_PLAYERS + " Starting Game");
            PhotonNetwork.LoadLevel(1);
        }
    }
}
