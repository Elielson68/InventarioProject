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
            List<IEquipamento> inventarioEquipamento = new List<IEquipamento>();
            List<GameObject> SlotsInventario = new List<GameObject>();
            List<GameObject> SlotsEquipados = new List<GameObject>();
            slot_inventario_count = 0;
            DontDestroyOnLoad(gameObject);
        }
        public Sprite spriteSlotPadraoInventario;
        public List<Item> inventarioGeral = new List<Item>();
        public List<IEquipamento> inventarioEquipamento = new List<IEquipamento>();
        public List<GameObject> slotsGameObject = new List<GameObject>();
        private Dictionary<string, GameObject> SlotsInventario = new Dictionary<string, GameObject>();
        private Dictionary<string, Item> ItemInventario = new Dictionary<string, Item>();
        private Dictionary<string, Item> ItemEquipado = new Dictionary<string, Item>();
        public List<GameObject> SlotsEquipados = new List<GameObject>();
        public List<GameObject> Buttons = new List<GameObject>();
        public GameObject inventarioGameObject;
        const int TOTAL_SLOTS_INVENTARIO = 5;
        const int TOTAL_SLOTS_EQUIPADOS = 4;
        private int slot_inventario_count = 0;
        void Start()
        {
            inventarioGameObject.SetActive(false);
            foreach(GameObject slot in slotsGameObject)
            {
                int count = slotsGameObject.IndexOf(slot);
                SlotsInventario[$"slot{count}"] = slot;
                SlotsInventario[$"slot{count}"].GetComponent<Button>().onClick.AddListener(delegate { EquiparItem($"slot{count}"); });
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
            print(ListarItensInventarioGeral());
            
        }
        private bool isEquipavelItem(int index){
            if(inventarioGeral[index].Tipo != "equipavel"){
                
                return false;
            }
            return true;
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
            Item itemJaEquipado = ItemEquipado.FirstOrDefault(x => ((IEquipamento)x.Value).bodyPart == ((IEquipamento)ItemInventario[key]).bodyPart).Value;
            if (ItemEquipado.Count >= 5 && itemJaEquipado == null)
            {
                return;
            }
            string key2 = $"slot{ItemEquipado.Count}";
            print($"Equipamento Count: {ItemEquipado.Count}");
            string key_item_equipado = ItemEquipado.FirstOrDefault(x => ((IEquipamento)x.Value).bodyPart == ((IEquipamento)ItemInventario[key]).bodyPart).Key;
            key_item_equipado = key_item_equipado.Replace("slot", "");
            int index = int.Parse(key_item_equipado);
            GameObject slot_position = SlotsEquipados[index];
            
            if (itemJaEquipado != null)
            {
                print("Oi");
                
                Image s = Instantiate(slot_position.GetComponent<Image>());
                print(SlotsInventario[key].GetComponent<Image>());
                slot_position.GetComponent<Image>().sprite = SlotsInventario[key].GetComponent<Image>().sprite;
                slot_position.GetComponent<Image>().sprite.name = SlotsInventario[key].GetComponent<Image>().sprite.name;
                SlotsInventario[key].GetComponent<Image>().sprite = s.sprite;
                SlotsInventario[key].GetComponent<Image>().sprite.name = s.sprite.name;
                Destroy(s.gameObject);
                key2 = ItemEquipado.First(x => x.Value.Tipo == ItemInventario[key].Tipo).Key;
                int[] val = { 2, 2, 2, 2 };
                Item aux2 = new ItemGuerreiro(ItemEquipado[key2].Nome, ItemEquipado[key2].Tipo, "corpo", "guerra", val);
                aux2 = ItemEquipado[key2];
                ItemEquipado[key2] = ItemInventario[key];
                ItemInventario[key] = aux2;
                
            }
            else
            {
                if (!ItemEquipado.ContainsKey(key2) && ItemEquipado.Count <= TOTAL_SLOTS_INVENTARIO)
                {
                    ItemEquipado.Add(key2, ItemInventario[key]);
                }
                else
                {
                    key2 = ItemEquipado.FirstOrDefault(x => x.Value == null).Key;
                    print(key2);
                }
                slot_position.GetComponent<Image>().sprite = SlotsInventario[key].GetComponent<Image>().sprite;
                SlotsInventario[key].GetComponent<Image>().sprite = spriteSlotPadraoInventario;
                
                ItemEquipado[key2] = ItemInventario[key];
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

        public void ListarItensInventarioEquipamento(){
            Console.WriteLine("___ITENS NOS EQUIPADOS___\n");
            if(inventarioEquipamento.Count == 0){
                Console.WriteLine("\nINVENTÁRIO VAZIO\n");
                return;
            }
            foreach(IEquipamento i in inventarioEquipamento){
                Console.WriteLine($"{inventarioEquipamento.IndexOf(i)+1} - {i.Nome}\n");
            }
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
            if (slot_inventario_count >= TOTAL_SLOTS_INVENTARIO)
                return;
            if (collision.CompareTag("equipavel"))
            {
                IEquipamento novoItem = collision.GetComponent<IEquipamento>();
                int[] atributos = { novoItem.STR, novoItem.AGI, novoItem.DEX, novoItem.LUK};
                
                ItemGuerreiro itemInfos = (ItemGuerreiro) InventarioFase.Instance.CriadorItensFase.criarItemGuerreiro(nome: novoItem.Nome, tipo: novoItem.Tipo, body: novoItem.bodyPart, classe: novoItem.Classe, atri: atributos);
                string key = $"slot{ItemInventario.Count}";
                if (!ItemInventario.ContainsKey(key) && ItemInventario.Count <= TOTAL_SLOTS_INVENTARIO)
                {
                    ItemInventario.Add(key, itemInfos);
                }
                else
                {
                    key = ItemInventario.FirstOrDefault(x => x.Value == null).Key;
                    ItemInventario[key] = itemInfos;
                }
                
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
        public void meudeus()
        {
            print("AAAAAAAAAAAAH");
        }
    }
}