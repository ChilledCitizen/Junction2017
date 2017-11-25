using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

   // public SceneManager sceneManager;
    private Scene scene;
    public float loadTime,treeStartPos;
    public Image img;
    public Animator anim;
    public Text txt;
    public PlayerController playerController;
    public GameObject mapStart, mapEnd, tree, player;
    public float treeWidth;

    [HideInInspector]
    public Vector3 mapDistance;
    


    // Use this for initialization

    private void Awake()
    {

        scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 0)
        {
            img.gameObject.SetActive(true);
        }
        
        Instantiate(player, new Vector3(0, 0.28f, 6.5f), Quaternion.identity);
    }


    void Start () {

        
        anim = img.GetComponent<Animator>();
        playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        txt.enabled = false;
        mapStart = GameObject.Find("MapStartPoint");
        mapEnd = GameObject.Find("MapEndPoint");
        

        mapDistance = mapEnd.transform.position - mapStart.transform.position;
        Vector3 mapNorm = mapDistance.normalized;

        

        for (float i = 0; i < mapDistance.magnitude; i += treeWidth)
        {

            Instantiate(tree, new Vector3(mapStart.transform.position.x, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90,0,0));
            Instantiate(tree, new Vector3(mapStart.transform.position.x-treeStartPos, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90, 0, 0));

        }

        
    }
	
	// Update is called once per frame
	void Update () {

        if (!playerController)
        {
            playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        }

            
        if (playerController.debugEnabled)
        {
            txt.enabled = true;
        }

        else
        {
            txt.enabled = false;
        }

        


		
	}


    public void GoToGameScene()
    { 
        StartCoroutine(LoadScene(1, true));
        
    }

    public void GoToScoreScene()
    {
        StartCoroutine(LoadScene(2, true));
    }


    IEnumerator LoadScene(int sceneIndex, bool fadeInOut)
    {
        anim.SetBool("FadingOut", true);
        yield return new WaitForSeconds(loadTime);

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

  

}
