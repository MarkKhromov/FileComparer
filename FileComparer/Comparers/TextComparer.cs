using System;
using System.IO;
using FileComparer.Comparers.Base;

namespace FileComparer.Comparers {
    public class TextComparer : IObjectComparer {
        bool IObjectComparer.Compare(object object1, object object2) {
            if(!(object1 is string)) {
                throw new ArgumentException();
            }
            if(!(object2 is string)) {
                throw new ArgumentException();
            }
            var string1 = (string)object1;
            var string2 = (string)object2;
            // Improve equals mechanism
            return Equals(string1, string2);
        }

        object IObjectComparer.GetObject(string fileName) {
            return File.ReadAllText(fileName);
        }
    }
}