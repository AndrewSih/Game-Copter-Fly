using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour // ����� ��� ����� ����� � ����
{ 
    public Canvas canvas; // ���� ��� �������
    public TMP_Text coinsText; // ���� ��� ���������� �����
    private float coins = 0; // ��������� ���������� �����

    private void OnTriggerEnter2D(Collider2D coll) // ����� �������� ����� ��������������� � ������������
    {


        if (coll.gameObject.tag == "Between") // ������� ��������,  ���� ����� ���������� �� ������� � ����� Between
        {
            coins +=10; // �������� 10 �����
            coinsText.text = coins.ToString(); // ��������� ���������� ����� � ������ � ��������� ���� �����
            Destroy(coll.gameObject); // ������� ������ � �����
        }

    }

}
