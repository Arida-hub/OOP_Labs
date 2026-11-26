namespace Model
{
    /// <summary>
    /// Класс для создания случайных персон.
    /// </summary>
    public static class RandomPersonGenerator
    {
        /// <summary>
        /// Количество значений пола.
        /// </summary>
        private const int _genderCount = 2;

        /// <summary>
        /// Объект для генерации случайных значений.
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Мужские имена.
        /// </summary>
        private static readonly string[] _maleNames =
        {
            "Александр", "Артём", "Дмитрий", "Иван", "Максим",
            "Михаил", "Никита", "Павел", "Сергей", "Виктор"
        };

        /// <summary>
        /// Женские имена.
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "Анастасия", "Анна", "Валентина", "Варвара", "Дарья",
            "Екатерина", "Елена", "Мария", "Ольга", "София"
        };

        /// <summary>
        /// Мужские фамилии.
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов",
            "Попов", "Васильев", "Соколов", "Михайлов", "Фёдоров"
        };

        /// <summary>
        /// Женские фамилии.
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Иванова", "Петрова", "Сидорова", "Смирнова", "Кузнецова",
            "Попова", "Васильева", "Соколова", "Михайлова", "Фёдорова"
        };

        /// <summary>
        /// Создаёт случайную персону.
        /// </summary>
        /// <returns>Случайно созданная персона.</returns>
        public static Person GetRandomPerson()
        {
            int genderIndex = _random.Next(_genderCount);

            Gender generatedGender = genderIndex == 0
                ? Gender.Male
                : Gender.Female;

            string generatedName = generatedGender == Gender.Male
                ? GetRandomMaleName()
                : GetRandomFemaleName();

            string generatedSurname = generatedGender == Gender.Male
                ? GetRandomMaleSurname()
                : GetRandomFemaleSurname();

            int generatedAge = _random.Next
                (Person.MinimumAge, Person.MaximumAge + 1);

            return new Person(
                generatedName,
                generatedSurname,
                generatedAge,
                generatedGender);
        }

        /// <summary>
        /// Возвращает случайное мужское имя.
        /// </summary>
        /// <returns>Случайное мужское имя.</returns>
        private static string GetRandomMaleName()
        {
            return _maleNames[_random.Next(_maleNames.Length)];
        }

        /// <summary>
        /// Возвращает случайное женское имя.
        /// </summary>
        /// <returns>Случайное женское имя.</returns>
        private static string GetRandomFemaleName()
        {
            return _femaleNames[_random.Next(_femaleNames.Length)];
        }

        /// <summary>
        /// Возвращает случайную мужскую фамилию.
        /// </summary>
        /// <returns>Случайная мужская фамилия.</returns>
        private static string GetRandomMaleSurname()
        {
            return _maleSurnames[_random.Next(_maleSurnames.Length)];
        }

        /// <summary>
        /// Возвращает случайную женскую фамилию.
        /// </summary>
        /// <returns>Случайная женская фамилия.</returns>
        private static string GetRandomFemaleSurname()
        {
            return _femaleSurnames[_random.Next(_femaleSurnames.Length)];
        }
    }
}
