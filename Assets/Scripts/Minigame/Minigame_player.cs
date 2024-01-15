using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;

    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1f;
        }

        transform.position += moveSpeed * Time.deltaTime * dir;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -1f * MinigameManager.Instance.rect.x, MinigameManager.Instance.rect.x),
            Mathf.Clamp(transform.position.y, -1f * MinigameManager.Instance.rect.y, MinigameManager.Instance.rect.y), 0f);
    }
}
