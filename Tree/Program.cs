using CustomLibrary;
namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int answer = 0;
            Tree<Emoji> tree = new Tree<Emoji>(1);
            int number = 0;
            int currentTree = 0;

            while (true)
            {
                number = 0;
                Console.WriteLine("Данная программа осуществляет действия над деревом.");
                Console.WriteLine("Список инициализированных деревеьев:");
                foreach (var item in Tree<Emoji>.list)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"{number + 1}) Дерево#{item.Id}");
                        number++;
                    }
                }

                if (number > 0)
                {
                    Console.WriteLine("Выберете над каким деревом будете совершать действия:");
                    currentTree = ChooseAnswer(1, number);
                    Console.Clear();

                    if (tree.Count > 0)
                    {
                        Console.Write($"На данный момент в дереве {Tree<Emoji>.list[currentTree-1].Count} элементов\n");
                    }
                    else
                    {
                        Console.Write($"На данный момент в дереве нет элементов\n");
                    }
                    Console.WriteLine("Выберите одно из действий над таблицей\n");

                    Console.WriteLine("1) Распечатать дерево");
                    Console.WriteLine("2) Инициализиоровать случайными элементами ИСД");
                    Console.WriteLine("3) Конвертировать в дерево поиска");
                    Console.WriteLine("4) Удалить объект (предварительно нужно конвертировать в дерево поиска)");
                    Console.WriteLine("5) Посчитать глубину дерева");
                    Console.WriteLine("6) Удалить дерево");

                    answer = ChooseAnswer(1, 6);
                    switch (answer)
                    {
                        case 1:
                            Console.Clear();
                            Tree<Emoji>.list[currentTree - 1].Show(Tree<Emoji>.list[currentTree - 1].root);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("На сколько элементов построить дерево?");
                            answer = ChooseAnswer(0, 1000);
                            Tree<Emoji>.list[currentTree - 1].Init(answer);
                            //tree.Clear();
                            //Tree<Emoji> newTree = new Tree<Emoji>(answer);
                            //tree = newTree;
                            Console.Clear();
                            Console.WriteLine("Дерево успешно проинициализировано");
                            break;

                        case 3:
                            Console.Clear();
                            Tree<Emoji> newTree = new Tree<Emoji>(0);
                            newTree.ToSearchTree(Tree<Emoji>.list[currentTree - 1]);
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Введите имя объекта для удаления:");
                            string name = Console.ReadLine();
                            Emoji target = new Emoji();
                            target.RandomInit();
                            target.Name = name;
                            if(Tree<Emoji>.list[currentTree - 1].Remove(target))
                            {
                                Console.WriteLine("Объект удален");
                            }
                            else
                            {
                                Console.WriteLine("Объекта с таким именем нет в дереве.");
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine($"Глубина текущего дерева равна {tree.Depth(tree.root)}");
                            break;

                        case 6: 
                            Console.Clear();
                            Tree<Emoji>.list.RemoveAt(currentTree - 1);
                            Console.WriteLine("Дерево удалено");
                            break;

                        default: break;

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Нет созданных деревьев. Для продолжения работы создайте новое дерево(просто укажите его длину):");
                    int lenght = ChooseAnswer(0, 100);
                    Tree<Emoji> tree1 = new Tree<Emoji>(lenght);
                }
            }
        }

        static int ChooseAnswer(int a, int b)   //выбор действия из целых
        {
            int answer = 0;
            bool checkAnswer;
            do
            {
                checkAnswer = int.TryParse(Console.ReadLine(), out answer);
                if ((answer > b || answer < a) || (!checkAnswer))
                {
                    Console.WriteLine("Вы некорректно ввели число, повторите ввод еще раз. Обратите внимание на то, что именно нужно ввести.");
                }
            } while ((answer > b || answer < a) || (!checkAnswer));

            return answer;
        }
    }
}
