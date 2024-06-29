using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetRegistry
{
    public class Animal
    {
        public string Id { get; private set; }
        public string Owner { get; private set; }
        public string Birth { get; private set; }
        public string Name { get; private set; }
        public TypeOfAnimals? Type { get; set; } = null;
        public List<ListOfCommands> Command { get; set; } = new List<ListOfCommands>();

        public Animal (string id, string owner, string birth, string name)
        {
            Id = id;
            Owner = owner;
            Birth = birth;
            Name = name;
        }
        public void SetTypeOfAnimal(TypeOfAnimals typeOfAnimal)
        {
            Type = typeOfAnimal;
        }

        public void AddCommand(ListOfCommands command)
        {
            Command.Add((ListOfCommands)command);
        }

        public override string ToString()
        {
            string type;
            if(Type == null) type = string.Empty;
            else
            {
                 type = Type.Value.ToString();
            }

            string commands = string.Empty;
            foreach(ListOfCommands command in Command)
            {
                commands += $"{command} ";
            }
            return $"id = {Id} owner = {Owner} birth = {Birth} name = {Name} type = {type} commands = {commands}";
        }


    }
}
