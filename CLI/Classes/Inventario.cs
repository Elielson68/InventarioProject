using System;
using System.Collections.Generic;
using System.Linq;
namespace InventarioSystem{
    public class Inventario{
        public List<Item> inventarioGeral = new List<Item>();
        public List<IEquipamento> inventarioEquipamento = new List<IEquipamento>();

        public void AdicionarItemInventarioGeral(Item item){
            inventarioGeral.Add(item);
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

        
    }
}