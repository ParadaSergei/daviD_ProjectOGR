using Cainos.PixelArtPlatformer_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSCeneDoor : MonoBehaviour
{
    public GameObject bossPrefab;
    [SerializeField] private AudioSource openLastDoor;
    void Update()
    {
        if (!bossPrefab)
        {
            transform.GetComponent<Door>().Open();
            openLastDoor.Play();
            transform.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
