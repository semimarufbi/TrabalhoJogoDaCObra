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
    public Vector3 valordacamera;
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
    public void DefinirDiametro(string value)
    {
        diametroDoCampo = int.Parse(value);
    }
    public void DefinirVelocidade(string value)
    {
        GameObject.Find("snake").GetComponent<Snake>().speed = float.Parse(value);
    }
    public void SpawnFood()
    {


        
        {
            // Se já houver uma comida gerada, destrói antes de criar uma nova
            if (spawnedFood != null)
            {
                Destroy(spawnedFood);
            }

            // Gera uma posição aleatória dentro dos limites do campo de jogo
            int randomX = Random.Range(0, diametroDoCampo);
            int randomY = Random.Range(0, diametroDoCampo);

            // Ajusta a posição para o centro do campo de jogo
            Vector2 spawnPosition = new Vector2(randomX - valordacamera.x, randomY - valordacamera.y);

            // Instancia a comida na nova posição
            spawnedFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }
 public void OnFoodCollected()
    {
        SpawnFood();
    }
    
}
