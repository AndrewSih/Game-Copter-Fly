using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviourPunCallbacks // класс для появления игроков на игровом поле
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) // если игрок создал сервер
        {
            Vector2 position1 = new Vector2(-13f, 0.55f); // позития появления
            PhotonNetwork.Instantiate("Player", position1, Quaternion.identity); // появление игрока ( имя , позития)
        }
        else // если игрок подключается к созданному серверу
        {
            Vector2 position2 = new Vector2(-16f, -0.55f);
            PhotonNetwork.Instantiate("Player 1", position2, Quaternion.identity);
        }
    }

    public void Leave() // метод для выхода из комнаты 
    {
        SceneManager.LoadScene(1); // загрузить сцену 1
        PhotonNetwork.LeaveRoom(); // выйти из комнаты не покидая подключение к лобби

    }
    public override void OnLeftRoom()
    {

        SceneManager.LoadScene(1);
    }
}