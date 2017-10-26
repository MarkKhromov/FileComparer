using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileComparer {
    static class FilterStringBuilder {
        #region Inner classes
        struct FileFormatInfo {
            public FileFormatInfo(string displayText, string[] fileExtensions) {
                DisplayText = displayText;
                FileExtensions = fileExtensions;
            }

            public readonly string DisplayText;
            public readonly string[] FileExtensions;
        }
        #endregion

        static FilterStringBuilder() {
            Register(FileFormats.All, "Все файлы", "*");
            Register(FileFormats.Txt, "Текстовые документы", "txt");
        }

        static readonly IDictionary<FileFormats, FileFormatInfo> FileFormatInfos = new Dictionary<FileFormats, FileFormatInfo>();

        public static string Build(params FileFormats[] fileFormats) {
            var filters = new Collection<string>();
            foreach(var fileFormat in fileFormats) {
                var fileFormatInfo = FileFormatInfos[fileFormat];
                var fileExtensions = fileFormatInfo.FileExtensions.Select(x => $"*.{x}");
                filters.Add($"{fileFormatInfo.DisplayText} ({string.Join(", ", fileExtensions)})|{string.Join(";", fileExtensions)}");
            }
            return string.Join("|", filters);
        }

        static void Register(FileFormats fileFormat, string displayName, params string[] fileExtensions) {
            FileFormatInfos.Add(fileFormat, new FileFormatInfo(displayName, fileExtensions));
        }
    }
}