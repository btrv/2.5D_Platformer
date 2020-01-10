using System.Collections;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           Player player = other.GetComponent<Player>();

           if(player != null)
            {
               player.LooseLife();
            }

            CharacterController cc = other.GetComponent<CharacterController>();
            if(cc != null)
            cc.enabled = false;

            other.transform.position = _spawnPoint.transform.position;

            StartCoroutine(CCElableRoutine(cc));
        }
    }

    IEnumerator CCElableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.3f);
        controller.enabled = true;
    }
}
