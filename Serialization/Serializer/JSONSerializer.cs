using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Serializer
{
    public class JSONSerializer
    {
        public static void ToJSON<T>(T input)
        {
            // ---------------------------------
            // Variant 1: Using System.Text.Json
            // ---------------------------------
            //JsonSerializerOptions options = new() { WriteIndented = true };
            //string jsonContent = JsonSerializer.Serialize(input, options);

            //string fileName = $"../../../{input.GetType().Name}.json";
            //File.WriteAllText(fileName, jsonContent);



            // ---------------------------------
            // Variant 2: Using Reflection
            // Note: This implementation will not work for properties of the type collection (array, list) or custom objects
            // ---------------------------------
            Type type = input.GetType();
            PropertyInfo[] properties = type.GetProperties();

            T clonedObj = (T)Activator.CreateInstance(type);

            StringBuilder sb = new();
            sb.AppendLine("{");
            int counter = 0;

            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(input);
                property.SetValue(clonedObj, value);

                if (properties.Length - 1 > counter)
                {
                    // Booleans, numbers and null don't need to have quotes
                    if (ValueTypeIsBoolOrNumberOrNull(value))
                    {
                        if (value == null)
                        {
                            sb.AppendLine($"  \"{property.Name}\": null,");
                        }
                        else
                        {
                            sb.AppendLine($"  \"{property.Name}\": {value.ToString().ToLower()},");
                        }
                    }
                    else
                    {
                        sb.AppendLine($"  \"{property.Name}\": \"{value}\",");
                    }
                }
                else // When it's the last property - enter here to get rig of the comma (,) after the last entry
                {
                    if (ValueTypeIsBoolOrNumberOrNull(value))
                    {
                        if (value == null)
                        {
                            sb.AppendLine($"  \"{property.Name}\": null");
                        }
                        else
                        {
                            sb.AppendLine($"  \"{property.Name}\": {value.ToString().ToLower()}");
                        }
                    }
                    else
                    {
                        sb.AppendLine($"  \"{property.Name}\": \"{value}\"");
                    }
                }

                counter++;
            }

            sb.Append('}');

            string fileName = $"../../../{input.GetType().Name}.json";
            File.WriteAllText(fileName, sb.ToString());
        }

        private static bool ValueTypeIsBoolOrNumberOrNull(object value)
        {
            return value == null || double.TryParse(value.ToString(), out _) || bool.TryParse(value.ToString(), out _);
        }

        public static T FromJSON<T>(string fileName)
        {
            // Didn't find an "easy" way to implement deserialization using only Reflection so I'm using System.Text.Json

            string jsonContent = File.ReadAllText($"../../../{fileName}");
            var obj = JsonSerializer.Deserialize<T>(jsonContent);

            return obj;
        }
    }
}
