using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class InGameController : MonoBehaviour
{
    public static InGameController instance;
    [SerializeField] private Text unameText;
    public string uname,pass;
    public Animator desk,bigHologram;
    public bool statusOpen, statusRotate = false;
    public Vector3[] targetTrapDoorOpen;
    public GameObject[] organs; 
    public Slider sliderRotation,sliderScale;
    public float time;
    private float timeStore;

    private void Awake()
    { 
        instance = this;
    }
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    { 

        EditableOrgans();
    }
    
    public IEnumerator AnimationOrgansShowUp()
    {
        desk.enabled = true;
        if (statusOpen == true)
        {

            if (bigHologram != null)
            {
                bigHologram.SetBool("open", false);
            }

            desk.SetBool("open", false);
            statusOpen = false;
            
        }
        else
        {
            desk.SetBool("open", true);
            if (bigHologram != null)
            {
                bigHologram.SetBool("open", true);
            }
            statusOpen = true;
            yield return new WaitForSeconds(3f);
            desk.enabled = false;
        } 
        
    }
    public void EditableOrgans()
    {
        for (int i = 0; i < organs.Length; i++)
        {
            organs[i].transform.rotation = Quaternion.Euler(new Vector3(organs[i].transform.eulerAngles.x, sliderRotation.value, organs[i].transform.eulerAngles.z));
            organs[i].transform.localScale = new Vector3(sliderScale.value, sliderScale.value, sliderScale.value);
        }
    }

    public void EnableAnimation(int i)
    {
        if(i == 1){
            desk.enabled = true;
        }
        else
        {
            desk.enabled = false;
        }
    }
}
