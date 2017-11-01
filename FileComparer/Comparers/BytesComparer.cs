using System;
using System.IO;
using FileComparer.Comparers.Base;

namespace FileComparer.Comparers {
    public class BytesComparer : IObjectComparer {
        bool IObjectComparer.Compare(object object1, object object2) {
            if(!(object1 is byte[])) {
                throw new ArgumentException();
            }
            if(!(object2 is byte[])) {
                throw new ArgumentException();
            }
            var bytes1 = (byte[])object1;
            var bytes2 = (byte[])object2;
            // TODO: Improve equals mechanism
            if(bytes1.Length != bytes2.Length) {
                return false;
            }
            for(var i = 0; i < bytes1.Length; i++) {
                if(bytes1[i] != bytes2[i]) {
                    return false;
                }
            }
            return true;
        }

        object IObjectComparer.GetObject(string fileName) {
            return File.ReadAllBytes(fileName);
        }
    }
}