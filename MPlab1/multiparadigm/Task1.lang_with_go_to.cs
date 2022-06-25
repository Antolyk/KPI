using System;
using System.IO;

string s = File.ReadAllText(@"text.txt"); 

s += ' ';

int word_count = 0;

int i = 0;
WordsCounting:
if (s[i] == ' ' || s[i] == '\n') word_count++;
i++;
if (i < s.Length) goto WordsCounting;

Console.WriteLine(word_count);

string[] words = new string[word_count];
int[] wordsRepeats = new int[word_count];
string word = "";
int word_counter = 0;
bool is_in_array;
i = 0;

MainLoop:
if ((s[i] == ' ' || s[i] == '\n' || s[i] == '\r') && word != "")
{
    is_in_array = false;
    int j = 0;

RepeatsLoop:
    if (words[j] == word)
    {
        wordsRepeats[j]++;
        is_in_array = true;
        goto RepeatsLoopEnd;
    }
    j++;
    if (words[j] != null) goto RepeatsLoop;

    RepeatsLoopEnd:
    if (!is_in_array)
    {
        words[word_counter] = word;
        wordsRepeats[word_counter] = 1;
        word_counter++;
    }

    word = "";

}
else if (s[i] != ',' && s[i] != '.' && s[i] != '?' && s[i] != '!' && s[i] != '"' && s[i] != ' ' && s[i] != '\n')
{
    if (s[i] >= 65 && s[i] <= 90)
    {
        word += (char)((int)s[i] + 32);
    }
    word += s[i];
}
i++;
if (i < s.Length) goto MainLoop;


Array.Resize(ref words, word_counter);
Array.Resize(ref wordsRepeats, word_counter);

i = 0;
int z = 0;
loop_outerBubbleSort:
if (i < word_counter)
{
loop_innerBubbleSort:
    if (z < word_counter - i - 1)
    {
        if (wordsRepeats[z] < wordsRepeats[z + 1])
        {
            word = words[z];
            int key = wordsRepeats[z];

            wordsRepeats[z] = wordsRepeats[z + 1];
            words[z] = words[z + 1];

            wordsRepeats[z + 1] = key;
            words[z + 1] = word;
        }
        z++;
        goto loop_innerBubbleSort;
    }
    i++;
    z = 0;
    goto loop_outerBubbleSort;
}

i = 0;
loop_print:
if (i < word_counter)
{
    if (wordsRepeats[i] != 0)
    {
        if(words[i] != "the" && words[i] != "a" && words[i] != "for")
            Console.WriteLine($"{words[i]} - {wordsRepeats[i]}");
    }
    i++;
    goto loop_print;
}
