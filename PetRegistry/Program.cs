using PetRegistry;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> listOfAnimals = new List<Animal>();

        do
        {
            PrintMenu();
            if (int.TryParse(Console.ReadLine(), out int item))
            {
                switch (item)
                {
                    case 1:
                        Console.WriteLine("Введите Id:");
                        var id = Console.ReadLine();
                        Console.WriteLine("Введите имя владельца:");
                        var owner = Console.ReadLine();
                        Console.WriteLine("Введите год рождения:");
                        var year = Console.ReadLine();
                        Console.WriteLine("Введите имя животного:");
                        var name = Console.ReadLine();
                        listOfAnimals.Add(new Animal(id, owner, year, name));                       
                        break;
                    case 2:
                        if (listOfAnimals.Count > 0)
                        {
                            Console.WriteLine("\nВыберите животное:\n");
                            PrintListOfAnimals(listOfAnimals);

                            if (!int.TryParse(Console.ReadLine(), out int tmp) || tmp > listOfAnimals.Count || tmp < 1)
                            {
                                WrongMenuSelected();
                                break;
                            }
                            var animal = listOfAnimals[tmp-1];

                            Console.WriteLine($"Выберите вид животного:\n 1. {TypeOfAnimals.Cat}\n 2. {TypeOfAnimals.Dog}\n 3. {TypeOfAnimals.Hamster}\n 4. {TypeOfAnimals.Horse}\n 5. {TypeOfAnimals.Dankey}\n");

                            if (!int.TryParse(Console.ReadLine(), out int tmp2) || tmp2 > Enum.GetNames(typeof(TypeOfAnimals)).Length || tmp2 < 1)
                            {
                                WrongMenuSelected();
                                break;
                            }
                            var typeOfAnimal = (TypeOfAnimals)Enum.GetValues(typeof(TypeOfAnimals)).GetValue(tmp2 - 1);
                            animal.SetTypeOfAnimal(typeOfAnimal);

                        }
                        else NoOneAnimal();
                        break;
                    case 3:
                        if (listOfAnimals.Count > 0)
                        {
                            PrintListOfAnimals(listOfAnimals);
                        }
                        else NoOneAnimal();
                        break;
                    case 4:
                        if (listOfAnimals.Count > 0)
                        {
                            Console.WriteLine("\nВыберите животное:\n");
                            PrintListOfAnimals(listOfAnimals);
                            if (!int.TryParse(Console.ReadLine(), out int tmp) || tmp > listOfAnimals.Count || tmp < 1)
                            {
                                WrongMenuSelected();
                                break;
                            }
                            var animal = listOfAnimals[tmp - 1];

                            Console.WriteLine($"Выберите команду:\n 1. {ListOfCommands.Sit}\n 2. {ListOfCommands.Lie}\n 3. {ListOfCommands.Voice}\n 4. {ListOfCommands.Down}\n 5. {ListOfCommands.Go}\n 6. {ListOfCommands.Run}\n");

                            if (!int.TryParse(Console.ReadLine(), out int tmp2) || tmp2 > Enum.GetNames(typeof(ListOfCommands)).Length || tmp2 < 1)
                            {
                                WrongMenuSelected();
                                break;
                            }
                            var command = (ListOfCommands)Enum.GetValues(typeof(ListOfCommands)).GetValue(tmp2 - 1);
                            animal.AddCommand(command);
                        }
                        else NoOneAnimal();
                        break;
                }
            }
            else
            {
                WrongMenuSelected();
            }
        }while (true);


    }

    private static void PrintMenu()
    {
        Console.WriteLine("\nВыберите действие: \n1. Завести новое животное\n2. Определять животное в правильный класс\n3. Увидеть список животных с командами\n4. Обучить животное новым командам");
    }

    private static void PrintListOfAnimals(List<Animal> listOfAnimals)
    {
        for (int i = 0; i < listOfAnimals.Count; i++)
        {
            Console.Write($"{i+1}. {listOfAnimals[i].ToString()}\n");
        }
    }

    private static void WrongMenuSelected()
    {
        Console.WriteLine("Не верно выбран пункт меню. Попробуйте снова.");
    }

    private static void NoOneAnimal()
    {
        Console.WriteLine("Не добавлено ни одного животного");
    }
}