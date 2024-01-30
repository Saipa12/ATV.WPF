using System;

namespace ATV.WPF.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    /// <summary>
    /// Указывает, что свойство источника нужно маппировать на свойство класса, представляющего ModelView.
    /// </summary>
    public class BindSourceAttribute : Attribute
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; private set; }

        public string PropertyName { get; private set; }

        public object[] DefaultValues { get; private set; }

        public bool ReadOnly { get; private set; }

        /// <param name="defaultValues">Если массив значений задан, то при возврате значений в исходный класс свойство будет проверяться на соответствие этим значениям. И если будет совпадение, то будет сформировано исключение.</param>
        public BindSourceAttribute(int id = 0, bool readOnly = false, string propertyName = "", params object[] defaultValues)
        {
            Id = id;
            PropertyName = propertyName;
            DefaultValues = defaultValues;
            ReadOnly = readOnly;
        }

        public BindSourceAttribute(int id = 0, bool readOnly = false)
        {
            Id = id;
            ReadOnly = readOnly;
        }
    }
}