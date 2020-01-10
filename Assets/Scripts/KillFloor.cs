using System.Collections;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> 90927c0c222a2d671ab0328c455fd63cdc0b409f
using UnityEngine;

public class KillFloor : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> 90927c0c222a2d671ab0328c455fd63cdc0b409f
    }
}
