using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // public SceneManager sceneManager;
    private Scene scene;
    public float loadTime, treeStartPos, fenceStartPos;
    public Image img;
    public Animator anim;
    public Text txt;
    public PlayerController playerController;
    public GameObject mapStart, mapEnd, tree, player, fence, beer, coffee;
    public float treeWidth, spawnHeight, fenceWidth;

    [HideInInspector]
    public Vector3 mapDistance;



    // Use this for initialization

    private void Awake()
    {
        //DontDestroyOnLoad(this);

        scene = SceneManager.GetActiveScene();
        //anim = img.GetComponent<Animator>();

        Debug.Log("Hello");

       
            //img.gameObject.SetActive(true);
        
     
            Instantiate(player, new Vector3(0, spawnHeight, 6.5f), Quaternion.identity);







            //txt.enabled = false;

            Debug.Log("adasdasd");




            mapStart = GameObject.Find("MapStartPoint");
            mapEnd = GameObject.Find("MapEndPoint");
            playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
            mapDistance = mapEnd.transform.position - mapStart.transform.position;
            Vector3 mapNorm = mapDistance.normalized;








            for (float i = 0; i < mapDistance.magnitude; i += treeWidth)
            {
                Debug.Log("aaaaa");
                Instantiate(tree, new Vector3(mapStart.transform.position.x, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90, 0, 0));
                Instantiate(tree, new Vector3(mapStart.transform.position.x - treeStartPos, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90, 0, 0));

            }
            for (float i = 0; i < mapDistance.magnitude; i += fenceWidth)
            {
                Instantiate(fence, new Vector3(mapStart.transform.position.x + 1, mapStart.transform.position.y + 0.5f, mapNorm.z + i), Quaternion.Euler(-90, 90, 0));
                Instantiate(fence, new Vector3(mapStart.transform.position.x + fenceStartPos, mapStart.transform.position.y + 0.5f, mapNorm.z + i), Quaternion.Euler(-90, -90, 0));

            }


        



    }


    void Start()
    {
        //scene = SceneManager.GetActiveScene();
        //anim = img.GetComponent<Animator>();

        //Debug.Log("Hello");

        //if (scene.buildIndex == 0)
        //{
        //    img.gameObject.SetActive(true);
        //}
        //if (scene.name == "Gameplay")
        //{
        //    Instantiate(player, new Vector3(0, spawnHeight, 6.5f), Quaternion.identity);





            

        //    //txt.enabled = false;

        //    Debug.Log("adasdasd");




        //    mapStart = GameObject.Find("MapStartPoint");
        //    mapEnd = GameObject.Find("MapEndPoint");
        //    playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        //    mapDistance = mapEnd.transform.position - mapStart.transform.position;
        //    Vector3 mapNorm = mapDistance.normalized;








        //    for (float i = 0; i < mapDistance.magnitude; i += treeWidth)
        //    {
        //        Debug.Log("aaaaa");
        //        Instantiate(tree, new Vector3(mapStart.transform.position.x, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90, 0, 0));
        //        Instantiate(tree, new Vector3(mapStart.transform.position.x - treeStartPos, mapStart.transform.position.y + 1, mapNorm.z + i), Quaternion.Euler(-90, 0, 0));

        //    }
        //    for (float i = 0; i < mapDistance.magnitude; i += fenceWidth)
        //    {
        //        Instantiate(fence, new Vector3(mapStart.transform.position.x + 1, mapStart.transform.position.y + 0.5f, mapNorm.z + i), Quaternion.Euler(-90, 90, 0));
        //        Instantiate(fence, new Vector3(mapStart.transform.position.x + fenceStartPos, mapStart.transform.position.y + 0.5f, mapNorm.z + i), Quaternion.Euler(-90, -90, 0));

        //    }


        //}
    }

    // Update is called once per frame
    void Update()
    {

            if (!playerController)
            {
                playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
            }


        //if (playerController.debugEnabled)
        //{
        //    txt.enabled = true;
        //}

        //else
        //{
        //    txt.enabled = false;
        //}


        Debug.Log("dasdasdadaddd");


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

        SceneManager.LoadScene(sceneIndex);
    }



}
