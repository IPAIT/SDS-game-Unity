using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform[] transforms = new Transform[3];

    public float speed = 5.0f; 
    private void Update()
    {
        for(int i = 0; i < transforms.Length; i ++) {
            transforms[i].Translate(new Vector3(1,0,0) * 5.0f * speed * Time.deltaTime);
        }
    }




}
