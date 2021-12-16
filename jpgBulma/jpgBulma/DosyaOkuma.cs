using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace jpgBulma
{
    class DosyaOkuma
    {
        public string location;
        public string yazi;
        public StringBuilder jpgArray;
        public StringBuilder txtArray;

        List<String> jpgList = new List<string>();
        List<String> txtList = new List<string>();

        public DosyaOkuma()
        {
            Console.WriteLine("Dosya yolunu giriniz.");
            location = Convert.ToString(Console.ReadLine());

            FileStream fileStream = new FileStream(location, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);



            while (!streamReader.EndOfStream)
            {
                yazi = streamReader.ReadLine();

                bool containTxt = checkString(yazi, "txt");
                string extension = getLastThreeCharacters(yazi);



                if (extension == "jpg") jpgList.Add(yazi);

                else if (extension == "txt") txtList.Add(yazi);



            }

            Console.WriteLine("size of jpgList: " + jpgList.Count + ", size of txtList: " + txtList.Count);

            for (int i = 0; i < jpgList.Count; i++)
            {
                string name = jpgList[i].Substring(0, jpgList[i].Length - 4);


                if (!txtList.Contains(name + ".txt"))
                {
                    File.Delete(jpgList[i]);
                }
            }
        }

        private bool checkString(string mainString, string subString)
        {
            if (mainString.Contains(subString)) return true;

            return false;
        }

        private string getLastThreeCharacters(string str)
        {
            if (str.Length > 3) return str.Substring(str.Length - 3);

            return "false";
        }
    }
}

