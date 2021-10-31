using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour // класс для сбора очков в игре
{ 
    public Canvas canvas; // поле для канваса
    public TMP_Text coinsText; // поле для количества очков
    private float coins = 0; // стартовое количество очков

    private void OnTriggerEnter2D(Collider2D coll) // метод действия после соприкосновения с препятствием
    {


        if (coll.gameObject.tag == "Between") // условие действий,  если игрок дотронулся до объекта с тэгом Between
        {
            coins +=10; // добавить 10 очков
            coinsText.text = coins.ToString(); // перевести полученный текст в строку и присвоить полю очков
            Destroy(coll.gameObject); // удалить объект с тэгом
        }

    }

}
