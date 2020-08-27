using UnityEngine;

public class ComicPageCam : MonoBehaviour
{
    public GameObject cam;
    public GameObject[] wayPoints;
    public GameObject[] lookAtPoints;
    public int intCurrentPoint;
    public float speed = 1f;

    private Vector3 currentPos;
    private Vector3 currentLookAt;
    private Vector3 nextPos;
    private Vector3 nextLookAt;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        if (this.wayPoints.Length > intCurrentPoint)
        {
            this.currentPos = this.wayPoints[intCurrentPoint].transform.position;
            this.currentLookAt = this.lookAtPoints[this.intCurrentPoint].transform.position;
            this.nextPos = this.wayPoints[this.intCurrentPoint].transform.position;
            this.nextLookAt = this.lookAtPoints[this.intCurrentPoint].transform.position;
            this.cam.transform.position = this.currentPos;
            this.cam.transform.LookAt(this.currentLookAt);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.intCurrentPoint++;
            Debug.Log(string.Format("Current point {0}", this.intCurrentPoint));
            if (this.intCurrentPoint >= this.wayPoints.Length)
            {
                //end of the line
            }
            else
            {
                this.nextPos = this.wayPoints[this.intCurrentPoint].transform.position;
                this.nextLookAt = this.lookAtPoints[this.intCurrentPoint].transform.position;
            }
        }

        this.currentPos = Vector3.Lerp(this.currentPos, this.nextPos, Time.deltaTime * this.speed);
        this.currentLookAt = Vector3.Lerp(this.currentLookAt, this.nextLookAt, Time.deltaTime * this.speed);

        this.cam.transform.position = this.currentPos;
        this.cam.transform.LookAt(this.currentLookAt);
      
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for(int i = 1; i < this.wayPoints.Length; i++)
        {
            Gizmos.DrawLine(this.wayPoints[i - 1].transform.position, this.wayPoints[i].transform.position);
        }
        Gizmos.color = Color.red;
        for (int i = 1; i < this.lookAtPoints.Length; i++)
        {
            Gizmos.DrawLine(this.lookAtPoints[i - 1].transform.position, this.lookAtPoints[i].transform.position);
        }
    }
}
