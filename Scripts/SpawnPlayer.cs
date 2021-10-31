using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviourPunCallbacks // ����� ��� ��������� ������� �� ������� ����
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) // ���� ����� ������ ������
        {
            Vector2 position1 = new Vector2(-13f, 0.55f); // ������� ���������
            PhotonNetwork.Instantiate("Player", position1, Quaternion.identity); // ��������� ������ ( ��� , �������)
        }
        else // ���� ����� ������������ � ���������� �������
        {
            Vector2 position2 = new Vector2(-16f, -0.55f);
            PhotonNetwork.Instantiate("Player 1", position2, Quaternion.identity);
        }
    }

    public void Leave() // ����� ��� ������ �� ������� 
    {
        SceneManager.LoadScene(1); // ��������� ����� 1
        PhotonNetwork.LeaveRoom(); // ����� �� ������� �� ������� ����������� � �����

    }
    public override void OnLeftRoom()
    {

        SceneManager.LoadScene(1);
    }
}