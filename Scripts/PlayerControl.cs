using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody; // ��������� ���� RigidBody ( ������������ ����)
    [SerializeField] private float speed; // ���� ��� ������� �������� �� ��������
    [SerializeField] private float flyForce; // ���� ��� ������� �������� �����
    private Vector2 dir; // ���� ��������� ���������
    [SerializeField] private float maxSpeed; // ���� ����������� ������������ �������� �������� �����
    private PhotonView photonview; // ������ �� ���� ��������
    public float normalSpeed = 4f; // ���������� �������� �������� �� ��������
    public GameObject canvas; // ���� ��� �������� ����������
    public GameObject winCanvas;// ��� ������� ����������
    public GameObject looseCanvas; // ��� ������� ������������
    public GameObject _camera; // ��� ������
    
    void Start()
    {
        photonview = GetComponent<PhotonView>(); // �������� ���������� ��������
        rigidBody = GetComponent<Rigidbody2D>(); // �������� ���������� RigidBody
        if (!photonview.IsMine)  // �������, ���� �� ��������� ����� ( �� ���� ��� �� ��� �����)
        {
           _camera.SetActive(false); // ��������� ������
            canvas.SetActive(false); // ��������� ������ ����������
            winCanvas.SetActive(false); // ��������� ������ ����������
            looseCanvas.SetActive(false); // ��������� ������ ������������

        }
    }

    private void FixedUpdate() // ����� ������� ��������� �����������
    {
        if (photonview.IsMine) // ���� �� ��������� �����
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); // �������� �� �������� 
            if (rigidBody.velocity.y >= maxSpeed) 
            {
                rigidBody.velocity = new Vector2(dir.x, maxSpeed); // �������� �����
            }
        }
       
    }
    public void LeftButtonDown() // ����� ��� ����� ������ ����������
    {
        if (speed >= 0f)  
        {
            speed = -normalSpeed; // ��� ��������� ������, �������� �������� ���������� �������� ���������� ��������
                                  // ����� ������ �����
        }
    }
    public void RightButtonDown() // ����� ��� ������ ������
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void ButtonUp() // ����� ��� ���������� ������
    {
        speed = 0f;
    }
    public void Fly() // ����� ��� �������� �����
    {

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }

        rigidBody.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse); // ������ ���� �������� �����
    } 
    public void PressPause() // ���� ������ �� ������ �����
    {
        Camera.main.GetComponent<CanvasScript>().Pause(); // ������������ ����� Pause, ������� ��������� � ���������� ������, � ������� canvasscript
    }
    private void OnTriggerEnter2D(Collider2D win) // ����� ��� ������, ��� ��������������� � ����������� ������
    {
        if (win.gameObject.tag == "Finish") // ���� ����� ����������� � ������� � ����� �����
        {
            if (photonview.IsMine) // ���� �� ��������� �����
            {
                winCanvas.SetActive(true); // �������� ������ ����������
                Time.timeScale = 0.01f; // ����������� ����� ����
            }
            else // ����  �� ��������� �����
            {
                looseCanvas.SetActive(true); // �������� ������ ������������
                Time.timeScale = 0.01f; 
            }
        }
    }
    public void CanvasButtonExit() // ����� ������ ������ �� ����
    {
        Application.Quit();
    }
    public void CanvasButtonReset() // ����� ������ ����������� ����
    {
        GameObject.Find("SpawnPlayer").GetComponent<SpawnPlayer>().Leave();
    }

}
