using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ATV.WPF.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected bool _IsChanged = false;
        /// <summary>
        /// Были ли внесены изменения в поля класса.
        /// </summary>
        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }

        public BaseViewModel() { }

        protected virtual void ClearChanges() => _IsChanged = false;

        protected void ReadFromSource(object source, int? attributeId = null)
        {
            Type thisType = GetType();
            PropertyInfo[] thisProperties = thisType.GetProperties();
            Type sourceType = source.GetType();

            foreach (var thisProp in thisProperties)
            {
                object[] attributes = thisProp.GetCustomAttributes(typeof(BindSourceAttribute), false);
                if (attributes.Length > 0)
                {
                    bool isHandle = !attributeId.HasValue || (attributes.First() as BindSourceAttribute).Id == attributeId.Value;
                    if (isHandle)
                    {
                        PropertyInfo sourceProp = sourceType.GetProperty(thisProp.Name);
                        if (sourceProp == null)
                            throw new Exception("Property \"" + thisProp.Name + "\" not found.");

                        object sourceValue = sourceProp.GetValue(source);
                        thisProp.SetValue(this, sourceValue);
                    }
                }
            }
        }

        protected void WriteToSource(object source, int? attributeId = null)
        {
            Type thisType = GetType();
            PropertyInfo[] thisProperties = thisType.GetProperties();
            Type sourceType = source.GetType();

            foreach (var thisProp in thisProperties)
            {
                object[] attributes = thisProp.GetCustomAttributes(typeof(BindSourceAttribute), false);
                if (attributes.Length > 0)
                {
                    BindSourceAttribute attribute = (attributes.First() as BindSourceAttribute);
                    bool isHandle = !attributeId.HasValue || attribute.Id == attributeId.Value;

                    if (isHandle && !attribute.ReadOnly)
                    {
                        PropertyInfo sourceProp = sourceType.GetProperty(thisProp.Name);
                        if (sourceProp == null)
                            throw new Exception("Property \"" + thisProp.Name + "\" not found.");

                        object thisValue = thisProp.GetValue(this);
                        if (attribute.DefaultValues != null && attribute.DefaultValues.Any(x => object.Equals(x, thisValue)))
                            throw new Exception("Свойство \"" + attribute.PropertyName + "\" обязательно к заполнению.");

                        sourceProp.SetValue(source, thisValue);
                    }
                }
            }
        }

        protected Action<T> GetActionBatchUpdateSource<T>(int? attributeId = null)
        {
            void action(T x) => WriteToSource(x, attributeId);
            return action;
        }

        protected void PropertyChange<TProperty>(string propName, ref TProperty oldValue, TProperty newValue)
        {
            if (!object.Equals(oldValue, newValue))
            {
                oldValue = newValue;

                RaisePropertyChanged(propName);
            }
        }

        protected void PropertyChange(object entity, string propName, object newValue)
        {
            if (entity != null)
            {
                var prop = entity.GetType().GetProperty(propName);
                if (prop != null)
                {
                    var existValue = prop?.GetValue(entity);

                    if (!Equals(existValue, newValue))
                    {
                        prop.SetValue(entity, newValue);

                        RaisePropertyChanged(propName);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName, bool setChange = true)
        {
            if (setChange) { _IsChanged = true; }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}