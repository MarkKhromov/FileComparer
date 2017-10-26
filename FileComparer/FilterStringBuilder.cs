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
            FileFormatInfos = new Dictionary<FileFormats, FileFormatInfo> {
                { FileFormats.All, new FileFormatInfo("Все файлы", new[] { "*" }) },
                { FileFormats.Txt, new FileFormatInfo("Текстовые документы", new[] { "txt" }) }
            };
        }

        static readonly IDictionary<FileFormats, FileFormatInfo> FileFormatInfos;

        public static string Build(params FileFormats[] fileFormats) {
            var filters = new Collection<string>();
            foreach(var fileFormat in fileFormats) {
                var fileFormatInfo = FileFormatInfos[fileFormat];
                var fileExtensions = fileFormatInfo.FileExtensions.Select(x => $"*.{x}");
                filters.Add($"{fileFormatInfo.DisplayText} ({string.Join(", ", fileExtensions)})|{string.Join(";", fileExtensions)}");
            }
            return string.Join("|", filters);
        }
    }
}