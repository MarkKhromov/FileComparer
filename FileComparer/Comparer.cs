using System.Collections.Generic;
using FileComparer.Comparers;
using FileComparer.Comparers.Base;

namespace FileComparer {
    public static  class Comparer {
        static Comparer() {
            comparers = new Dictionary<FileFormats, IObjectComparer>();
            Register(FileFormats.Txt, new TextComparer());
            Register(FileFormats.All, new BytesComparer());
        }

        static readonly IDictionary<FileFormats, IObjectComparer> comparers;

        public static IObjectComparer Get(FileFormats fileFormat) {
            return comparers[fileFormat];
        }

        static void Register(FileFormats fileFormat, IObjectComparer objectComparer) {
            comparers.Add(fileFormat, objectComparer);
        }
    }
}