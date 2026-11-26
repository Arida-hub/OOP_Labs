using Model;

namespace Lab1
{
    /// <summary>
    /// Класс для демонстрации работы программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            var olderPersons = new PersonList();
            var youngerPersons = new PersonList();

            FillInitialLists(olderPersons, youngerPersons);

            PrintStepHeader("Исходные списки персон");
            PrintPersonList("Первый список", olderPersons);
            PrintPersonList("Второй список", youngerPersons);

            WaitForNextStep();

            var newPerson = new Person
                ("Харитон", "Харитонов", 35, Gender.Male);

            olderPersons.AddPerson(newPerson);

            PrintStepHeader("Добавление новой персоны в первый список");
            Console.WriteLine("В первый список добавлена новая персона.");
            PrintPersonList("Первый список", olderPersons);
            PrintPersonList("Второй список", youngerPersons);

            WaitForNextStep();

            var copiedPerson = olderPersons.SearchPerson(1);
            youngerPersons.AddPerson(copiedPerson);

            PrintStepHeader(
                "Копирование второй персоны из первого списка" +
                " во второй");
            Console.WriteLine(
                "Вторая персона из первого списка добавлена " +
                "в конец второго списка.");

            PrintPersonList("Первый список", olderPersons);
            PrintPersonList("Второй список", youngerPersons);

            ShowReferenceCheck
                //TODO: RSDN
                (copiedPerson, youngerPersons.SearchPerson(youngerPersons.NumberOfPersons() - 1));

            WaitForNextStep();

            olderPersons.DeletePersonByIndex(1);

            PrintStepHeader("Удаление второй персоны из первого списка");
            Console.WriteLine("Вторая персона удалена из первого списка.");

            PrintPersonList("Первый список", olderPersons);
            PrintPersonList("Второй список", youngerPersons);

            ShowPersonExistenceInSecondList(copiedPerson, youngerPersons);

            WaitForNextStep();

            youngerPersons.ClearList();

            PrintStepHeader("Очистка второго списка");
            Console.WriteLine("Второй список очищен.");

            PrintPersonList("Первый список", olderPersons);
            PrintPersonList("Второй список", youngerPersons);

            WaitForNextStep();

            PrintStepHeader("Ввод персон с клавиатуры");
            CreatePersonsFromConsoleUntilExit();

            WaitForNextStep();

            PrintStepHeader("Создание случайных персон");
            CreateRandomPersonsUntilExit();

