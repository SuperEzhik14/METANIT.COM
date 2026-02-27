using System.Collections;

namespace GroupLogin
{
    
}






public class MyMasiv : IEnumerable<string>
{
    public readonly string[] masiv;

    public MyMasiv(params string[] masiv)
    {
        this.masiv = masiv;
    }
    public IEnumerable<string> GetProducts(int num)
    {
        for (int i = 0; i < num; i++)
        {
            yield return Convert.ToString(i);
        }
    }
    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < masiv.Length; i++)
        {
            yield return masiv[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


