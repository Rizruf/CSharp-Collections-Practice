using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice
{
    internal class ListTasks
    {
        public void ListMerge()
        {
            List<int> l1 = new List<int>() { 1, 2, 3 };
            List<int> l2 = new List<int>() { 2, 3, 4, 5 };

            List<int> merges = new List<int>();

            merges.AddRange(l1);
            merges.AddRange(l2);

            foreach (int item in merges) Console.Write($"{item} ");

            Console.WriteLine();

            List<int> final = merges.Distinct().ToList(); ;

            foreach (int item in final) Console.Write($"{item} ");
        }

        public void ToDoList()
        {
            List<string> tasks = new List<string>();

            while (true)
            {
                Console.WriteLine("Выберите вариант действия над списком дел:");

                Console.WriteLine("\n1.Добавить дело. \n2. Показать все дела (списком 1, 2, 3...). " +
                                  "\n3. Удалить дело (по номеру или названию). \n4. Очистить список\n");

                string variable = Console.ReadLine();

                if (string.IsNullOrEmpty(variable))
                {
                    Console.WriteLine("Вы ничего не ввели! Повторите.\n");
                    continue;
                }
                else
                {
                    switch (variable)
                    {
                        case "1":

                            Console.WriteLine("\nВы выбрали вариант 1. Добавить дело. если хотите выйти назад нажмите 0\n");

                            while (true)
                            {
                                Console.Write("\nВведите текст: ");

                                string isCase = Console.ReadLine();

                                if (isCase == "0") break;

                                if (string.IsNullOrEmpty(isCase))
                                {
                                    Console.WriteLine("Вы ничего не ввели! Повторите.\n");
                                    continue;
                                }
                                else
                                {
                                    tasks.Add(isCase);
                                    Console.WriteLine("Запись добавлена!\n");
                                    break;
                                }

                            }
                            continue;

                        case "2":

                            Console.WriteLine("\nВы выбрали вариант 2. Показать все дела (списком 1, 2, 3...).\n");

                            if (tasks.Count == 0)
                            {
                                Console.WriteLine("Списка не существует!\n");
                                continue;
                            }
                            else
                            {
                                for (int i = 0; i < tasks.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + $" {tasks[i]}");
                                }

                                Console.WriteLine();
                                continue;
                            }

                        case "3":
                            Console.WriteLine("\n--- УДАЛЕНИЕ ---");
                            Console.Write("Введите номер дела или его название: ");
                            string inputForDelete = Console.ReadLine();

                            if (int.TryParse(inputForDelete, out int index))
                            {
                                int realIndex = index - 1;

                                if (realIndex >= 0 && realIndex < tasks.Count)
                                {
                                    string removedTask = tasks[realIndex];

                                    tasks.RemoveAt(realIndex);

                                    Console.WriteLine($"Удалено дело №{index}: {removedTask}\n");
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: Дела с таким номером не существует.\n");
                                }
                            }
                            else
                            {
                                bool isRemoved = tasks.Remove(inputForDelete);

                                if (isRemoved)
                                {
                                    Console.WriteLine($"Дело '{inputForDelete}' удалено!\n");
                                }
                                else
                                {
                                    Console.WriteLine($"Ошибка: Дела с названием '{inputForDelete}' не найдено.\n");
                                }
                            }
                            break;

                        case "4":
                            tasks.Clear();
                            Console.WriteLine("Список очищен!\n");
                            break;

                        case "5":
                            Console.WriteLine("До свидания!");
                            return;

                        default:
                            Console.WriteLine("\nВы не ввели ни один из вариантов, повторите!\n");
                            continue;
                    }
                }

            }
        }

    }
}
