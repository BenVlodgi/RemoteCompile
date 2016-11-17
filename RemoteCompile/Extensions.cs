using System;
using System.Collections.Generic;
using System.Linq;
using VMFParser;

namespace RemoteCompile
{
    public static class Extensions
    {
        public static VProperty GetPropertyWithKey(this VBlock block, string key)
        {
            return block.Body.Where(node => node is VProperty && node.Name == key).Cast<VProperty>().FirstOrDefault();
        }

        public static bool HasPropertyWithKeyValue(this VBlock block, string key, string value)
        {
            return block.Body.Where(node => node is VProperty && node.Name == key && (node as VProperty).Value == value).Count() > 0;
        }
    }
}
