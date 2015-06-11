using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class Photo
    {
        public string MetaInfo { get; private set; }

        public string Path { get; private set; }

        internal async Task Load(string fullName)
        {
            await Task.Delay(100);
            //using (var client = new HttpClient())
            //{
            //    MetaInfo = await client.GetStringAsync("http://bing.com/images/meta/" + fullName);
            //}

            Path = fullName;
        }
    }
}