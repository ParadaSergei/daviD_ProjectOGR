using Cainos.PixelArtPlatformer_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _closeDoor;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _closeDoor.Play();
            transform.GetComponentInParent<Door>().Close();
            transform.GetComponentInParent<Collider2D>().isTrigger = false;
        }
    }
}
