using MalbersAnimations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public LayerMask npc;
    public Camera cam;
    [SerializeField] private MalbersInput onHorse;
    private void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 10, npc))
            {
                if (onHorse.enabled == true)
                {
                    hit.transform.gameObject.GetComponent<NPCscript>().interact();
                }
            }
        }
    }
}
