
using UnityEngine;

public class CanvasScript : MonoBehaviour // класс дл€ запуска канваса PauseCanvas
{
    [SerializeField] private GameObject pauseCanvas; // объ€вл€ем поле дл€ канваса и позвол€ем измен€ть пр€мо в юнити
  
    void Start()
    {
        pauseCanvas.SetActive(false); // выключаем канвас на старте
    }
   

    public void ExitButton() // метод выхода из приложени€
    {
        Application.Quit();
    }

    public void PlayButton() //метод возобновлени€ игры по нажатию кнопки продолжить
    {
        pauseCanvas.SetActive(false); //выключает канвас паузы
        Time.timeScale = 1f; // возобновл€ет игру после паузы

    }
    public void Pause() //метод постановки игры на паузу
    {
        pauseCanvas.SetActive(true); // включает канвас паузы
        Time.timeScale = 0f; // останавливает врем€ после нажати€ на паузу
    }
}
