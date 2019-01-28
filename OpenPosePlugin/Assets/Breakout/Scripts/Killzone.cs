using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GM.instance.LoseLife();
    }
}
