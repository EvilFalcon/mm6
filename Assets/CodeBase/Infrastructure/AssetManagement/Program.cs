using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class Program
    {
        public static void Run()
        {
            var path = InputDirectoryPath();
            var counter = new LineCounter();

            var total = counter.SearchAndCount(path, false, out Dictionary<FileInfo, int> statistics);

            Debug.Log("Всего файлов: " + statistics.Count);
            Debug.Log("Всего строк кода: " + total);
        }

        static string InputDirectoryPath()
        {
            const string messagenput = "Укажите полный путь к папке с иходниками (*.cs): ";
            const string messageError = "Папка не найдена!";

            string path = string.Empty;
            bool exists = false;

            do
            {
                Console.WriteLine(messagenput);
                path = @"\Assets\CodeBase";
                exists = Directory.Exists(path);

                if (!exists)
                {
                    Debug.Log(messageError);
                }
            } while (!exists);

            return path;
        }
    }

    internal sealed class LineCounter
    {
        private const string FileSearchMask = "*.cs";

        private IEnumerable<string> _ignoredFiles = new string[]
        {
            "Program.cs"
        };

        /// <summary>
        /// Найти все файлы с кодом си шарпа и подсчитать количество строк кода во всех файлах.
        /// </summary>
        /// <param name="directoryPath">Полный путь к папке.</param>
        /// <param name="ignoreEmptyLines">Игнорировать пустые строки при подсчете?</param>
        /// <param name="statistics">Статистика с результатами подсчета по всем файлам.</param>
        /// <returns></returns>
        public int SearchAndCount(string directoryPath, bool ignoreEmptyLines, out Dictionary<FileInfo, int> statistics)
        {
            int counter = 0;

            var files = FindFiles(directoryPath);
            statistics = new Dictionary<FileInfo, int>();

            foreach (var file in files)
            {
                var lines = CountLines(file);
                statistics.Add(file, lines);

                counter += lines;
            }

            return counter;
        }

        private bool CheckIsIgnored(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return true;
            }

            return _ignoredFiles.Any(
                ignored =>
                    ignored.Equals(filename, StringComparison.OrdinalIgnoreCase) ||
                    filename.EndsWith(ignored)
            );
        }

        private IEnumerable<FileInfo> FindFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return new FileInfo[0];
            }

            var files = Directory.GetFiles(directoryPath, FileSearchMask, SearchOption.AllDirectories);

            var infos = files.Select(path => new FileInfo(path))
                .Where(info => !CheckIsIgnored(info.Name));

            return infos;
        }

        private int CountLines(FileInfo fileInfo, bool ignoreEmptyLines = false)
        {
            if (!fileInfo.Exists)
            {
                return 0;
            }

            var lines = File.ReadAllLines(fileInfo.FullName);

            if (ignoreEmptyLines)
            {
                int counter = 0;

                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line?.Trim()))
                    {
                        counter++;
                    }
                }

                return counter;
            }
            else
            {
                return lines.Length;
            }
        }
    }
}