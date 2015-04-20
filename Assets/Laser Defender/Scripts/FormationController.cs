using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour
{


    public GameObject enemyPrefab;
    public float speed;
    public float width = 10, height = 5;
    public float padding = 1;
    public float spawnDelaySeconds = 1f;
    private float boundaryLeftEdge, boundaryRightEdge;
    private int direction = 1;
    public static GameObject enemy;

    // Use this for initialization



    void Start()
    {

        Camera cam = Camera.main;
        float distance = transform.position.z - cam.transform.position.z;

        boundaryLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        boundaryRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;

        SpawnUntilFull();
    }

    void CreateFormation()
    {
        foreach (Transform child in transform) //for every item child of type Transform in this gameObject's transform
        {
            enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject; 
            enemy.transform.parent = child.transform; //parintele lui enemy sunt eu, transformul atasat acestui GameObject (EnemySpawner) (scriptul)
        }
    }
    
    void OnDrawGizmos()
    {
        float xmin, xmax, ymin, ymax;

        xmin = transform.position.x - 0.5f * width;
        xmax = transform.position.x + 0.5f * width;
        ymin = transform.position.y - 0.5f * height;
        ymax = transform.position.y + 0.5f * height;

        Gizmos.DrawLine(new Vector3(xmin, ymin, 0), new Vector3(xmin, ymax));
        Gizmos.DrawLine(new Vector3(xmin, ymax, 0), new Vector3(xmax, ymax));
        Gizmos.DrawLine(new Vector3(xmax, ymax, 0), new Vector3(xmax, ymin));
        Gizmos.DrawLine(new Vector3(xmax, ymin, 0), new Vector3(xmin, ymin));
    }

   
   

    // Update is called once per frame
    void Update()
    {

        float formationRightEdge = transform.position.x + 0.5f * width;
        float formationLeftEdge = transform.position.x - 0.5f * width;

        if (formationRightEdge > boundaryRightEdge)
        {
            direction = -1;
        }
        if (formationLeftEdge < boundaryLeftEdge)
        {
            direction = 1;
        }
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);


        //----------------------------------------------//

        if(AllMembersAreDead())
        {
            Debug.Log("MY FORMATION IS EMPTY :(");
            SpawnUntilFull();
        }


    }

    bool AllMembersAreDead()
    {
        foreach(Transform position in transform) // pt fiecare position in transformul lui formation controller
        {
            
            if(position.childCount > 0) //daca pozitie mai are vreun copil de tip Enemy
            {
                
                return false; //returneaza fals
            }
        }
        return true; //altfel pentru ca nu se mai afla copii pe nici o pozitie atunci da adevarat ca au murit toti
    }

    void SpawnUntilFull()
    {
        Transform freePos = NextFreePosition(); //cream un Transform numit freePos caruia ii este alocat pozitionul care este liber
        enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject; //instantiem un inamic pe pozitia libera Freepos
        enemy.transform.parent = freePos.transform; //parintele lui enemy este pozitia libera
        if(FreePositionExists()) //daca mai exista pozitii libere da-i drumu
        {
            Invoke("SpawnUntilFull", spawnDelaySeconds);
        }
    }

    Transform NextFreePosition(){
        foreach(Transform position in transform) //pentru fiecare Transform in transform-ul lui FormationController
        {
            if(position.childCount <= 0) //daca au murit toti copii
            {
                return position; //da inapoi position-ul
            }
        }
        return null;
    }

    bool FreePositionExists()
    {
        foreach(Transform position in transform)
        {
            if(position.childCount <= 0)
            {
                return true;
            }
        }
        return false;
    }





}


