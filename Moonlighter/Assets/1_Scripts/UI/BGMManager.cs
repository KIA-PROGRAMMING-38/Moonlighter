using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip NormalBGM;
    public AudioClip BossBGM;
    public Player PlayerRef;

    public bool IsChanged;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        AudioSource.clip = NormalBGM;
        AudioSource.Play();
    }

    private void Update()
    {
        if(false == IsChanged && PlayerRef.NowRoomType == EnumValue.RoomType.BossRoom)
        {
            AudioSource.clip = BossBGM;
            AudioSource.Play();
            IsChanged = true;
        }
    }
}
