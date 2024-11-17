using System.Security.Cryptography;

namespace Zadanie
{
    public class ChangeMail
    {
        public string ReadFromFile(string path) {
            string result="";
            if (!File.Exists(path)) { result = $"Файл {path} не найден!"; }
            else
            {
                StreamReader file = new StreamReader(path);
                result+= file.ReadToEnd();
                file.Close();
            }
            return result ;
        }

        public (int K,int N,string[] text) GetSeparatedValues(string text)
        {
            string[] linesOfText = text.Split('\n');
            string[] kAndN = linesOfText[0].Split(",");
            int.TryParse(kAndN[0], out int k);
            int.TryParse(kAndN[1], out int n);
            if (CheckValues(k, n, linesOfText))
            {
                return (k, n, linesOfText);
            }
            return (k, n, ["Impossible"] ); 
        }

        public bool CheckValues(int k, int n, string[] linesOfText)
        {
            if (linesOfText.Length < 2) { return false; }
            if ((k < 1 || k > 100) || (n < 1 || n > 1000)) { return false; }
            if (n != linesOfText.Length - 1) { return false; }
            foreach (string line in linesOfText.Skip(1))
            {
                if (line.Length > k) { return false; }
            }
            return true;
        }

        public string ChangeText((int K, int N, string[] linesOfText) separValues) {
            string separText = "";
            if (!CheckValues(separValues.K, separValues.N, separValues.linesOfText)) { return "Impossible"; }
            foreach (string line in separValues.linesOfText.Skip(1))
            {
                int diff = (separValues.K - line.Length) % 2;
                string pluses = "";
                for (int i = 1; i <= (separValues.K - line.Length) / 2; i++)
                {
                    pluses += "+";
                }
                switch (diff)
                {
                    case 0:
                        separText += pluses + line + pluses;
                        break;
                    case 1:
                        separText += pluses + line + pluses + "+";
                        break;
                }
                if (!separValues.linesOfText.ElementAt(separValues.linesOfText.Length - 1).Equals(line)) { separText += "\n"; }
            }
            return separText; 
        }

        public bool WriteToFile(string path, string changedText) {
            if (!File.Exists(path) || String.IsNullOrEmpty(changedText)) { return false; }
            else
            {
                StreamWriter file = new StreamWriter(path);
                file.WriteLine(changedText);
                file.Close();
                return true;
            }
        }

    }
}
