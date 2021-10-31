using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody; // объявляем поле RigidBody ( материальное тело)
    [SerializeField] private float speed; // поле для задания движение по сторонам
    [SerializeField] private float flyForce; // поле для задания движения вверх
    private Vector2 dir; // поле получения координат
    [SerializeField] private float maxSpeed; // поле ограничения максимальной скорости движения вверх
    private PhotonView photonview; // ссылка на поле фотонвью
    public float normalSpeed = 4f; // нормальная скорость движения по сторонам
    public GameObject canvas; // поле для каввнаса кправления
    public GameObject winCanvas;// для канваса победителя
    public GameObject looseCanvas; // для канваса проигравшего
    public GameObject _camera; // для камеры
    
    void Start()
    {
        photonview = GetComponent<PhotonView>(); // получаем компоненты фотонвью
        rigidBody = GetComponent<Rigidbody2D>(); // получаем компоненты RigidBody
        if (!photonview.IsMine)  // условия, если не локальный игрок ( то есть ели не наш игрок)
        {
           _camera.SetActive(false); // отключаем камеру
            canvas.SetActive(false); // отключаем канвас управления
            winCanvas.SetActive(false); // отключаем канвас победителя
            looseCanvas.SetActive(false); // отключаем канвас проигравшего

        }
    }

    private void FixedUpdate() // метод который постоянно обновляется
    {
        if (photonview.IsMine) // если мы локальный игрок
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); // движение по сторонам 
            if (rigidBody.velocity.y >= maxSpeed) 
            {
                rigidBody.velocity = new Vector2(dir.x, maxSpeed); // движение вверх
            }
        }
       
    }
    public void LeftButtonDown() // метод для левой кнопки управления
    {
        if (speed >= 0f)  
        {
            speed = -normalSpeed; // при включении метода, обратное значение нормальной скорости присвоится скорости
                                  // игрок пойдет влево
        }
    }
    public void RightButtonDown() // метод для правой кнопки
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void ButtonUp() // метод при отпускании кнопак
    {
        speed = 0f;
    }
    public void Fly() // метод для движения вверх
    {

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }

        rigidBody.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse); // задаем силу движения вверх
    } 
    public void PressPause() // если нажали на кнопку паузы
    {
        Camera.main.GetComponent<CanvasScript>().Pause(); // активировали метод Pause, который находится в компоненте камеры, в скрипте canvasscript
    }
    private void OnTriggerEnter2D(Collider2D win) // метод для финиша, при соприкосновении с коллайдером финиша
    {
        if (win.gameObject.tag == "Finish") // если игрок прикоснулся к объекту с тэгом финиш
        {
            if (photonview.IsMine) // если мы локальный игрок
            {
                winCanvas.SetActive(true); // включить канвас победителя
                Time.timeScale = 0.01f; // затормозить время игры
            }
            else // если  не локальный игрок
            {
                looseCanvas.SetActive(true); // включить канвас проигравшего
                Time.timeScale = 0.01f; 
            }
        }
    }
    public void CanvasButtonExit() // метод кнопки выхода из игры
    {
        Application.Quit();
    }
    public void CanvasButtonReset() // метод кнопки перезапуска игры
    {
        GameObject.Find("SpawnPlayer").GetComponent<SpawnPlayer>().Leave();
    }

}
