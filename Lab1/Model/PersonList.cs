namespace Model
{
    /// <summary>
    /// Класс, описывающий список персон на основе массива.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив персон.
        /// </summary>
        private Person[] _persons = new Person[0];

        /// <summary>
        /// Добавляет персону в конец списка.
        /// </summary>
        /// <param name="person">Добавляемая персона.</param>
        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException
                    (nameof(person), "Персона не может быть пустой.");
            }

            var newPersonIndex = _persons.Length;

            Array.Resize(ref _persons, newPersonIndex + 1);
            _persons[newPersonIndex] = person;
        }

        /// <summary>
        /// Проверяет корректность индекса.
        /// </summary>
        /// <param name="index">Проверяемый индекс.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Индекс выходит за границы списка.
        /// </exception>
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _persons.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Индекс выходит за границы списка.");
            }
        }

        /// <summary>
        /// Удаляет персону по индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемой персоны.</param>
        public void DeletePersonByIndex(int index)
        {
            CheckIndex(index);

            for (int currentIndex = index;
                currentIndex < _persons.Length - 1;
                currentIndex++)
            {
                _persons[currentIndex] = _persons[currentIndex + 1];
            }

            Array.Resize(ref _persons, _persons.Length - 1);
        }

        /// <summary>
        /// Удаляет персону из списка.
        /// </summary>
        /// <param name="person">Удаляемая персона.</param>
        public void DeletePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(
                    nameof(person),
                    "Персона не может быть пустой.");
            }

            int personIndex = SearchIndexOfPerson(person);

            if (personIndex == -1)
            {
                throw new ArgumentException(
                    "Персона не найдена в списке.",
                    nameof(person));
            }

            DeletePersonByIndex(personIndex);
        }

        /// <summary>
        /// Возвращает персону по индексу.
        /// </summary>
        /// <param name="index">Индекс персоны.</param>
        /// <returns>Персона с указанным индексом.</returns>
        public Person SearchPerson(int index)
        {
            CheckIndex(index);
            return _persons[index];
        }

        /// <summary>
        /// Возвращает индекс персоны в списке.
        /// </summary>
        /// <param name="person">Искомая персона.</param>
        /// <returns>
        /// Индекс персоны в списке. Если персона не найдена, возвращает -1.
        /// </returns>
        public int SearchIndexOfPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(
                    nameof(person),
                    "Персона не может быть пустой.");
            }

            for (int currentIndex = 0;
                currentIndex < _persons.Length;
                currentIndex++)
            {
                if (_persons[currentIndex] == person)
                {
                    return currentIndex;
                }
            }

            return -1;
        }

        /// <summary>
        /// Очищает список персон.
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref _persons, 0);
        }

        /// <summary>
        /// Возвращает количество персон в списке.
        /// </summary>
        /// <returns>Количество персон в списке.</returns>
        public int NumberOfPersons()
        {
            return _persons.Length;
        }
    }
}
