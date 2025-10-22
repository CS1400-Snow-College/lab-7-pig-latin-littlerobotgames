//Alex Gardner 10/21/25 PigLatin Cryptogram
using System.Diagnostics.Metrics;

char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

Console.WriteLine("Let's manipulate your phrase!");
Console.Write("Please enter your message: ");
string[] phrase = Console.ReadLine().ToLower().Split(" ");

//Convert to PigLatin
for (int i = 0; i < phrase.Length; i++)
{
    //Check vowel start
    bool vowelStart = false;
    foreach(char letter in vowels)
    {
        if (phrase[i].StartsWith(letter))
        {
            vowelStart = true;
            break;
        }
    }

    if (vowelStart)
    {
        phrase[i] += "way";
    }
    else
    {
        //Find closest vowel
        int closestIndex = phrase[i].Length;

        foreach(char letter in vowels)
        {
            int tempIndex = phrase[i].IndexOf(letter);

            if (tempIndex != -1)
            {
                if (tempIndex < closestIndex)
                {
                    closestIndex = tempIndex;
                }
            }
        }

        string beginning = phrase[i].Substring(0, closestIndex);

        phrase[i] = phrase[i].Remove(0, closestIndex);
        phrase[i] += beginning + "ay";
    }
}
//Recombine the whole phrase
string fullPhrase = "";

foreach(string word in phrase)
{
    fullPhrase += word + " ";
}

Console.WriteLine("In piglatin that's: " +  fullPhrase);

//Offset each letter
char[] chars = fullPhrase.ToCharArray();
Random rand = new Random();
for(int i = 0; i < chars.Length; i++)
{
    if (chars[i] != ' ')
    {
        int randomOffset = rand.Next(1, 26);
        chars[i] = (char)(chars[i] + randomOffset);
    }
}

string jumbledPhrase = new string(chars);
Console.WriteLine("Encrypted phrase: " + jumbledPhrase);