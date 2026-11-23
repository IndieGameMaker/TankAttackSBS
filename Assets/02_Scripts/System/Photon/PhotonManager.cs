using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _gameVersion = "1.0";
    [SerializeField] private string _nickName = "Zackiller";
    [SerializeField] private byte _maxPlayers = 20;

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
    }

    #endregion
}
