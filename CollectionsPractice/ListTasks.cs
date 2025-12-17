using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void PhoneBook()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            phoneBook.Add("Мама", "88009994545");
            phoneBook.Add("Папа", "88009994546");

            bool isNull;

            while (true)
            {
                Console.WriteLine("\nВыберите какое действие хотели бы совершить с телефонной книгой:\n");

                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Найти номер по имени");
                Console.WriteLine("3. Удалить контакт контакт");
                Console.WriteLine("4. Посмотреть список контактов");
                Console.WriteLine("5. Выход\n");

                string variable = Console.ReadLine();

                if (int.TryParse(variable, out int correctVariable))
                {
                    switch (correctVariable)
                    {
                        case 1:

                            while (true)
                            {
                                Console.WriteLine("\nДобавление контакта:\n");

                                Console.Write("Введите имя: ");
                                string name = Console.ReadLine();

                                isNull = NullValidation(name);
                                if (!isNull) continue;

                                Console.Write("\nВведите телефон: ");
                                string phoneNum = Console.ReadLine();

                                isNull = NullValidation(phoneNum);
                                if (!isNull) continue;

                                ValidationPhone(in phoneNum, out bool numberIsCorrect);

                                if (phoneBook.ContainsKey(name))
                                {
                                    Console.WriteLine("Ошибка: Контакт с таким именем уже существует!");
                                    Console.WriteLine("Повторите!");
                                    continue;
                                }
                                if (numberIsCorrect)
                                {
                                    phoneBook.Add(name, phoneNum);
                                    Console.WriteLine("Контакт добавлен!");
                                    break;
                                }
                            }
                            continue;

                        case 2:
                            Console.WriteLine("\nПоиск номера по имени:\n");
                            Console.WriteLine("\nВведите имя: ");
                            string namePerson = Console.ReadLine();

                            isNull = NullValidation(namePerson);
                            if (!isNull) continue;

                            if (phoneBook.ContainsKey(namePerson))
                            {
                                string number = phoneBook[namePerson];

                                Console.WriteLine($"Нашел номер этого человека - Номер: {number}");
                            }
                            else Console.WriteLine("Такого имени в контактах нет.");

                            continue;

                        case 3:
                            Console.WriteLine("\nНапишите имя контакта, которого хотите удалить\n");
                            string nameToDel = Console.ReadLine();

                            isNull = NullValidation(nameToDel);
                            if (!isNull) continue;

                            if (phoneBook.ContainsKey(nameToDel))
                            {
                                Console.WriteLine("\nКонтакт удален!\n");
                                phoneBook.Remove(nameToDel);
                            }
                            else Console.WriteLine("\nТакого имени в контактах нет.\n");

                            continue;

                        case 4:

                            foreach (var item in phoneBook)
                            {
                                Console.WriteLine($"Имя: {item.Key} | Тел: {item.Value}");
                            }
                            continue;

                        case 5:
                            Console.WriteLine("Выходим");
                            return;

                        default:
                            Console.WriteLine("Такого действия не существует! Повторите.");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("\nНе корректный формат ввода. Повторите!");
                    continue;
                }
            }
        }

        public static void ValidationPhone(in string number, out bool correctOrNot)
        {
            bool numberCorrect1 = true;

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    Console.WriteLine("Не корректный ввод номера, должны быть лишь цифры! Повторите.");
                    numberCorrect1 = false;
                    break;
                }
            }
            if (number.Length != 11)
            {
                Console.WriteLine("Номер должен содержать 11 цифр! Повторите.");
                numberCorrect1 = false;
            }
            correctOrNot = numberCorrect1;
        }

        public static bool NullValidation(in string context)
        {
            if (string.IsNullOrEmpty(context))
            {
                Console.WriteLine("Вы ничего не ввели, пожалуйста повторите!");
                return false;
            }
            return true;
        }

        public void FrequencyAnalysis()
        {
            Console.WriteLine("Введите предложением слова, а мы посчитаем повторы этих слов");
            string text;

            while (true)
            {
                text = Console.ReadLine();

                bool isNull = NullValidation(text);

                if (!isNull) continue;
                else break;
            }

            text = text.ToLower();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            int counts = 1;

            foreach (string word in words)
            {
                if (!frequencies.ContainsKey(word))
                {
                    frequencies.Add(word, counts);
                }
                else
                {
                    frequencies[word] += counts;
                }
            }

            Console.WriteLine("Ваш результат:");
            foreach (var item in frequencies)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        public void LifeTimeCalculator()
        {
            Console.Write("Введите дату рождения (гггг-мм-дд): ");
            string inputbirthDate = Console.ReadLine();


            if (DateTime.TryParse(inputbirthDate, out DateTime birthDate))
            {
                DateTime now = DateTime.Now;
                TimeSpan lived = now - birthDate;
                Console.WriteLine($"Ты прожил: {lived.TotalDays:F0} дней всего");
                Console.WriteLine($"Ты родился в: {birthDate.DayOfWeek}");

                DateTime nextBirthday = new DateTime(now.Year, birthDate.Month, birthDate.Day);

                if (nextBirthday < now)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }
                TimeSpan daysLeft = nextBirthday - now;
                Console.WriteLine($"До следующего ДР осталось: {daysLeft.TotalDays:F0} дней");
            }
            else Console.WriteLine("Не корректный ввод!");
        }
    }
}
