using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _gameVersion = "1.0";
    [SerializeField] private string _nickName = "Zackiller";
    [SerializeField] private byte _maxPlayers = 20;
    
    private const string TankPrefabName = "Tank";

    private void Awake()
    {
        PhotonNetwork.GameVersion = _gameVersion;
        PhotonNetwork.NickName = _nickName;
        // 방장이 새로운 씬을 로딩하면 해당 룸에 있는 모든 클라이언트가 자동으로 해당 씬이 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        // 포톤 서버에 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    #region Photon Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("포톤 서버에 접속 되었습니다.");
        
        // 로비 입장 요청 : 로비에 입장해야지만 룸 목록을 받아올 수 있다.
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비에 입장 완료");
        // 미리 생성된 방에 랜덤하게 입장 요청
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"방 입장 실패: {message}");
        
        // 방 생성
        // 룸 옵션 설정
        RoomOptions ro = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = _maxPlayers
        };

        PhotonNetwork.CreateRoom($"Room_{Random.Range(0, 1000):0000}", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("룸 생성 완료");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("룸 입장 완료");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        
        // 생성할 위치 좌표
        Vector3 pos = new Vector3(Random.Range(-100f, 100f), 10.0f, Random.Range(-100f, 100f));
        // 네트워크 탱크 생성
        PhotonNetwork.Instantiate(TankPrefabName, pos, Quaternion.identity);
    }

    #endregion
}
