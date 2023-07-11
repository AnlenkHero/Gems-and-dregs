using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Helpers
{
    public static class SaveSystem
    {
        private static string path = Application.persistentDataPath + "/progress.hentai";

        public static void SaveProgress(HentaiGirl[] hentaiGirls)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, hentaiGirls);
            stream.Close();
        }

        public static HentaiGirl[] LoadProgress()
        {
            HentaiGirl[] hentaiGirls;
            if (File.Exists(path))
            {
                // Якщо іcнує файл то завантажуємо його
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                hentaiGirls = formatter.Deserialize(stream) as HentaiGirl[];
                stream.Close();

                return hentaiGirls;
            }

            // Якщо його нема то створюємо його з нульовим прогресом
            hentaiGirls = new HentaiGirl[12];
            for (int i = 0; i < hentaiGirls.Length; i++)
            {
                // Визначаємо кількість рівнів по кількості png картинок у папці
                string currPath = @"Sprites/Girls/" + (i + 1);
                int j;
                for (j = 5; j > 0; j--)
                {
                    Sprite spriteTocheck = Resources.Load<Sprite>(currPath + $"/{j}");
                    if (Resources.LoadAll<Sprite>(currPath + $"/layers/lvl{j}/").Length > 0)
                    {
                        break;
                    }
                }

                HentaiGirl tempGirl = new HentaiGirl(j, 0, currPath);
                hentaiGirls[i] = tempGirl;
            }

            SaveProgress(hentaiGirls);
            return hentaiGirls;
        }

        public static void EraseProgress()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}