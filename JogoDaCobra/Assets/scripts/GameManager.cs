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
            // Se j� houver uma comida gerada, destr�i antes de criar uma nova
            if (spawnedFood != null)
            {
                Destroy(spawnedFood);
            }

            // Gera uma posi��o aleat�ria dentro dos limites do campo de jogo
            int randomX = Random.Range(0, diametroDoCampo);
            int randomY = Random.Range(0, diametroDoCampo);

            // Ajusta a posi��o para o centro do campo de jogo
            Vector2 spawnPosition = new Vector2(randomX - valordacamera.x, randomY - valordacamera.y);

            // Instancia a comida na nova posi��o
            spawnedFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }
 public void OnFoodCollected()
    {
        SpawnFood();
    }

    private void LimitPlayerPosition()
    {
        Vector3 playerPosition = transform.position;

        // Calcula os limites do campo usando valordacamera
        float halfFieldWidth = GameManager.instance.valordacamera.x;  // Largura do campo
        float halfFieldHeight = GameManager.instance.valordacamera.y; // Altura do campo

        // Limite para a posi��o X
        if (playerPosition.x > halfFieldWidth)
        {
            playerPosition.x = halfFieldWidth; // Limita ao m�ximo
        }
        else if (playerPosition.x < -halfFieldWidth)
        {
            playerPosition.x = -halfFieldWidth; // Limita ao m�nimo
        }

        // Limite para a posi��o Y
        if (playerPosition.y > halfFieldHeight)
        {
            playerPosition.y = halfFieldHeight; // Limita ao m�ximo
        }
        else if (playerPosition.y < -halfFieldHeight)
        {
            playerPosition.y = -halfFieldHeight; // Limita ao m�nimo
        }

        // Atualiza a posi��o do jogador
        transform.position = playerPosition;
    }
    private void Update()
    {
        // Primeiro, atualize a posi��o do jogador conforme o movimento
        Vector3 playerPosition = transform.position;

        // Aqui voc� pode adicionar a l�gica de movimento da cobra...

        // Chame o m�todo para limitar a posi��o do jogador
        LimitPlayerPosition();
    }



}
