using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InventarioSystem;
using UnityEngine.UI;
namespace InventarioSystem{
    public class Inventario: MonoBehaviour{
        public List<Item> inventarioGeral = new List<Item>();
        public List<IEquipamento> inventarioEquipamento = new List<IEquipamento>();
        public List<GameObject> SlotsInventario = new List<GameObject>();
        public GameObject inventarioGameObject;
        const int TOTAL_SLOTS = 6;
        private int slot = 0;

        void Start()
        {
            inventarioGameObject.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventarioGameObject.SetActive(!inventarioGameObject.activeInHierarchy);
            }
        }
        public void AdicionarItemInventarioGeral(GameObject item){
            if (slot >= TOTAL_SLOTS)
                return;
            GameObject item_remover = SlotsInventario[slot];
           
            //item_remover.transform.localScale = new Vector3(0.229515254f, 0.291273266f, 0.625076115f);
            //item_remover.transform.localPosition -= new Vector3(0.22f, 0.28f, 0f);
            item_remover.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            Button item_btn = item_remover.GetComponent<Button>();
            item_btn.onClick.AddListener(teste);
            slot++;
        }
        public void teste()
        {
            print("Oi");
        }
        private bool isEquipavelItem(int index){
            if(inventarioGeral[index].Tipo != "equipavel"){
                
                return false;
            }
            return true;
        }

        private bool isValidIndexItem(int index){
            if (index > inventarioGeral.Count-1 || index < 0){
                return false;
            }
            return true;
        }
        public void EquiparItem(int index){
            index--;
            if(!isValidIndexItem(index)){
                return;
            }
            if(!isEquipavelItem(index)){
                Console.WriteLine("Este item não é equipável!");
                return;
            }
            IEquipamento item = (IEquipamento) inventarioGeral[index];
            Item removerItemEquipado = inventarioEquipamento.Find(x => x.bodyPart == item.bodyPart);
            if (removerItemEquipado != null){
                inventarioEquipamento.Remove((IEquipamento)removerItemEquipado);
                inventarioGeral.Add(removerItemEquipado);
            }
            inventarioEquipamento.Add(item);
            inventarioGeral.RemoveAt(index);
        }

        public void ListarItensInventarioGeral(){
            if(inventarioGeral.Count == 0){
                Console.WriteLine("\nINVENTÁRIO VAZIO\n");
                return;
            }
            Console.WriteLine("___ITENS NO INVENTÁRIO GERAL___\n");
            foreach(Item i in inventarioGeral){
                Console.WriteLine($"{inventarioGeral.IndexOf(i)+1} - {i.Nome}\n");
            }
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
            if (collision.CompareTag("equipavel"))
            {
                AdicionarItemInventarioGeral(collision.gameObject);
            }
            
        }


    }
}