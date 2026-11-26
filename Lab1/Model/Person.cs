using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс, описывающий персону.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Минимальное значение возраста.
        /// </summary>
        public const int MinimumAge = 0;

        /// <summary>
        /// Максимальное значение возраста.
        /// </summary>
        public const int MaximumAge = 120;

        /// <summary>
        /// Шаблон имени или фамилии на английском языке.
        /// </summary>
        private static readonly Regex _latinNamePattern =
            new Regex(@"^[A-Za-z]+(?:[- ][A-Za-z]+)*$");

        /// <summary>
        /// Шаблон имени или фамилии на русском языке.
        /// </summary>
        private static readonly Regex _cyrillicNamePattern =
            new Regex(@"^[А-Яа-яЁё]+(?:[- ][А-Яа-яЁё]+)*$");

        /// <summary>
        /// Имя персоны.
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        private string _surname = string.Empty;

        /// <summary>
        /// Возраст персоны.
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол персоны.
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Имя персоны.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _ = CheckStringLanguage(value);
                var editedName = EditRegister(value);

                if (!string.IsNullOrWhiteSpace(_surname))
                {
                    CheckNameSurname(editedName, _surname);
                }

                _name = editedName;
            }
        }

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _ = CheckStringLanguage(value);
                var editedSurname = EditRegister(value);

                if (!string.IsNullOrWhiteSpace(_name))
                {
                    CheckNameSurname(_name, editedSurname);
                }

                _surname = editedSurname;
            }
        }

        /// <summary>
        /// Возраст персоны.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value >= MinimumAge && value <= MaximumAge)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Возраст должен быть в диапазоне " +
                        $"от {MinimumAge} до {MaximumAge}.");
                }
            }
        }

        /// <summary>
        /// Пол персоны.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <param name="name">Имя персоны.</param>
        /// <param name="surname">Фамилия персоны.</param>
        /// <param name="age">Возраст персоны.</param>
        /// <param name="gender">Пол персоны.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Person"/>.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Считывает данные персоны с клавиатуры.
        /// </summary>
        /// <returns>Персона, созданная на основе введённых данных.</returns>
        public static Person ReadFromConsole()
        {
            var person = new Person();

            while (true)
            {
                try
                {
                    Console.Write("Введите имя: ");
                    person.Name = Console.ReadLine() ?? string.Empty;
                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"Ошибка ввода: {exception.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Введите фамилию: ");
                    person.Surname = Console.ReadLine() ?? string.Empty;
                    break;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"Ошибка ввода: {exception.Message}");
                }
            }

            while (true)
            {
                Console.Write("Введите возраст: ");
                string ageText = Console.ReadLine() ?? string.Empty;

                if (!int.TryParse(ageText, out int age))
                {
                    Console.WriteLine("Возраст должен быть целым числом.");
                    continue;
                }

                try
                {
                    person.Age = age;
                    break;
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine($"Ошибка ввода: {exception.Message}");
                }
            }

            while (true)
            {
                Console.Write("Введите пол: 1 - мужской, 2 - женский: ");
                string genderText = Console.ReadLine() ?? string.Empty;

                if (genderText == "1")
                {
                    person.Gender = Gender.Male;
                    break;
                }

                if (genderText == "2")
                {
                    person.Gender = Gender.Female;
                    break;
                }

                Console.WriteLine("Пол должен быть указан числом 1 или 2.");
            }

            return person;
        }

        /// <summary>
        /// Выводит информацию о персоне на экран.
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine(this);
        }

        /// <summary>
        /// Создаёт случайную персону.
        /// </summary>
        /// <returns>Случайно созданная персона.</returns>
        public static Person GetRandomPerson()
        {
            return RandomPersonGenerator.GetRandomPerson();
        }

        /// <summary>
        /// Преобразует данные персоны в строку.
        /// </summary>
        /// <returns>Строка с информацией о персоне.</returns>
        public override string ToString()
        {
            return $"{Name} {Surname};" +
                $" возраст - {Age}; " +
                $"пол - {GetGenderText(Gender)}";
        }

        /// <summary>
        /// Проверяет язык строки.
        /// </summary>
        /// <param name="text">Проверяемая строка.</param>
        /// <returns>Язык строки.</returns>
        private static Language CheckStringLanguage(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Строка не может быть пустой.");
            }

            if (_latinNamePattern.IsMatch(text))
            {
                return Language.English;
            }

            if (_cyrillicNamePattern.IsMatch(text))
            {
                return Language.Russian;
            }

            throw new ArgumentException(
                "Строка должна содержать только русские или английские буквы.");
        }

        /// <summary>
        /// Проверяет, что имя и фамилия написаны на одном языке.
        /// </summary>
        /// <param name="personName">Имя персоны.</param>
        /// <param name="personSurname">Фамилия персоны.</param>
        private static void CheckNameSurname
            (string personName, string personSurname)
        {
            var personNameLanguage = CheckStringLanguage(personName);
            var personSurnameLanguage = CheckStringLanguage(personSurname);

            if (personNameLanguage != personSurnameLanguage)
            {
                throw new FormatException(
                    "Имя и фамилия должны быть написаны на одном языке.");
            }
        }

        /// <summary>
        /// Преобразует строку к правильному регистру.
        /// </summary>
        /// <param name="text">Имя или фамилия персоны.</param>
        /// <returns>Строка с первой заглавной буквой.</returns>
        private static string EditRegister(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(text.ToLower());
        }

        /// <summary>
        /// Возвращает текстовое представление пола.
        /// </summary>
        /// <param name="gender">Пол персоны.</param>
        /// <returns>Пол персоны в текстовом формате.</returns>
        private static string GetGenderText(Gender gender)
        {
            return gender switch
            {
                Gender.Male => "мужской",
                Gender.Female => "женский",
                _ => "неизвестен"
            };
        }
    }
}
