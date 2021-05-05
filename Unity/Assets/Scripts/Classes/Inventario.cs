using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InventarioSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace InventarioSystem{
    public class Inventario: MonoBehaviour{
        public static Inventario Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                gameObject.SetActive(false);
                return;
            }
            Instance = this;
            List<Item> inventarioGeral = new List<Item>();
            List<GameObject> SlotsInventario = new List<GameObject>();
            List<GameObject> SlotsEquipados = new List<GameObject>();
            slot_inventario_count = 0;
            DontDestroyOnLoad(gameObject);
        }
        public Sprite spriteSlotPadraoInventario;
        public List<Item> inventarioGeral = new List<Item>();
        public List<GameObject> slotsInventaryGameObjects = new List<GameObject>();
        public List<GameObject> slotsEquipGameObjects = new List<GameObject>();
        private Dictionary<string, GameObject> SlotsInventario = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> SlotsEquipados = new Dictionary<string, GameObject>();
        private Dictionary<string, Item> ItemInventario = new Dictionary<string, Item>();
        private Dictionary<string, Item> ItemEquipado = new Dictionary<string, Item>();
        
        public List<GameObject> Buttons = new List<GameObject>();
        public GameObject inventarioGameObject;
        const int TOTAL_SLOTS_INVENTARIO = 6;
        const int TOTAL_SLOTS_EQUIPADOS = 4;
        private int slot_inventario_count = 0;
        void Start()
        {
            inventarioGameObject.SetActive(false);
            foreach(GameObject slot in slotsInventaryGameObjects)
            {
                int count = slotsInventaryGameObjects.IndexOf(slot);
                SlotsInventario[$"slot{count}"] = slot;
                SlotsInventario[$"slot{count}"].GetComponent<Button>().onClick.AddListener(delegate { EquiparItem($"slot{count}"); });
                ItemInventario[$"slot{count}"] = null;
            }
            foreach (GameObject slot in slotsEquipGameObjects)
            {
                int count = slotsEquipGameObjects.IndexOf(slot);
                SlotsEquipados[$"slot{count}"] = slot;
                ItemEquipado[$"slot{count}"] = null;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventarioGameObject.SetActive(!inventarioGameObject.activeInHierarchy);
            }
        }
        public void AdicionarItemInventarioGeral(Item item){
            
            inventarioGeral.Add(item);
            
        }
        private bool isEquipavelItem(string key){
            if(ItemInventario[key].Tipo == "equipavel")
            {
                
                return true;
            }
            return false;
        }
        private bool isConsumivelItem(string key)
        {
            if (ItemInventario[key].Tipo == "consumivel")
            {
                return true;
            }
            return false;
        }
        private bool isEmptySlot(string key){
            if (!ItemInventario.ContainsKey(key) || ItemInventario[key] == null)
            {
                return true;
            }
            return false;
        }

        public void EquiparItem(string key){
            
            if (isEmptySlot(key))
            {
                return;
            }
            if (!isEquipavelItem(key))
            {
                if (isConsumivelItem(key))
                {
                    SlotsInventario[key].GetComponent<Image>().sprite = spriteSlotPadraoInventario;
                    ItemInventario[key] = null;
                }
                return;
            }
            Item itemJaEquipado = null;
            string key_item_equipado = null;
            try
            {
                itemJaEquipado = ItemEquipado.FirstOrDefault(x => ((IEquipamento)x.Value).bodyPart == ((IEquipamento)ItemInventario[key]).bodyPart).Value;
                key_item_equipado = ItemEquipado.FirstOrDefault(x => ((IEquipamento)x.Value).bodyPart == ((IEquipamento)ItemInventario[key]).bodyPart).Key;
                print($"Nome item já equipado: {itemJaEquipado.Nome} | Key do item: {key_item_equipado}");
            }
            catch
            {
                
                print("Deu erro em alguma coisa ae");
            }
            
            if (isEquipamentosFull() && key_item_equipado == null)
            {
                return;
            }
            GameObject slot_position = new GameObject();
            string key2 = ItemEquipado.FirstOrDefault(x => x.Value == null).Key;
            print(key2);
            if (key_item_equipado != null)
            {
                key2 = key_item_equipado;
                slot_position = SlotsEquipados[key_item_equipado];
            }
            else
            {
                slot_position = SlotsEquipados[key2];
            }
            if (itemJaEquipado != null)
            {
                Image s = Instantiate(slot_position.GetComponent<Image>());
                slot_position.GetComponent<Image>().sprite = SlotsInventario[key].GetComponent<Image>().sprite;
                slot_position.GetComponent<Image>().sprite.name = SlotsInventario[key].GetComponent<Image>().sprite.name;
                SlotsInventario[key].GetComponent<Image>().sprite = s.sprite;
                SlotsInventario[key].GetComponent<Image>().sprite.name = s.sprite.name;
                Destroy(s.gameObject);
                key2 = ItemEquipado.First(x => ((IEquipamento)x.Value).bodyPart == ((IEquipamento)ItemInventario[key]).bodyPart).Key;
                int[] val = { 2, 2, 2, 2 };
                IEquipamento aux2 = new ItemGuerreiro(ItemEquipado[key2].Nome, ItemEquipado[key2].Tipo, "corpo", "guerra", val);
                aux2 = (IEquipamento) ItemEquipado[key2];
                ItemEquipado[key2] = (IEquipamento) ItemInventario[key];
                ItemInventario[key] = aux2;
                
            }
            else
            {
                try
                {
                    print($"Nome item já equipado: {itemJaEquipado.Nome} | Key do item: {key_item_equipado}");
                }
                catch
                {
                    print("Deu erro em alguma coisa ae");
                }
                if (!ItemEquipado.ContainsKey(key2) && ItemEquipado.Count <= TOTAL_SLOTS_INVENTARIO)
                {
                    ItemEquipado.Add(key2, ItemInventario[key]);
                }
                else
                {
                    key2 = ItemEquipado.FirstOrDefault(x => x.Value == null).Key;
                }
                print($"Key: {key} | {key2}");
                slot_position.GetComponent<Image>().sprite = SlotsInventario[key].GetComponent<Image>().sprite;
                SlotsInventario[key].GetComponent<Image>().sprite = spriteSlotPadraoInventario;
                ItemEquipado[key2] = (IEquipamento)ItemEquipado[key2];
                ItemEquipado[key2] = (IEquipamento) ItemInventario[key];
                ItemInventario[key] = null;
            }
        }

        public string ListarItensInventarioGeral(){
            string log = "___ITENS NO INVENTÁRIO GERAL___\n";
            if (inventarioGeral.Count == 0){
                log += "\nINVENTÁRIO VAZIO\n";
                return log;
            }
            foreach(Item i in inventarioGeral){
                log += $"{inventarioGeral.IndexOf(i)+1} - {i.Nome} | {i.Tipo}\n";
            }
            return log;
        }

        public void ListarItensDoTipo(string tipo){
            bool existItemType = false;
            inventarioGeral.ForEach(delegate(Item i)
            {
                if(i.Tipo == tipo.ToLower()){
                    Console.WriteLine($"{inventarioGeral.IndexOf(i)+1} - {i.Nome}\n");
                    existItemType = true;
                }
            });
            if (!existItemType){
                Console.WriteLine("Não há itens com este tipo no inventário!");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isInventarioFull())
                return;
            if (collision.CompareTag("equipavel"))
            {
                IEquipamento novoItem = collision.GetComponent<IEquipamento>();
                int[] atributos = { novoItem.STR, novoItem.AGI, novoItem.DEX, novoItem.LUK};
                ItemGuerreiro itemInfos = (ItemGuerreiro) SpawnManager.Instance.CriadorItensFase.criarItemGuerreiro(nome: novoItem.Nome, tipo: novoItem.Tipo, body: novoItem.bodyPart, classe: novoItem.Classe, atri: atributos);
                string key;
                key = ItemInventario.FirstOrDefault(x => x.Value == null).Key;
                ItemInventario[key] = itemInfos;
                GameObject slot_position = SlotsInventario[key];
                if (novoItem.SpriteItem == null)
                    novoItem.SpriteItem = collision.gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sprt = Instantiate(collision.gameObject.GetComponent<SpriteRenderer>());
                slot_position.GetComponent<Image>().sprite = sprt.sprite;
                Destroy(sprt);
                
            }
            if (collision.CompareTag("consumivel"))
            {
                IConsumivel novoItem = collision.GetComponent<IConsumivel>();
                string key;
                key = ItemInventario.FirstOrDefault(x => x.Value == null).Key;
                ItemInventario[key] = novoItem;
                GameObject slot_position = SlotsInventario[key];
                if (novoItem.SpriteItem == null)
                    novoItem.SpriteItem = collision.gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sprt = Instantiate(collision.gameObject.GetComponent<SpriteRenderer>());
                slot_position.GetComponent<Image>().sprite = sprt.sprite;
                Destroy(sprt);
            }
            if (collision.CompareTag("inutil"))
            {
                Inutil novoItem = collision.GetComponent<Inutil>();
                string key;
                key = ItemInventario.FirstOrDefault(x => x.Value == null).Key;
                ItemInventario[key] = novoItem;
                GameObject slot_position = SlotsInventario[key];
                if (novoItem.SpriteItem == null)
                    novoItem.SpriteItem = collision.gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sprt = Instantiate(collision.gameObject.GetComponent<SpriteRenderer>());
                slot_position.GetComponent<Image>().sprite = sprt.sprite;
                Destroy(sprt);
            }
        }
        public string GetInfoItem(string key)
        {
            if (isEmptySlot(key))
                return "\t___SLOT VAZIO__";
            IEquipamento equip = (IEquipamento)ItemInventario[key];
            string infos = $"Nome: {equip.Nome}\n\t_____ATRIBUTOS____\nSTR: {equip.STR}\nAGI: {equip.AGI}\nDEX: {equip.DEX}\nLUK: {equip.LUK}";
            return infos;
        }
        public bool isInventarioFull()
        {
            
            bool slot = ItemInventario.All( x=> x.Value != null);
            if (slot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEquipamentosFull()
        {

            bool slot = ItemEquipado.All(x => x.Value != null);
            if (slot)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}