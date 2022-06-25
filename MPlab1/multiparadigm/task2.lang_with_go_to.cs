using System;
using System.IO;

string s = File.ReadAllText(@"text1.txt");

s += ' ';

int word_count = 0;

int i = 0, j = 0;
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
    j = 0;

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
else if (s[i] != ',' && s[i] != '.' && s[i] != '?' && s[i] != '!' && s[i] != '"' && s[i] != ' ' && s[i] != '\n' && s[i] != '(' && s[i] != ')')
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


int write = 0;
int sort = 0;
bool toSwapWords = false;
int counter = 0;
int wordLenthCurren = 0;
int wordLenthNext = 0;
loop_outerBubbleSort:
if (write < words.Length && words[write] != null)
{
    sort = 0;
loop_innerBubbleSort:
    if (sort < words.Length - write - 1 && words[sort + 1] != null)
    {
        wordLenthCurren = words[sort].Length;
        wordLenthNext = words[sort + 1].Length;

        int compareLenth = wordLenthCurren > wordLenthNext ? wordLenthNext : wordLenthCurren;

        toSwapWords = false;
        counter = 0;
    check_alphabet:

        if (words[sort][counter] > words[sort + 1][counter])
        {
            toSwapWords = true;
            goto loop_checkAlphabetEnd;
        }
        if (words[sort][counter] < words[sort + 1][counter])
            goto loop_checkAlphabetEnd;
        counter++;
        if (counter < compareLenth)
            goto check_alphabet;
        loop_checkAlphabetEnd:
        if (toSwapWords)
        {
            string temp = words[sort];
            int temp_n = wordsRepeats[sort];

            words[sort] = words[sort + 1];
            wordsRepeats[sort] = wordsRepeats[sort + 1];

            words[sort + 1] = temp;
            wordsRepeats[sort + 1] = temp_n;
        }
        sort++;
        goto loop_innerBubbleSort;
    }
    write++;
    goto loop_outerBubbleSort;
}


int[][] pages = new int[word_counter][];
j = 0;
PageCountLoop:

pages[j] = new int[wordsRepeats[j]];

i = 0;
int u = 0;
PagesLoop:
if ((s[u] == ' ' || s[u] == '\n' || s[u] == '\r') && word != "")
{
    if (words[j] == word)
    {
        pages[j][i] = u / 1800;
        i++;
    }

    word = "";
}
else if (s[u] != ',' && s[u] != '.' && s[u] != '?' && s[u] != '!' && s[u] != '"' && s[u] != ' ' && s[u] != '\n')
{
    word += s[u];
}
u++;
if (u < s.Length) goto PagesLoop;
j++;
if (j < word_counter) goto PageCountLoop;


i = 0;
j = 0;

PrintLoop:
string p = "";
j = 0;
LinkPrint:

p += pages[i][j];
if (j != pages.Length - 1) p += ',';
j++;
if (j < wordsRepeats[i]) goto LinkPrint;
Console.WriteLine(words[i] + " - " + p);
i++;
if (i < words.Length) goto PrintLoop;
