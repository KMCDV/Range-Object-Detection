using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string ObjectName = "Interactive object";
    // Start is called before the first frame update
    private void Start()
    {
        //C# Actions -> If you subscribe to it with += you have to unsubscribe with -=
        InteractiveObjectFinder.MyEvent += OnFinderActivated;
    }

    private void OnFinderActivated(Transform sender)
    {
        if (Vector3.Distance(sender.position, transform.position) > 10f)
        {
            Debug.Log("I am too far " + ObjectName);
            return;
        }
        Debug.Log("I heard you!" + ObjectName);
    }

    private void OnDestroy()
    {
        InteractiveObjectFinder.MyEvent -= OnFinderActivated;
    }
}
