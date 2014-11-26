using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace theRightDirection.Library.Portable.Extensions
{
    public static class ObjectExtension
    {
        public static void CopyProperties(this object from, object to, string[] excludedProperties = null)
        {
            var targetType = to.GetType();
            var sourceType = from.GetType();
            var sourceTypeInfo = sourceType.GetTypeInfo();
            var targetTypeInfo = targetType.GetTypeInfo();
            var baseType = targetTypeInfo.BaseType;
            var baseTypeInfo = baseType.GetTypeInfo();
            IEnumerable<PropertyInfo> sourceProperties = sourceTypeInfo.DeclaredProperties;
            IEnumerable<PropertyInfo> targetProperties = targetTypeInfo.DeclaredProperties;
            IEnumerable<PropertyInfo> baseProperties = baseTypeInfo.DeclaredProperties;
            targetProperties = targetProperties.Concat(baseProperties);
            IEnumerable<PropertyInfo> commonProperties = sourceProperties.Intersect(targetProperties, new PropertyInfoComparer());
            foreach (var commonProperty in commonProperties)
            {
                if (excludedProperties != null
                  && excludedProperties.Contains(commonProperty.Name))
                    continue;
                var hasExcludeAttribute = FindAttribute(commonProperty);
                if (!hasExcludeAttribute)
                {
                    var value = commonProperty.GetValue(from, null);
                    commonProperty.SetValue(to, value, null);
                }
            }
        }

        private static bool FindAttribute(PropertyInfo commonProperty)
        {
            var attribute = commonProperty.GetCustomAttribute<ExcludeFromCopyPropertyAttribute>();
            return attribute != null;
        }
        
    }
}