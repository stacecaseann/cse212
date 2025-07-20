public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}
//There's a text string
//Stacks are LIFO
//loop through eaach letter in the text and add the letter on the stack (like a pancake)
//Then go through the stack and take the letters off
//The result should be the text backwards
//string is abcdefg
//goes on the stack like abcdefg
//pops off gfedcba
//racecar would be racecar
//stressed would be desserts
//a but for a jar of tuna would be a nut of raj
