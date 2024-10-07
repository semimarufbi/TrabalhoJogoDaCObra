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
    
}
