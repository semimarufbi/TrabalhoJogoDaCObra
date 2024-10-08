using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region
    GameManager instnce;
    private void Awake()
    {
        instnce = this;
    }
    #endregion
    public int diametroDoCampo;
    public int[,] grade;
    UImanager managerUI;
    GameObject menu, gameover;
    // Start is called before the first frame update
    void Start()
    {
        managerUI = GetComponent<UImanager>();
        menu = GameObject.Find("menu");
        gameover = GameObject.Find("GameOverPanel");
        GerarGrade();
    }
    public void GerarGrade()
    {
        grade = new int[diametroDoCampo,diametroDoCampo];
    }
    public void CameraSeguidora()
    {
        Camera.main.transform.position = new Vector3(diametroDoCampo / 2f - 0.5f, diametroDoCampo / 2f - 0.5f, -10);
        Camera.main.orthographicSize = diametroDoCampo / 2f;
    }
    public void DefinirDIametro(string value)
    {
        diametroDoCampo = int.Parse(value);
    }
    public void DefinirVelocidade(string value)
    {
        GameObject.Find("snake").GetComponent<Snake>().speed = float.Parse(value);
    }
    
}
