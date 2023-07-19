using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    private static DataManager s_dataManager = new DataManager();
    private static ResourceManager s_resourceManager = new ResourceManager();
    private static EffectManager s_effectManager = new EffectManager();
    private static DungeonManager s_dungeonManager = new DungeonManager();

    public static DataManager Data { get { Init(); return s_dataManager; } }
    public static ResourceManager Resource { get { Init(); return s_resourceManager; } }
    public static EffectManager Effect { get { Init(); return s_effectManager; } }
    public static DungeonManager Dungeon { get { Init(); return s_dungeonManager; } }

    private void Start()
    {
        Init();
    }

    private static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("Managers");
            if (go == null)
            {
                go = new GameObject { name = "Managers" };
                go.AddComponent<Managers>();
            }
            s_instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);

            Data.Init();
            Resource.Init();
            Effect.Init();
            Dungeon.Init();
        }
    }
}