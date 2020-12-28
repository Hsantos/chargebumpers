using Photon.Pun;
public class CarPack : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        //safeguard
        if (!photonView.IsMine)
        {
            Destroy(GetComponent<CarPack>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
