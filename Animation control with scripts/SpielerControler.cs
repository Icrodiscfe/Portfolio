using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class SpielerControler : BaseAiControler
{
    public override void Update()
    {
        base.Update();
        
    }

    public override void CheckForTarget()
    {
        base.CheckForTarget();
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Mouse0) & EventSystem.current.currentSelectedGameObject == null)
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2);
                if (hit.collider.CompareTag("Enemy"))
                {
                    Target = hit.transform;
                    navMeshAgent.destination = Target.position;
                    navMeshAgent.stoppingDistance = 0;
                }

                else
                {
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.stoppingDistance = 0;
                    Target = null;
                    isAttacking = false;
                    abortAttack = true;
                }
            }
        }
    }
}
