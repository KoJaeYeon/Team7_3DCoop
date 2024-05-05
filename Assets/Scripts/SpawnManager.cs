using System.Collections;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public Transform[] itemSpawnTrans = new Transform[3];
    public Transform playerTrans;

    public float itemSpawnTimer = 5f;
    public float enemySpawnTimer = 1f;
    public float spawnSpeedMultiflier = 1f;

    private float enemyHelath = 1f;

    private int gameLevel = 1;


    private void Start()
    {
        StartCoroutine(SpawnItem());
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(itemSpawnTimer);
            SpawnItemPoint();
        } 
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SpawnEnemyPoint();
            yield return new WaitForSeconds(enemySpawnTimer * spawnSpeedMultiflier);
        }
    }
    public void SpawnItemPoint()
    {
        Debug.Log("Spawn");
        int count = Random.Range(1, 3); //1, 2
        if(count == 1)
        {
            GameObject itemBoxPrefab = PoolManager.Instance.GetItemBox();
            itemBoxPrefab.transform.position = itemSpawnTrans[Random.Range(0, 3)].position;
            Item item = itemBoxPrefab.GetComponent<Item>();
            item.SetBoxHp(Random.Range(1*gameLevel, 10*gameLevel));
            SetItem(item);
        }
        else // count = 2
        {
            int exceptNum = Random.Range(0, 3);
            for(int i = 0; i < 3; i++)
            {
                if (exceptNum == i) continue;
                GameObject itemBoxPrefab = PoolManager.Instance.GetItemBox();
                itemBoxPrefab.transform.position = itemSpawnTrans[i].position;
                Item item = itemBoxPrefab.GetComponent<Item>();
                item.SetBoxHp(Random.Range(1 * gameLevel, 10 * gameLevel));
                SetItem(item);
            }
        }
    }

    public void SetItem(Item item)
    {
        float random = Random.Range(0, 3);
        if(random < 1) // 플레이어 숫자
        {
            item.SetItem(false, false);
        }
        else if(random < 2)
        {
            item.SetItem(false, true);
        }
        else 
        {
            item.SetItem(true, false, WeaponRand());
        }
    }

    public void UpdateLevel(int level)
    {
        spawnSpeedMultiflier *= 0.9f;
        enemyHelath += 0.5f;
        enemyHelath *= 1.05f;
        gameLevel = level;
    }

    public void SpawnEnemyPoint()
    {
        //Debug.Log("SpawnEnemy");
        GameObject prefab = PoolManager.Instance.GetEnemy();
        prefab.transform.position = itemSpawnTrans[1].position + Vector3.right * Random.Range(-4,4);
        prefab.transform.eulerAngles = new Vector3(0,-180,0);
        Enemy enemy = prefab.GetComponent<Enemy>();
        enemy.PlayerTransform = playerTrans;
        enemy.SetHp(enemyHelath);
    }

    public WeaponType WeaponRand()
    {
        WeaponType weaponType;
        float random = Random.Range(0,100);
        switch(gameLevel)
        {
            case 1:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 40) { weaponType = WeaponType.SMG; }
                else if (random < 70) { weaponType = WeaponType.Bow; }
                else { weaponType = WeaponType.ThrowingStars; }
                break;
            case 2:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 30) { weaponType = WeaponType.SMG; }
                else if (random < 60) { weaponType = WeaponType.Bow; }
                else if (random < 95) { weaponType = WeaponType.ThrowingStars; }
                else { weaponType = WeaponType.MachineGun; }
                break;
            case 3:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 25) { weaponType = WeaponType.SMG; }
                else if (random < 55) { weaponType = WeaponType.Bow; }
                else if (random < 90) { weaponType = WeaponType.ThrowingStars; }
                else { weaponType = WeaponType.MachineGun; }
                break;
            case 4:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 25) { weaponType = WeaponType.SMG; }
                else if (random < 55) { weaponType = WeaponType.Bow; }
                else if (random < 86) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 94) { weaponType = WeaponType.MachineGun; }
                else { weaponType = WeaponType.Rifle; }
                break;
            case 5:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 25) { weaponType = WeaponType.SMG; }
                else if (random < 45) { weaponType = WeaponType.Bow; }
                else if (random < 80) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 90) { weaponType = WeaponType.MachineGun; }
                else { weaponType = WeaponType.Rifle; }
                break;
            case 6:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 20) { weaponType = WeaponType.SMG; }
                else if (random < 40) { weaponType = WeaponType.Bow; }
                else if (random < 60) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 75) { weaponType = WeaponType.MachineGun; }
                else if (random < 90) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
            case 7:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 15) { weaponType = WeaponType.SMG; }
                else if (random < 30) { weaponType = WeaponType.Bow; }
                else if (random < 55) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 70) { weaponType = WeaponType.MachineGun; }
                else if (random < 90) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
            case 8:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 10) { weaponType = WeaponType.SMG; }
                else if (random < 20) { weaponType = WeaponType.Bow; }
                else if (random < 30) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 55) { weaponType = WeaponType.MachineGun; }
                else if (random < 80) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
            case 9:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 10) { weaponType = WeaponType.SMG; }
                else if (random < 15) { weaponType = WeaponType.Bow; }
                else if (random < 25) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 45) { weaponType = WeaponType.MachineGun; }
                else if (random < 70) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
            case 10:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 10) { weaponType = WeaponType.SMG; }
                else if (random < 15) { weaponType = WeaponType.Bow; }
                else if (random < 20) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 50) { weaponType = WeaponType.MachineGun; }
                else if (random < 70) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
            default:
                if (random < 5) { weaponType = WeaponType.Revolver; }
                else if (random < 10) { weaponType = WeaponType.SMG; }
                else if (random < 15) { weaponType = WeaponType.Bow; }
                else if (random < 20) { weaponType = WeaponType.ThrowingStars; }
                else if (random < 45) { weaponType = WeaponType.MachineGun; }
                else if (random < 65) { weaponType = WeaponType.Rifle; }
                else { weaponType = WeaponType.RocketLauncher; }
                break;
        }

        return weaponType;
    }

}
