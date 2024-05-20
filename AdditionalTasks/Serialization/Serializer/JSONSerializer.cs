using System.Collections;
using System.Reflection;
using System.Text;

namespace Serializer
{
    public class JSONSerializer
    {
        public string ToJSON(object input)
        {
            StringBuilder sb = new();
            SerializeInput(input, sb);
            return sb.ToString();
        }

        private void SerializeInput(object input, StringBuilder sb)
        {
            if (input == null)
            {
                sb.Append("null");
            }
            else if (input is bool || IsNumeric(input))
            {
                sb.Append(input.ToString().ToLower());
            }
            else if (input is string)
            {
                sb.Append($"\"{input}\"");
            }
            else if (input is IDictionary dictionary)
            {
                SerializeDictionary(dictionary, sb);
            }
            else if (input is IEnumerable enumerable)
            {
                SerializeEnumerable(enumerable, sb);
            }
            else
            {
                SerializeObjectProperties(input, sb);
            }
        }

        private void SerializeObjectProperties(object input, StringBuilder sb)
        {
            Type type = input.GetType();
            PropertyInfo[] properties = type.GetProperties();

            sb.Append('{');
            bool isFirstProperty = true;

            foreach (PropertyInfo property in properties)
            {
                if (!isFirstProperty)
                {
                    sb.Append(',');
                }

                isFirstProperty = false;
                sb.Append($"\"{property.Name}\"");
                sb.Append(':');
                SerializeInput(property.GetValue(input), sb);
            }

            sb.Append('}');
        }

        private void SerializeEnumerable(IEnumerable input, StringBuilder sb)
        {
            sb.Append('[');
            bool isFirstEntry = true;

            foreach (object item in input)
            {
                if (!isFirstEntry)
                {
                    sb.Append(',');
                }

                isFirstEntry = false;
                SerializeInput(item, sb);
            }

            sb.Append(']');
        }

        private void SerializeDictionary(IDictionary dictionary, StringBuilder sb)
        {
            sb.Append('{');
            bool isFirstEntry = true;

            foreach (DictionaryEntry entry in dictionary)
            {
                if (!isFirstEntry)
                {
                    sb.Append(',');
                }

                isFirstEntry = false;
                sb.Append($"\"{entry.Key.ToString()}\"");
                sb.Append(':');
                SerializeInput(entry.Value, sb);
            }

            sb.Append('}');
        }

        private bool IsNumeric(object input)
        {
            return double.TryParse(input.ToString(), out _);
        }
    }
}
