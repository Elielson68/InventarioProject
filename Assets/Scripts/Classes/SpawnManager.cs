using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventarioSystem;
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject spawnItens;
    public FerreiroDeGuerreiro CriadorItensFase;
    public FerreiroDeBarbaro CriadorItensFase_2;
    public MercadoVila MercadoDaDonaMaria;
    public SpawnLixo Inutilidades;
    public List<Vector3> itens_positions;
    public void Start()
    {
        itens_positions = new List<Vector3>();
        CriadorItensFase = new FerreiroDeGuerreiro();
        CriadorItensFase_2 = new FerreiroDeBarbaro();
        MercadoDaDonaMaria = new MercadoVila();
        Inutilidades = new SpawnLixo();

        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarHelmo(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase_2.criarHelmo(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarEspada(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarLuva(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarBota(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarArmadura(spawnItens);
        StartCoroutine(RandomizarSpawn());
        CriadorItensFase.criarHelmo(spawnItens);
        StartCoroutine(RandomizarSpawn());
        MercadoDaDonaMaria.criarPoteVida(spawnItens);
        StartCoroutine(RandomizarSpawn());
        MercadoDaDonaMaria.criarPoteMana(spawnItens);
        StartCoroutine(RandomizarSpawn());
        Inutilidades.criarOvelha(spawnItens);

    }

    public IEnumerator RandomizarSpawn()
    {
        float x = Random.Range(-2.95f, 7);
        float y = Random.Range(-3.48f, 2.35f);
        Vector3 Position = new Vector3(x, y, 0);
        if (itens_positions.Count > 0)
        {

            while (itens_positions.Exists(delegate (Vector3 x) {
                print(Vector3.Distance(x, Position));
                return Vector3.Distance(x, Position) < 2;
            }))
            {
                x = Random.Range(-2.95f, 7);
                y = Random.Range(-3.48f, 2.35f);
                Position = new Vector3(x, y, 0);
            }
        }
        itens_positions.Add(Position);
        spawnItens.transform.position = Position;
        yield return null;
    }


}
