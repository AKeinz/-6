namespace Zadanie
{
    public class ChangeMail
    {
        public string ReadFromFile(string path) { return $"Файл {path} не найден!"; }

        public (int K,int N,string text) GetSeparatedValues(string text) { return (0,0,"Impossible"); }

        public string ChangeText((int K, int N, string text) separValues) { return "Impossible"; }

        public bool WriteToFile(string path) { return false; }

    }
}
