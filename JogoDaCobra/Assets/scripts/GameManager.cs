using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public int diametroDoCampo;
    public int[,] grade;
    UIManager managerUI;
    GameObject menu, gameover;
    public GameObject foodPrefab;
    private GameObject spawnedFood;
    Camera possicaoinicial;
    Vector3 valordacamera;
    // Start is called before the first frame update
    void Start()
    {
        managerUI = GetComponent<UIManager>();
        menu = GameObject.Find("menu");
        gameover = GameObject.Find("GameOverPanel");
      
    }
    public void GerarGrade()
    {
        grade = new int[diametroDoCampo,diametroDoCampo];
        CameraSeguidora();
    }
    public void CameraSeguidora()
    {
        Camera.main.transform.position = new Vector3(diametroDoCampo / 2f - 0.5f, diametroDoCampo / 2f - 0.5f, -10);
        Camera.main.orthographicSize = diametroDoCampo / 2f;
        
    }
    public void calculocamera()
    {
       valordacamera = possicaoinicial.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height));

    }
    public void DefinirDIametro(string value)
    {
        diametroDoCampo = int.Parse(value);
    }
    public void DefinirVelocidade(string value)
    {
        GameObject.Find("snake").GetComponent<Snake>().speed = float.Parse(value);
    }
    public void SpawnFood()
    {
        
        if (spawnedFood != null)
        {
            Destroy(spawnedFood);
        }
        int randomX = Random.Range(diametroDoCampo/-2,diametroDoCampo/2);
        int randomY = Random.Range(diametroDoCampo/-2, diametroDoCampo/2);
        
        Vector2 spawnPosition = new Vector2(randomX,randomY);
        
      if(randomX > diametroDoCampo /-2 && randomX < diametroDoCampo / 2 && randomY > diametroDoCampo / -2 && randomY < diametroDoCampo / 2) 
        {
            spawnedFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            SpawnFood();
        }
      

       
    }
    public void OnFoodCollected()
    {
        SpawnFood();
    }
    
}
