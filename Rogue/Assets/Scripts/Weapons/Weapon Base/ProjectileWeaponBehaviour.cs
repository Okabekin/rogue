using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base script for projectile weapons

public class ProjectileWeaponBehaviour : MonoBehaviour
{

    protected Vector3 direction;
    public float destroyAfterSeconds;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry== 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0)//down
        {
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        else if(dirx ==0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
            rotation.z = 0f;
        }
        else if( dir.x > 0 && dir.y > 0) //right up
        {
            rotation.z = -45f;
        }
        else if (dir.x > 0 && dir.y < 0) // right down
        {
            rotation.z = -135f;
        }
        else if (dir.x < 0 && dir.y > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -135f;
        }
        else if (dir.x < 0 && dir.y < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -45f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); // cant convert quaternion to vector 3
    }
}
