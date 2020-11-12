using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //при нажатии игрок идет в точку нажатия, если точка нажатия не картина
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (!hit.transform.gameObject.CompareTag("Image"))
                {
                    target.transform.position = hit.point;
                    anim.SetTrigger("walk");
                    agent.destination = hit.point;
                }
            }
        }
        //агент близко у цели
        if (agent.remainingDistance < 0.1f)
        {
            StartCoroutine(stop());
        }
    }

    //корутина для переключения в анимацию покоя
    IEnumerator stop()
    {
        anim.SetTrigger("idle");
        yield return new WaitForSeconds(0.1f);
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
