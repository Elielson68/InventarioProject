using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventarioSystem;
public class InventarioFase : MonoBehaviour
{
    public static InventarioFase Instance { get; private set; }
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            CriadorItensFase = null;
            CriadorItensFase_2 = null;
            gameObject.SetActive(false);
            return;
        }
        Instance = this;
        
        CriadorItensFase = new FerreiroDeGuerreiro();
        CriadorItensFase_2 = new FerreiroDeBarbaro();
        DontDestroyOnLoad(gameObject);
    }

    public GameObject spawnItens;
    public FerreiroDeGuerreiro CriadorItensFase;
    public FerreiroDeBarbaro CriadorItensFase_2;
    public void Start()
    {
        CriadorItensFase = new FerreiroDeGuerreiro();
        CriadorItensFase_2 = new FerreiroDeBarbaro();
        
        CriadorItensFase.criarHelmo(spawnItens);
        spawnItens.transform.Translate(2, 0, 0);

        CriadorItensFase_2.criarHelmo(spawnItens);
        spawnItens.transform.Translate(2, 0, 0);

        CriadorItensFase.criarEspada(spawnItens);
        spawnItens.transform.Translate(2, 0, 0);

        CriadorItensFase.criarLuva(spawnItens);
        spawnItens.transform.Translate(2, 0, 0);

        CriadorItensFase.criarBota(spawnItens);
        spawnItens.transform.Translate(-2, 5, 0);
        CriadorItensFase.criarArmadura(spawnItens);
        
        spawnItens.transform.Translate(-4, 3, 0);

        CriadorItensFase.criarHelmo(spawnItens);
    }


}
