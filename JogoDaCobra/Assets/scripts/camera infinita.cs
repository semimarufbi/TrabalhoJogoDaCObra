using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public int diametroDoCampo;

    void Update()
    {
        // Pega a posição atual do jogador
        Vector3 playerPosition = transform.position;

        // Verifica se o jogador saiu pelos lados horizontais
        if (playerPosition.x > diametroDoCampo / 2)
        {
            // Teleporta o jogador para o lado esquerdo
            playerPosition.x = -diametroDoCampo / 2;
        }
        else if (playerPosition.x < -diametroDoCampo / 2)
        {
            // Teleporta o jogador para o lado direito
            playerPosition.x = diametroDoCampo / 2;
        }

        // Verifica se o jogador saiu pelos lados verticais
        if (playerPosition.y > diametroDoCampo / 2)
        {
            // Teleporta o jogador para a parte de baixo
            playerPosition.y = -diametroDoCampo / 2;
        }
        else if (playerPosition.y < -diametroDoCampo / 2)
        {
            // Teleporta o jogador para a parte de cima
            playerPosition.y = diametroDoCampo / 2;
        }

        // Atualiza a posição do jogador
        transform.position = playerPosition;
    }
}