            Console.WriteLine();
            Console.WriteLine("Демонстрация завершена.");
        }

        /// <summary>
        /// Заполняет исходные списки персонами.
        /// </summary>
        /// <param name="olderPersons">Первый список персон.</param>
        /// <param name="youngerPersons">Второй список персон.</param>
        private static void FillInitialLists
            (PersonList olderPersons, PersonList youngerPersons)
        {
            if (olderPersons == null)
            {
                throw new ArgumentNullException
                    //TODO: RSDN
                    (nameof(olderPersons), "Первый список персон не может быть пустым.");
            }

            if (youngerPersons == null)
            {
                throw new ArgumentNullException
                    //TODO: RSDN
                    (nameof(youngerPersons), "Второй список персон не может быть пустым.");
            }

            var ivanov = new Person
                ("Иван", "Иванов", 50, Gender.Male);
            var petrov = new Person
                ("Пётр", "Петров", 45, Gender.Male);
            var sidorov = new Person
                ("Сидор", "Сидоров", 40, Gender.Male);

            var smirnov = new Person
                ("Владислав", "Смирнов", 12, Gender.Male);
            var sokolov = new Person
                ("Александр", "Соколов", 11, Gender.Male);
            var fedorov = new Person
                ("Владимир", "Фёдоров", 10, Gender.Male);

            olderPersons.AddPerson(ivanov);
            olderPersons.AddPerson(petrov);
            olderPersons.AddPerson(sidorov);

            youngerPersons.AddPerson(smirnov);
            youngerPersons.AddPerson(sokolov);
            youngerPersons.AddPerson(fedorov);
        }

        /// <summary>
        /// Выводит список персон.
        /// </summary>
        /// <param name="title">Название списка.</param>
        /// <param name="personList">Список персон.</param>
        private static void PrintPersonList(string title, PersonList personList)
        {
            if (personList == null)
            {
                throw new ArgumentNullException
                    (nameof(personList), "Список персон не может быть пустым.");
            }

            Console.WriteLine();
            Console.WriteLine(title + ":");

            if (personList.NumberOfPersons() == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int personIndex = 0;
                personIndex < personList.NumberOfPersons();
                personIndex++)
            {
                var person = personList.SearchPerson(personIndex);
                Console.WriteLine($"{personIndex + 1}. {person}");
            }
        }

        /// <summary>
        /// Выводит заголовок шага демонстрации.
        /// </summary>
        /// <param name="title">Название шага.</param>
        private static void PrintStepHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 60));
        }

        /// <summary>
        /// Ожидает нажатия клавиши для перехода к следующему шагу.
        /// </summary>
        private static void WaitForNextStep()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            _ = Console.ReadKey(true);
        }

        /// <summary>
        /// Показывает, что две ссылки указывают на один объект.
        /// </summary>
        /// <param name="firstPerson">Первая персона.</param>
        /// <param name="secondPerson">Вторая персона.</param>
        private static void ShowReferenceCheck
            (Person firstPerson, Person secondPerson)
        {
            Console.WriteLine();

            if (ReferenceEquals(firstPerson, secondPerson))
            {
                Console.WriteLine(
                    "Проверка ссылок: " +
                    "в обоих списках находится один и тот же объект.");
            }
            else
            {
                Console.WriteLine("Проверка ссылок: " +
                    "в списках находятся разные объекты.");
            }
        }

        /// <summary>
        /// Показывает, осталась ли персона во втором списке.
        /// </summary>
        /// <param name="person">Проверяемая персона.</param>
        /// <param name="personList">Список персон.</param>
        private static void ShowPersonExistenceInSecondList
            (Person person, PersonList personList)
        {
            if (person == null)
            {
                throw new ArgumentNullException
                    (nameof(person), "Персона не может быть пустой.");
            }

            if (personList == null)
            {
                throw new ArgumentNullException
                    (nameof(personList), "Список персон не может быть пустым.");
            }

            Console.WriteLine();

            int personIndex = personList.SearchIndexOfPerson(person);

            if (personIndex == -1)
            {
                Console.WriteLine(
                    "Проверка удаления: персона отсутствует во втором списке.");
            }
            else
            {
                Console.WriteLine(
                    "Проверка удаления: персона осталась во втором списке.");
                Console.WriteLine(
                    $"Индекс персоны во втором списке: {personIndex}.");
                Console.WriteLine($"Персона: {person}");
            }
        }

        /// <summary>
        /// Вводит персон с клавиатуры до тех пор, пока пользователь
        /// не завершит ввод.
        /// </summary>
        private static void CreatePersonsFromConsoleUntilExit()
        {
            while (true)
            {
                var enteredPerson = ReadPersonFromConsole();

                Console.WriteLine();
                Console.WriteLine("Введённая персона:");
                enteredPerson.PrintToConsole();

                if (!NeedContinue("Ввести ещё одну персону?"))
                {
                    return;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Считывает данные персоны из консоли.
        /// </summary>
        /// <returns>Персона, созданная на основе введённых данных.</returns>
        private static Person ReadPersonFromConsole()
        {
            return Person.ReadFromConsole();
        }

        /// <summary>
        /// Создаёт случайных персон до тех пор, пока пользователь
        /// не завершит программу.
        /// </summary>
        private static void CreateRandomPersonsUntilExit()
        {
            while (true)
            {
                var randomPerson = Person.GetRandomPerson();

                Console.WriteLine();
                Console.WriteLine("Создана случайная персона:");
                randomPerson.PrintToConsole();

                if (!NeedContinue("Создать ещё одну случайную персону?"))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Проверяет, хочет ли пользователь продолжить
        /// выполнение текущего действия.
        /// </summary>
        /// <param name="question">Вопрос для пользователя.</param>
        /// <returns>
        /// Возвращает true, если пользователь хочет продолжить;
        /// иначе возвращает false.
        /// </returns>
        private static bool NeedContinue(string question)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write($"{question} 1 - да, 2 - нет: ");

                string inputText = Console.ReadLine();

                if (!int.TryParse(inputText, out int answerNumber))
                {
                    Console.WriteLine("Ответ должен быть числом.");
                    continue;
                }

                //TODO: switch-case
                if (answerNumber == 1)
                {
                    return true;
                }

                if (answerNumber == 2)
                {
                    return false;
                }

                Console.WriteLine("Ответ должен быть числом 1 или 2.");
            }
        }
    }
}
