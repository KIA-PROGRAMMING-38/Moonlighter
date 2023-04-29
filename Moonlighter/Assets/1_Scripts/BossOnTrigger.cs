using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnTrigger : MonoBehaviour
{
    public Boss BossRef;

    private BoxCollider2D _bossSpawnTrigger;

    private void Awake()
    {
        _bossSpawnTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(TagLiteral.PLAYER))
        {
            BossRef.gameObject.SetActive(true);
            _bossSpawnTrigger.enabled = false;
        }
    }
}
