﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Exam.Services
{
    class FileHandleService
    {
        public static async void WriteFile(string fileName, string content)
        {
            var storage = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            // tim den noi luu tru file trong may tinh
            var demoFile = await storage.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(demoFile, content);
        }
        public static async Task<string> ReadFile(string fileName)
        {
            var storage = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            var demoFile = await storage.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(demoFile);
        }
    }
}
